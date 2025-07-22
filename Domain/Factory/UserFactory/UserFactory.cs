using Domain.Interfaces;
using Domain.Models;
using Domain.Visitor;
using Domain.Visitors;

namespace Domain.Factory.UserFactory
{
    public class UserFactory : IUserFactory
    {
        public IUser Create(Guid id, string names, string email)
        {
            return new User(id, names, email);
        }

        public IUser Create(IUserVisitor visitor)
        {
            return new User(visitor.Id, visitor.Names, visitor.Email);
        }
    }
}
