using System;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUser
    {
        Guid Id { get; }
        string Names { get; }
        string Email { get; }
        void UpdateNames(string names);
        void UpdateEmail(string names);

    }
}
