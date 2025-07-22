using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Infrastructure.DataModel;

public class ProjectDataModel : IProjectVisitor
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Acronym { get; set; }
    public PeriodDate PeriodDate { get; set; }


    public ProjectDataModel(IProject project)
    {
        Id = project.Id;
        Title = project.Title;
        Acronym = project.Acronym;
        PeriodDate = project.PeriodDate;
    }

    public ProjectDataModel() { }

}