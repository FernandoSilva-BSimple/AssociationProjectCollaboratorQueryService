using Application.DTO;
using Application.Interfaces;
using Domain.Messages;
using Domain.Models;
using MassTransit;

namespace WebApi.Consumers;

public class CollaboratorUpdatedConsumer : IConsumer<CollaboratorUpdatedMessage>
{
    private readonly ICollaboratorService _collaboratorService;

    public CollaboratorUpdatedConsumer(ICollaboratorService collaboratorService)
    {
        _collaboratorService = collaboratorService;
    }
    public async Task Consume(ConsumeContext<CollaboratorUpdatedMessage> context)
    {
        var message = context.Message;

        var dto = new UpdateCollaboratorFromMessageDTO(message.Id, message.PeriodDateTime);

        await _collaboratorService.UpdateConsumedCollaboratorAsync(dto);
    }
}