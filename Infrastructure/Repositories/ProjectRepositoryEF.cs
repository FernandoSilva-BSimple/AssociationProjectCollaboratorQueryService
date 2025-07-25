using AutoMapper;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Infrastructure.DataModel;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProjectRepositoryEF : GenericRepositoryEF<IProject, Project, ProjectDataModel>, IProjectRepository
{
    private readonly IMapper _mapper;

    public ProjectRepositoryEF(AssociationDbContext context, IMapper mapper) : base(context, mapper)
    {
        _mapper = mapper;
    }

    public override IProject? GetById(Guid id)
    {
        var projectDM = _context.Set<ProjectDataModel>().FirstOrDefault(t => t.Id == id);

        if (projectDM == null) return null;

        return _mapper.Map<ProjectDataModel, Project>(projectDM);
    }

    public override async Task<IProject?> GetByIdAsync(Guid id)
    {
        var projectDM = await _context.Set<ProjectDataModel>().FirstOrDefaultAsync(t => t.Id == id);

        if (projectDM == null) return null;

        return _mapper.Map<ProjectDataModel, Project>(projectDM);
    }

    public async Task UpdateAsync(IProject project)
    {
        var existing = await _context.Set<ProjectDataModel>().FirstOrDefaultAsync(p => p.Id == project.Id);
        if (existing == null) return;

        existing.Title = project.Title;
        existing.Acronym = project.Acronym;
        existing.PeriodDate.InitDate = project.PeriodDate.InitDate;
        existing.PeriodDate.FinalDate = project.PeriodDate.FinalDate;

        await _context.SaveChangesAsync();
    }

}
