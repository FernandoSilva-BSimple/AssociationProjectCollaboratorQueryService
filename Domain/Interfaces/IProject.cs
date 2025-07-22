using System;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IProject
    {
        Guid Id { get; }
        string Title { get; }
        string Acronym { get; }
        PeriodDate PeriodDate { get; }
    }
}
