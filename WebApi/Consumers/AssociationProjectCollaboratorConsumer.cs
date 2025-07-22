using MassTransit;
using Domain.Messages;

public class AssociationProjectCollaboratorCreatedConsumer : IConsumer<AssociationProjectCollaboratorCreatedMessage>
{
    private readonly AssociationProjectCollaboratorService _assocService;

    public AssociationProjectCollaboratorCreatedConsumer(AssociationProjectCollaboratorService assPCService)
    {
        _assocService = assPCService;
    }

    public async Task Consume(ConsumeContext<AssociationProjectCollaboratorCreatedMessage> context)
    {
        var message = context.Message;
        var dto = new CreateAssociationProjectCollaboratorFromMessageDTO(message.Id, message.ProjectId, message.CollaboratorId, message.PeriodDate);
        await _assocService.AddConsumedAssociationProjectCollaboratorAsync(dto);
    }
}