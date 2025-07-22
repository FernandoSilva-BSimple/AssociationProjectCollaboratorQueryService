using Domain.Models;

namespace Application.DTO;

public record CreateUserFromMessageDTO
{
    public Guid Id { get; set; }
    public string Names { get; set; }
    public string Email { get; set; }

    public CreateUserFromMessageDTO(Guid id, string names, string email)
    {
        Id = id;
        Names = names;
        Email = email;
    }

    public CreateUserFromMessageDTO() { }
}

