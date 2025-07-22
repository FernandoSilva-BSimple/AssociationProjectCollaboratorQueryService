using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;
using Domain.Visitors;

namespace Domain.Factory.ProjectFactory
{
    public class ProjectFactory : IProjectFactory
    {
        public IProject Create(Guid id, string title, string acronym, PeriodDate periodDate)
        {
            return new Project(id, title, acronym, periodDate);
        }

        public IProject Create(IProjectVisitor visitor)
        {
            return new Project(visitor.Id, visitor.Title, visitor.Acronym, visitor.PeriodDate);
        }
    }
}
