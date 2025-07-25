using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataModel;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepositoryEF : GenericRepositoryEF<IUser, User, UserDataModel>, IUserRepository
{
    private readonly IMapper _mapper;

    public UserRepositoryEF(AssociationDbContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
    }

    public override IUser? GetById(Guid id)
    {
        var userDM = _context.Set<UserDataModel>().FirstOrDefault(t => t.Id == id);

        if (userDM == null) return null;

        return _mapper.Map<UserDataModel, User>(userDM);
    }

    public override async Task<IUser?> GetByIdAsync(Guid id)
    {
        var userDM = await _context.Set<UserDataModel>().FirstOrDefaultAsync(t => t.Id == id);

        if (userDM == null) return null;

        return _mapper.Map<UserDataModel, User>(userDM);
    }

    public async Task UpdateAsync(IUser user)
    {
        var existing = await _context.Set<UserDataModel>().FirstOrDefaultAsync(u => u.Id == user.Id);
        if (existing == null) return;

        existing.Names = user.Names;
        existing.Email = user.Email;

        await _context.SaveChangesAsync();
    }

}
