using Domain.Factory;
using Domain.IRepository;
using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;
using Moq;

namespace Domain.Tests.AssociationProjectCollaboratorTests;

public class AssociationProjectCollaboratorFactoryTests
{
    [Fact]
    public void WhenCreatingFromVisitor_ThenAssociationIsCreatedCorrectly()
    {
        // Arrange
        var visitorMock = new Mock<IAssociationProjectCollaboratorVisitor>();
        var id = Guid.NewGuid();
        var projectId = Guid.NewGuid();
        var collaboratorId = Guid.NewGuid();
        var period = new PeriodDate(new DateOnly(2025, 7, 1), new DateOnly(2025, 7, 10));

        visitorMock.Setup(v => v.Id).Returns(id);
        visitorMock.Setup(v => v.ProjectId).Returns(projectId);
        visitorMock.Setup(v => v.CollaboratorId).Returns(collaboratorId);
        visitorMock.Setup(v => v.PeriodDate).Returns(period);

        var factory = new AssociationProjectCollaboratorFactory();

        // Act
        var assoc = factory.Create(visitorMock.Object);

        // Assert
        Assert.Equal(id, assoc.Id);
        Assert.Equal(projectId, assoc.ProjectId);
        Assert.Equal(collaboratorId, assoc.CollaboratorId);
        Assert.Equal(period, assoc.PeriodDate);
    }
}
