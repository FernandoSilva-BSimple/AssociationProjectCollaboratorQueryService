using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Factory.CollaboratorFactory;
using Domain.Factory.ProjectFactory;
using Domain.Factory.UserFactory;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;

namespace Application.Services;

public class CollaboratorService : ICollaboratorService
{
    private readonly ICollaboratorRepository _collaboratorRepository;
    private readonly ICollaboratorFactory _collaboratorFactory;
    private readonly IMapper _mapper;

    public CollaboratorService(ICollaboratorRepository collaboratorRepository, ICollaboratorFactory collaboratorFactory, IMapper mapper)
    {
        _collaboratorRepository = collaboratorRepository;
        _collaboratorFactory = collaboratorFactory;
        _mapper = mapper;
    }

    public async Task<Result<CreatedCollaboratorFromMessageDTO>> AddConsumedCollaboratorAsync(CreateCollaboratorFromMessageDTO collabDTO)
    {
        var newCollaborator = _collaboratorFactory.Create(collabDTO.Id, collabDTO.UserId, collabDTO.PeriodDateTime);
        var collaboratorCreated = await _collaboratorRepository.AddAsync(newCollaborator);
        var collaboratorDTOCreated = _mapper.Map<CreatedCollaboratorFromMessageDTO>(collaboratorCreated);
        return Result<CreatedCollaboratorFromMessageDTO>.Success(collaboratorDTOCreated);
    }

    public async Task<Result> UpdateConsumedCollaboratorAsync(UpdateCollaboratorFromMessageDTO dto)
    {
        var existing = await _collaboratorRepository.GetByIdAsync(dto.Id);
        if (existing is null)
        {
            return Result.Failure(Error.BadRequest("Collaborator not found."));
        }

        existing.UpdatePeriod(dto.PeriodDateTime);

        await _collaboratorRepository.UpdateAsync(existing);

        return Result.Success();
    }

}