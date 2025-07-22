using Domain.Models;

namespace Application.DTO;

public record CreateProjectFromMessageDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Acronym { get; set; }
    public PeriodDate PeriodDate { get; set; }

    public CreateProjectFromMessageDTO(Guid id, string title, string acronym, PeriodDate periodDate)
    {
        Id = id;
        Title = title;
        Acronym = acronym;
        PeriodDate = periodDate;
    }

    public CreateProjectFromMessageDTO() { }
}

