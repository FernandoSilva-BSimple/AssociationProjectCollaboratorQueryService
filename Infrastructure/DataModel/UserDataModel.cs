using Domain.Interfaces;
using Domain.Visitors;

namespace Infrastructure.DataModel;

public class UserDataModel : IUserVisitor
{
    public Guid Id { get; set; }
    public string Names { get; set; }
    public string Email { get; set; }

    public UserDataModel(IUser user)
    {
        Id = user.Id;
        Names = user.Names;
        Email = user.Email;
    }

    public UserDataModel() { }

}