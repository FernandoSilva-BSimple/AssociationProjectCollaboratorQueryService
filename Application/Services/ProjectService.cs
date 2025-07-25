using Application.DTO;
using Application.DTO.Project;
using Application.Interfaces;
using AutoMapper;
using Domain.Factory.ProjectFactory;
using Domain.Factory.UserFactory;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;

namespace Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IProjectFactory _projectFactory;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository projectRepository, IProjectFactory projectFactory, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _projectFactory = projectFactory;
        _mapper = mapper;
    }

    public async Task<Result<CreatedProjectFromMessageDTO>> AddConsumedProjectAsync(CreateProjectFromMessageDTO projectDTO)
    {
        var newProject = _projectFactory.Create(projectDTO.Id, projectDTO.Title, projectDTO.Acronym, projectDTO.PeriodDate);
        var projectCreated = await _projectRepository.AddAsync(newProject);
        var projectDTOCreated = _mapper.Map<CreatedProjectFromMessageDTO>(projectCreated);
        return Result<CreatedProjectFromMessageDTO>.Success(projectDTOCreated);
    }

    public async Task<Result> UpdateConsumedProjectAsync(UpdateProjectFromMessageDTO dto)
    {
        var existingProject = await _projectRepository.GetByIdAsync(dto.Id);
        if (existingProject == null)
            return Result.Failure(Error.BadRequest("Project not found"));

        existingProject.UpdateTitle(dto.Title);
        existingProject.UpdateAcronym(dto.Acronym);
        existingProject.UpdatePeriodDate(dto.PeriodDate);

        await _projectRepository.UpdateAsync(existingProject);

        return Result.Success();
    }

}