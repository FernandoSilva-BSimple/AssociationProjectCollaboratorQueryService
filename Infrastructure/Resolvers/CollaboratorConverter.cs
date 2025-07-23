using AutoMapper;
using Domain.Factory;
using Domain.Factory.CollaboratorFactory;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DataModel;

namespace Infrastructure.Resolvers;

public class CollaboratorConverter : ITypeConverter<CollaboratorDataModel, Collaborator>
{
    private readonly ICollaboratorFactory _factory;

    public CollaboratorConverter(ICollaboratorFactory factory)
    {
        _factory = factory;
    }

    public Collaborator Convert(CollaboratorDataModel source, Collaborator destination, ResolutionContext context)
    {
        return _factory.Create(source);
    }
}
