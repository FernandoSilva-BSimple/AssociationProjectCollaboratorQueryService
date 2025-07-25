using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Domain.Visitors;

public interface ICollaboratorRepository : IGenericRepositoryEF<ICollaborator, Collaborator, ICollaboratorVisitor>
{
    Task UpdateAsync(ICollaborator collaborator);

}