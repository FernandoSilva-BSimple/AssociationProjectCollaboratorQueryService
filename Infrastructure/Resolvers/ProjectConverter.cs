using AutoMapper;
using Domain.Factory;
using Domain.Factory.CollaboratorFactory;
using Domain.Factory.ProjectFactory;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DataModel;

namespace Infrastructure.Resolvers;

public class ProjectConverter : ITypeConverter<ProjectDataModel, Project>
{
    private readonly IProjectFactory _factory;

    public ProjectConverter(IProjectFactory factory)
    {
        _factory = factory;
    }

    public Project Convert(ProjectDataModel source, Project destination, ResolutionContext context)
    {
        return _factory.Create(source);
    }
}
