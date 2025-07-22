using Domain.Models;

namespace Application.DTO;

public record CreateCollaboratorFromMessageDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public PeriodDateTime PeriodDateTime { get; set; }

    public CreateCollaboratorFromMessageDTO(Guid id, Guid userId, PeriodDateTime periodDateTime)
    {
        Id = id;
        UserId = userId;
        PeriodDateTime = periodDateTime;
    }

    public CreateCollaboratorFromMessageDTO() { }
}

