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
        void UpdateTitle(string title);
        void UpdateAcronym(string acronym);
        void UpdatePeriodDate(PeriodDate periodDate);
    }
}
