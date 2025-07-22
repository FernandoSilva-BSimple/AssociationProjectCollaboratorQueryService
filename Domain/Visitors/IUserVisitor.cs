using Domain.Models;

namespace Domain.Visitors;

public interface IUserVisitor
{
    Guid Id { get; }
    string Names { get; }
    string Email { get; }
}
