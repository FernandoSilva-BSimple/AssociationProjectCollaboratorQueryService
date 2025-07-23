using Domain.Interfaces;
using Domain.Models;
using Domain.Visitors;

namespace Domain.Factory.UserFactory;

public interface IUserFactory
{
    IUser Create(Guid id, string names, string email);
    User Create(IUserVisitor visitor);
}