using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Domain.Factory
{
    public interface IAssociationProjectCollaboratorFactory
    {
        IAssociationProjectCollaborator Create(Guid id, Guid projectId, Guid collaboratorId, PeriodDate periodDate);
        AssociationProjectCollaborator Create(IAssociationProjectCollaboratorVisitor visitor);

    }
}
