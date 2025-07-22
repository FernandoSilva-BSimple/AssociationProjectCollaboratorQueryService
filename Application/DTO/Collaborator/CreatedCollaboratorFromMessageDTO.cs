using Domain.Models;

namespace Application.DTO;

public record CreatedCollaboratorFromMessageDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public PeriodDateTime PeriodDateTime { get; set; }

    public CreatedCollaboratorFromMessageDTO()
    {

    }
}

