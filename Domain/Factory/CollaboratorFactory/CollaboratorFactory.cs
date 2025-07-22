using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;
using Domain.Visitors;

namespace Domain.Factory.CollaboratorFactory
{
    public class CollaboratorFactory : ICollaboratorFactory
    {
        public ICollaborator Create(Guid id, Guid userId, PeriodDateTime periodDateTime)
        {
            return new Collaborator(id, userId, periodDateTime);
        }

        public ICollaborator Create(ICollaboratorVisitor visitor)
        {
            return new Collaborator(visitor.Id, visitor.UserId, visitor.PeriodDateTime);
        }
    }
}
