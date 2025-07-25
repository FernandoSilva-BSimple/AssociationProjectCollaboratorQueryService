using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Factory;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DataModel;
using Infrastructure.Repositories;
using Moq;
using Xunit;

namespace Infrastructure.Tests.AssociationProjectCollaboratorRepositoryTests;

public class AssociationProjectCollaboratorRepositoryTests : RepositoryTestBase
{
    private readonly Mock<IAssociationProjectCollaboratorFactory> _factory;
    private readonly AssociationProjectCollaboratorRepositoryEF _repository;
    private readonly Mock<IMapper> _mapper = new Mock<IMapper>();

    public AssociationProjectCollaboratorRepositoryTests()
    {
        _factory = new Mock<IAssociationProjectCollaboratorFactory>();
        _repository = new AssociationProjectCollaboratorRepositoryEF(context, _mapper.Object);
    }

    [Fact]
    public async Task FindAllByProjectAndCollaboratorAsync_ReturnsMatches()
    {
        var collabId = Guid.NewGuid();
        var projectId = Guid.NewGuid();
        var assoc = CreateAssociation(collabId, projectId);
        context.Associations.Add(assoc);
        await context.SaveChangesAsync();

        var result = await _repository.FindAllByProjectAndCollaboratorAsync(projectId, collabId);

        Assert.Single(result);
    }

    [Fact]
    public async Task FindAllByProjectAndIntersectingPeriodAsync_ReturnsIntersecting()
    {
        var projectId = Guid.NewGuid();
        var assoc = CreateAssociation(Guid.NewGuid(), projectId, new DateOnly(2024, 5, 1), new DateOnly(2024, 6, 30));
        context.Associations.Add(assoc);
        await context.SaveChangesAsync();

        var period = new PeriodDate(new DateOnly(2024, 6, 1), new DateOnly(2024, 7, 1));

        var result = await _repository.FindAllByProjectAndIntersectingPeriodAsync(projectId, period);

        Assert.Single(result);
    }

    [Fact]
    public async Task FindAllByProjectAndCollaboratorAndBetweenPeriodAsync_ReturnsMatches()
    {
        var collabId = Guid.NewGuid();
        var projectId = Guid.NewGuid();
        var assoc = CreateAssociation(collabId, projectId, new DateOnly(2024, 5, 1), new DateOnly(2024, 6, 30));
        context.Associations.Add(assoc);
        await context.SaveChangesAsync();

        var period = new PeriodDate(new DateOnly(2024, 4, 1), new DateOnly(2024, 5, 15));

        var result = await _repository.FindAllByProjectAndCollaboratorAndBetweenPeriodAsync(projectId, collabId, period);

        Assert.Single(result);
    }

    [Fact]
    public async Task CanInsert_ReturnsFalse_WhenOverlapExists()
    {
        var collabId = Guid.NewGuid();
        var projectId = Guid.NewGuid();
        var assoc = CreateAssociation(collabId, projectId, new DateOnly(2024, 5, 1), new DateOnly(2024, 7, 1));
        context.Associations.Add(assoc);
        await context.SaveChangesAsync();

        var period = new PeriodDate(new DateOnly(2024, 6, 1), new DateOnly(2024, 8, 1));

        var result = await _repository.CanInsert(period, collabId, projectId);

        Assert.False(result);
    }

    [Fact]
    public async Task CanInsert_ReturnsTrue_WhenNoOverlap()
    {
        var collabId = Guid.NewGuid();
        var projectId = Guid.NewGuid();
        var assoc = CreateAssociation(collabId, projectId, new DateOnly(2024, 1, 1), new DateOnly(2024, 3, 1));
        context.Associations.Add(assoc);
        await context.SaveChangesAsync();

        var period = new PeriodDate(new DateOnly(2024, 4, 1), new DateOnly(2024, 5, 1));

        var result = await _repository.CanInsert(period, collabId, projectId);

        Assert.True(result);
    }

    private AssociationProjectCollaboratorDataModel CreateAssociation(Guid collabId, Guid projectId, DateOnly? init = null, DateOnly? end = null)
    {
        return new AssociationProjectCollaboratorDataModel
        {
            Id = Guid.NewGuid(),
            CollaboratorId = collabId,
            ProjectId = projectId,
            PeriodDate = new PeriodDate
            {
                InitDate = init ?? new DateOnly(2024, 1, 1),
                FinalDate = end ?? new DateOnly(2024, 12, 31)
            }
        };
    }
}