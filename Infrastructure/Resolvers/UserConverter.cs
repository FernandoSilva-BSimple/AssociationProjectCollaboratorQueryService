using AutoMapper;
using Domain.Factory;
using Domain.Factory.CollaboratorFactory;
using Domain.Factory.ProjectFactory;
using Domain.Factory.UserFactory;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DataModel;

namespace Infrastructure.Resolvers;

public class UserConverter : ITypeConverter<UserDataModel, User>
{
    private readonly IUserFactory _factory;

    public UserConverter(IUserFactory factory)
    {
        _factory = factory;
    }

    public User Convert(UserDataModel source, User destination, ResolutionContext context)
    {
        return _factory.Create(source);
    }
}
