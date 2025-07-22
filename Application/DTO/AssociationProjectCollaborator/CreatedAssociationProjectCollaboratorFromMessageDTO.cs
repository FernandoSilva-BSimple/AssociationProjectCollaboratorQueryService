using Domain.Models;

public record CreatedAssociationProjectCollaboratorFromMessageDTO
{
    public Guid Id { get; init; }
    public Guid ProjectId { get; init; }
    public Guid CollaboratorId { get; init; }
    public PeriodDate PeriodDate { get; init; }

    public CreatedAssociationProjectCollaboratorFromMessageDTO(Guid id, Guid projectId, Guid collaboratorId, PeriodDate periodDate)
    {
        Id = id;
        ProjectId = projectId;
        CollaboratorId = collaboratorId;
        PeriodDate = periodDate;
    }

    public CreatedAssociationProjectCollaboratorFromMessageDTO() { }
}


