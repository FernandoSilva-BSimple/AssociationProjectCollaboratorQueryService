using Domain.Models;

namespace Application.DTO;

public record CreatedUserFromMessageDTO
{
    public Guid Id { get; set; }
    public string Names { get; set; }
    public string Email { get; set; }

    public CreatedUserFromMessageDTO()
    {

    }
}

