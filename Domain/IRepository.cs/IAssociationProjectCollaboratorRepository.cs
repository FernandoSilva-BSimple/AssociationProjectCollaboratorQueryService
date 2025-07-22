using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;

namespace Domain.IRepository;

public interface IAssociationProjectCollaboratorRepository : IGenericRepositoryEF<IAssociationProjectCollaborator, AssociationProjectCollaborator, IAssociationProjectCollaboratorVisitor>
{
    Task<IEnumerable<IAssociationProjectCollaborator>> FindAllByCollaboratorAsync(Guid collabId);

    Task<IEnumerable<IAssociationProjectCollaborator>> FindAllByProjectAsync(Guid projectId);

    Task<IAssociationProjectCollaborator?> FindByProjectAndCollaboratorAsync(Guid projectId, Guid collaboratorId);

    Task<IEnumerable<IAssociationProjectCollaborator>> FindAllByProjectAndCollaboratorAsync(Guid projectId, Guid collaboratorId);

    Task<IEnumerable<IAssociationProjectCollaborator>> FindAllByProjectAndIntersectingPeriodAsync(Guid projectId, PeriodDate periodDate);

    Task<IEnumerable<IAssociationProjectCollaborator>> FindAllByProjectAndCollaboratorAndBetweenPeriodAsync(Guid projectId, Guid collaboratorId, PeriodDate periodDate);

    Task<bool> CanInsert(PeriodDate periodDate, Guid collaboratorId, Guid projectId);
}
