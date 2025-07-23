using Application;
using Application.DTO;
using AutoMapper;
using Domain.Factory;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;

public class AssociationProjectCollaboratorService : IAssociationProjectCollaboratorService
{
    private readonly IAssociationProjectCollaboratorRepository _assocRepository;
    private readonly IAssociationProjectCollaboratorFactory _factory;
    private readonly ICollaboratorRepository _collaboratorRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AssociationProjectCollaboratorService(IAssociationProjectCollaboratorRepository associationProjectCollaboratorRepository, IAssociationProjectCollaboratorFactory factory, ICollaboratorRepository collaboratorRepository, IProjectRepository projectRepository, IUserRepository userRepository, IMapper mapper)
    {
        _assocRepository = associationProjectCollaboratorRepository;
        _factory = factory;
        _collaboratorRepository = collaboratorRepository;
        _projectRepository = projectRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Result<AssociationProjectCollaboratorDTO>> GetByIdAsync(Guid id)
    {
        var assoc = await _assocRepository.GetByIdAsync(id);
        if (assoc == null) return Result<AssociationProjectCollaboratorDTO>.Failure(Error.NotFound("Association not found."));

        var result = _mapper.Map<AssociationProjectCollaboratorDTO>(assoc);
        return Result<AssociationProjectCollaboratorDTO>.Success(result);
    }

    public async Task<Result<CreatedAssociationProjectCollaboratorFromMessageDTO>> AddConsumedAssociationProjectCollaboratorAsync(CreateAssociationProjectCollaboratorFromMessageDTO dto)
    {
        var assPC = _factory.Create(dto.Id, dto.ProjectId, dto.CollaboratorId, dto.PeriodDate);
        var created = await _assocRepository.AddAsync(assPC);
        var resultDTO = _mapper.Map<CreatedAssociationProjectCollaboratorFromMessageDTO>(created);
        return Result<CreatedAssociationProjectCollaboratorFromMessageDTO>.Success(resultDTO);
    }

    public async Task<Result<AssociationProjectCollaboratorDetailsDTO>> GetAssociationDetailsAsync(Guid id)
    {
        var association = await _assocRepository.GetByIdAsync(id);
        if (association == null) return Result<AssociationProjectCollaboratorDetailsDTO>.Failure(Error.NotFound("Association not found."));

        var collaborator = await _collaboratorRepository.GetByIdAsync(association.CollaboratorId);
        if (collaborator == null) return Result<AssociationProjectCollaboratorDetailsDTO>.Failure(Error.NotFound("Collaborator not found."));

        var project = await _projectRepository.GetByIdAsync(association.ProjectId);
        if (project == null) return Result<AssociationProjectCollaboratorDetailsDTO>.Failure(Error.NotFound("Project not found."));

        var user = await _userRepository.GetByIdAsync(collaborator.UserId);
        if (user == null) return Result<AssociationProjectCollaboratorDetailsDTO>.Failure(Error.NotFound("User not found."));

        var detailsDTO = new AssociationProjectCollaboratorDetailsDTO(association.Id, association.ProjectId, association.CollaboratorId, association.PeriodDate, user.Names, user.Email, project.Title, project.Acronym);
        return Result<AssociationProjectCollaboratorDetailsDTO>.Success(detailsDTO);
    }

    public async Task<Result<IEnumerable<AssociationProjectCollaboratorDetailsDTO>>> GetAllWithDetailsByCollaboratorIdAsync(Guid collaboratorId)
    {
        var associations = await _assocRepository.FindAllByCollaboratorAsync(collaboratorId);

        var result = new List<AssociationProjectCollaboratorDetailsDTO>();

        foreach (var association in associations)
        {
            var collaborator = await _collaboratorRepository.GetByIdAsync(association.CollaboratorId);
            if (collaborator == null) return Result<IEnumerable<AssociationProjectCollaboratorDetailsDTO>>.Failure(Error.NotFound("Collaborator not found."));

            var project = await _projectRepository.GetByIdAsync(association.ProjectId);
            if (project == null) return Result<IEnumerable<AssociationProjectCollaboratorDetailsDTO>>.Failure(Error.NotFound("Project not found."));

            var user = await _userRepository.GetByIdAsync(collaborator.UserId);
            if (user == null) return Result<IEnumerable<AssociationProjectCollaboratorDetailsDTO>>.Failure(Error.NotFound("User not found."));

            result.Add(new AssociationProjectCollaboratorDetailsDTO(association.Id, association.ProjectId, association.CollaboratorId, association.PeriodDate, user.Names, user.Email, project.Title, project.Acronym));
        }

        return Result<IEnumerable<AssociationProjectCollaboratorDetailsDTO>>.Success(result);
    }

    public async Task<Result<IEnumerable<AssociationProjectCollaboratorDetailsDTO>>> GetAllWithDetailsByProjectIdAsync(Guid projectId)
    {
        var associations = await _assocRepository.FindAllByProjectAsync(projectId);

        var result = new List<AssociationProjectCollaboratorDetailsDTO>();

        foreach (var association in associations)
        {
            var collaborator = await _collaboratorRepository.GetByIdAsync(association.CollaboratorId);
            if (collaborator == null) return Result<IEnumerable<AssociationProjectCollaboratorDetailsDTO>>.Failure(Error.NotFound("Collaborator not found."));

            var project = await _projectRepository.GetByIdAsync(association.ProjectId);
            if (project == null) return Result<IEnumerable<AssociationProjectCollaboratorDetailsDTO>>.Failure(Error.NotFound("Project not found."));

            var user = await _userRepository.GetByIdAsync(collaborator.UserId);
            if (user == null) return Result<IEnumerable<AssociationProjectCollaboratorDetailsDTO>>.Failure(Error.NotFound("User not found."));

            result.Add(new AssociationProjectCollaboratorDetailsDTO
            {
                CollaboratorId = collaborator.Id,
                CollaboratorName = user.Names,
                CollaboratorEmail = user.Email,
                ProjectId = project.Id,
                ProjectTitle = project.Title,
                ProjectAcronym = project.Acronym,
                PeriodDate = association.PeriodDate
            });
        }

        return Result<IEnumerable<AssociationProjectCollaboratorDetailsDTO>>.Success(result);
    }
}
