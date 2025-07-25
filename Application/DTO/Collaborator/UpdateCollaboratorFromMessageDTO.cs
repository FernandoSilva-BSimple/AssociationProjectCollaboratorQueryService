using Domain.Models;

namespace Application.DTO;

public record UpdateCollaboratorFromMessageDTO
{
    public Guid Id { get; set; }
    public PeriodDateTime PeriodDateTime { get; set; }

    public UpdateCollaboratorFromMessageDTO(Guid id, PeriodDateTime periodDateTime)
    {
        Id = id;
        PeriodDateTime = periodDateTime;
    }

    public UpdateCollaboratorFromMessageDTO() { }
}

