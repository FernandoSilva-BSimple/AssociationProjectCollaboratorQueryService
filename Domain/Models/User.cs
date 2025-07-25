using Domain.Interfaces;

namespace Domain.Models;

public class User : IUser
{
    public Guid Id { get; set; }
    public string Names { get; set; }
    public string Email { get; set; }

    public User(Guid id, string names, string email)
    {
        Id = id;
        Names = names;
        Email = email;
    }

    public void UpdateNames(string names)
    {
        Names = names;
    }

    public void UpdateEmail(string email)
    {
        Email = email;
    }


}