using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DataModel;
using Infrastructure.Repositories;
using Moq;
using Xunit;

namespace Infrastructure.Tests.ProjectRepositoryTests;

public class ProjectRepositoryUpdateAsyncTests : RepositoryTestBase
{
    [Fact]
    public async Task WhenUpdatingProject_ThenDataIsUpdated()
    {
        // Arrange
        var id = Guid.NewGuid();
        var titleOriginal = "Projeto Original";
        var acronymOriginal = "PO";

        var originalPeriod = new PeriodDate(new DateOnly(2024, 1, 1), new DateOnly(2024, 12, 31));
        var updatedPeriod = new PeriodDate(new DateOnly(2025, 1, 1), new DateOnly(2025, 12, 31));

        // Entidade original na base de dados
        var originalDM = new ProjectDataModel
        {
            Id = id,
            Title = titleOriginal,
            Acronym = acronymOriginal,
            PeriodDate = originalPeriod
        };
        context.Projects.Add(originalDM);
        await context.SaveChangesAsync();

        // Mock do IProject com dados atualizados
        var updatedTitle = "Projeto Atualizado";
        var updatedAcronym = "PA";

        var projectMock = new Mock<IProject>();
        projectMock.Setup(p => p.Id).Returns(id);
        projectMock.Setup(p => p.Title).Returns(updatedTitle);
        projectMock.Setup(p => p.Acronym).Returns(updatedAcronym);
        projectMock.Setup(p => p.PeriodDate).Returns(updatedPeriod);

        var repository = new ProjectRepositoryEF(context, Mock.Of<IMapper>());

        // Act
        await repository.UpdateAsync(projectMock.Object);

        // Assert
        var updated = await context.Projects.FindAsync(id);
        Assert.NotNull(updated);
        Assert.Equal(updatedTitle, updated!.Title);
        Assert.Equal(updatedAcronym, updated.Acronym);
        Assert.Equal(updatedPeriod.InitDate, updated.PeriodDate.InitDate);
        Assert.Equal(updatedPeriod.FinalDate, updated.PeriodDate.FinalDate);
    }
}
