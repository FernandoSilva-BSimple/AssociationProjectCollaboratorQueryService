using Domain.Interfaces;
using Domain.Visitors;

namespace Domain.Factory.UserFactory;

public interface IUserFactory
{
    IUser Create(Guid id, string names, string email);
    IUser Create(IUserVisitor visitor);
}