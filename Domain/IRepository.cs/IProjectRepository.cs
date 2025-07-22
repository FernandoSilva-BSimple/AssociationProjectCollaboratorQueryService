using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Domain.Visitor;

public interface IProjectRepository : IGenericRepositoryEF<IProject, Project, IProjectVisitor>
{ }
