using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataModel;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CollaboratorRepositoryEF : GenericRepositoryEF<ICollaborator, Collaborator, CollaboratorDataModel>, ICollaboratorRepository
{
    private readonly IMapper _mapper;

    public CollaboratorRepositoryEF(AssociationDbContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
    }

    public override ICollaborator? GetById(Guid id)
    {
        var collabDM = _context.Set<CollaboratorDataModel>().FirstOrDefault(t => t.Id == id);

        if (collabDM == null) return null;

        return _mapper.Map<CollaboratorDataModel, Collaborator>(collabDM);
    }

    public override async Task<ICollaborator?> GetByIdAsync(Guid id)
    {
        var collabDM = await _context.Set<CollaboratorDataModel>().FirstOrDefaultAsync(t => t.Id == id);

        if (collabDM == null) return null;

        return _mapper.Map<CollaboratorDataModel, Collaborator>(collabDM);
    }

    public async Task UpdateAsync(ICollaborator collaborator)
    {
        var existing = await _context.Set<CollaboratorDataModel>().FirstOrDefaultAsync(c => c.Id == collaborator.Id);
        if (existing == null) return;

        existing.PeriodDateTime = collaborator.PeriodDateTime;

        await _context.SaveChangesAsync();
    }

}
