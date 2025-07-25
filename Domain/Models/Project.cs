using Domain.Interfaces;

namespace Domain.Models;

public class Project : IProject
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Acronym { get; set; }
    public PeriodDate PeriodDate { get; set; }

    public Project(Guid id, string title, string acronym, PeriodDate periodDate)
    {
        Id = id;
        Title = title;
        Acronym = acronym;
        PeriodDate = periodDate;
    }

    public void UpdateTitle(string title)
    {
        Title = title;
    }

    public void UpdateAcronym(string acronym)
    {
        Acronym = acronym;
    }

    public void UpdatePeriodDate(PeriodDate periodDate)
    {
        PeriodDate = periodDate;
    }


}