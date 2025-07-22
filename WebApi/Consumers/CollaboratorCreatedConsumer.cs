using Application.DTO;
using Application.Interfaces;
using Domain.Messages;
using Domain.Models;
using MassTransit;

namespace WebApi.Consumers;

public class CollaboratorCreatedConsumer : IConsumer<CollaboratorCreatedMessage>
{
    private readonly ICollaboratorService _collaboratorService;

    public CollaboratorCreatedConsumer(ICollaboratorService collaboratorService)
    {
        _collaboratorService = collaboratorService;
    }
    public async Task Consume(ConsumeContext<CollaboratorCreatedMessage> context)
    {
        var message = context.Message;

        var dto = new CreateCollaboratorFromMessageDTO(message.Id, message.UserId, message.PeriodDateTime);

        await _collaboratorService.AddConsumedCollaboratorAsync(dto);
    }
}