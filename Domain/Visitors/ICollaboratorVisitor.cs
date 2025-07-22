using Domain.Models;

namespace Domain.Visitors;

public interface ICollaboratorVisitor
{
    Guid Id { get; }
    Guid UserId { get; }
    PeriodDateTime PeriodDateTime { get; }
}
