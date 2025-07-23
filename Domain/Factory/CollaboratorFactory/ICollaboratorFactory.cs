using Domain.Interfaces;
using Domain.Models;
using Domain.Visitors;

namespace Domain.Factory.CollaboratorFactory;

public interface ICollaboratorFactory
{
    ICollaborator Create(Guid id, Guid userId, PeriodDateTime periodDateTime);
    Collaborator Create(ICollaboratorVisitor visitor);
}