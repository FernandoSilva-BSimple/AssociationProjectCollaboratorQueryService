using Domain.Models;

namespace Application.DTO;

public record CreatedProjectFromMessageDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Acronym { get; set; }
    public PeriodDate PeriodDate { get; set; }

    public CreatedProjectFromMessageDTO()
    {

    }
}

