using Domain.Models;

namespace Application.DTO;

public record UpdatedCollaboratorFromMessageDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public PeriodDateTime PeriodDateTime { get; set; }

    public UpdatedCollaboratorFromMessageDTO(Guid id, Guid userId, PeriodDateTime periodDateTime)
    {
        Id = id;
        UserId = userId;
        PeriodDateTime = periodDateTime;
    }

    public UpdatedCollaboratorFromMessageDTO() { }
}

