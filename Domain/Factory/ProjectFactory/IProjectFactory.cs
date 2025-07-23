using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory.ProjectFactory;

public interface IProjectFactory
{
    IProject Create(Guid id, string title, string acronym, PeriodDate periodDate);
    Project Create(IProjectVisitor visitor);
}