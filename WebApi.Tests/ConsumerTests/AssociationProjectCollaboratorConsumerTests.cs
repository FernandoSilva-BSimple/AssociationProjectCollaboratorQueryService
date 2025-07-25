using System;
using System.Threading.Tasks;
using Application;
using Application.DTO;
using Domain.Messages;
using Domain.Models;
using MassTransit;
using Moq;
using Xunit;

public class AssociationProjectCollaboratorCreatedConsumerTests
{
    [Fact]
    public async Task Consume_CallsAddConsumedAssociationProjectCollaboratorAsync_WithCorrectDTO()
    {
        // Arrange
        var serviceMock = new Mock<IAssociationProjectCollaboratorService>();

        var consumer = new AssociationProjectCollaboratorCreatedConsumer(serviceMock.Object);

        var message = new AssociationProjectCollaboratorCreatedMessage(
    Guid.NewGuid(),
    Guid.NewGuid(),
    Guid.NewGuid(),
    new PeriodDate(
        new DateOnly(2025, 1, 1),
        new DateOnly(2025, 12, 31)
    )
);

        var contextMock = new Mock<ConsumeContext<AssociationProjectCollaboratorCreatedMessage>>();
        contextMock.Setup(c => c.Message).Returns(message);

        // Act
        await consumer.Consume(contextMock.Object);

        // Assert
        serviceMock.Verify(s => s.AddConsumedAssociationProjectCollaboratorAsync(
            It.Is<CreateAssociationProjectCollaboratorFromMessageDTO>(dto =>
                dto.Id == message.Id &&
                dto.ProjectId == message.ProjectId &&
                dto.CollaboratorId == message.CollaboratorId &&
                dto.PeriodDate.InitDate == message.PeriodDate.InitDate &&
                dto.PeriodDate.FinalDate == message.PeriodDate.FinalDate
            )
        ), Times.Once);
    }
}
