using Application.DTO;
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
}