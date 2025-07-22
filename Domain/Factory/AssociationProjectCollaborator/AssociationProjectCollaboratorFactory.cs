using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory
{
    public class AssociationProjectCollaboratorFactory : IAssociationProjectCollaboratorFactory
    {
        public IAssociationProjectCollaborator Create(Guid id, Guid projectId, Guid collaboratorId, PeriodDate periodDate)
        {
            return new AssociationProjectCollaborator(id, projectId, collaboratorId, periodDate);
        }

        public AssociationProjectCollaborator Create(IAssociationProjectCollaboratorVisitor visitor)
        {
            return new AssociationProjectCollaborator(visitor.Id, visitor.ProjectId, visitor.CollaboratorId, visitor.PeriodDate);
        }
    }
}
