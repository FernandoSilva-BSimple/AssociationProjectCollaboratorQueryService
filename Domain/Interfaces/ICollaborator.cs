using System;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICollaborator
    {
        Guid Id { get; }
        Guid UserId { get; }
        PeriodDateTime PeriodDateTime { get; }
    }
}
