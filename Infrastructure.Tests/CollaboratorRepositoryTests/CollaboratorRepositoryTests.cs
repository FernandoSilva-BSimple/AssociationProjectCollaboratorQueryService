using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DataModel;
using Infrastructure.Repositories;
using Moq;
using Xunit;

namespace Infrastructure.Tests.CollaboratorRepositoryTests;

public class CollaboratorRepositoryUpdateAsyncTests : RepositoryTestBase
{
    [Fact]
    public async Task WhenUpdatingCollaborator_ThenDataIsUpdated()
    {
        // Arrange
        var id = Guid.NewGuid();
        var userId = Guid.NewGuid();

        var initialPeriod = new PeriodDateTime(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31));
        var updatedPeriod = new PeriodDateTime(new DateTime(2025, 1, 1), new DateTime(2025, 12, 31));

        var originalDM = new CollaboratorDataModel
        {
            Id = id,
            UserId = userId,
            PeriodDateTime = initialPeriod
        };

        context.Collaborators.Add(originalDM);
        await context.SaveChangesAsync();

        // Mock do colaborador com dados atualizados
        var collaboratorMock = new Mock<ICollaborator>();
        collaboratorMock.Setup(c => c.Id).Returns(id);
        collaboratorMock.Setup(c => c.UserId).Returns(userId);
        collaboratorMock.Setup(c => c.PeriodDateTime).Returns(updatedPeriod);

        var repository = new CollaboratorRepositoryEF(context, null!);

        // Act
        await repository.UpdateAsync(collaboratorMock.Object);

        // Assert
        var updated = await context.Collaborators.FindAsync(id);
        Assert.NotNull(updated);
        Assert.Equal(userId, updated!.UserId);
        Assert.Equal(updatedPeriod._initDate, updated.PeriodDateTime._initDate);
        Assert.Equal(updatedPeriod._finalDate, updated.PeriodDateTime._finalDate);
    }
}
