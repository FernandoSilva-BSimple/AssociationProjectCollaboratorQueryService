using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Domain.Visitors;

public interface IUserRepository : IGenericRepositoryEF<IUser, User, IUserVisitor>
{

}