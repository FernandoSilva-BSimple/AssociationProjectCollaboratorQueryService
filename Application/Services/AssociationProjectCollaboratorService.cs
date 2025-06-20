using Application;
using Application.DTO;
using AutoMapper;
using Domain.Factory;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;

public class AssociationProjectCollaboratorService
{
    private readonly IAssociationProjectCollaboratorRepository _assocRepository;
    private readonly IAssociationProjectCollaboratorFactory _factory;
    private readonly IMapper _mapper;

    public AssociationProjectCollaboratorService(IAssociationProjectCollaboratorRepository assocRepository, IAssociationProjectCollaboratorFactory factory, IMapper mapper)
    {
        _assocRepository = assocRepository;
        _mapper = mapper;
        _factory = factory;
    }

    public async Task<Result<AssociationProjectCollaboratorDTO>> GetByIdAsync(Guid id)
    {
        var assoc = await _assocRepository.GetByIdAsync(id);
        if (assoc == null) return Result<AssociationProjectCollaboratorDTO>.Failure(Error.NotFound("Association not found."));

        var result = _mapper.Map<AssociationProjectCollaboratorDTO>(assoc);
        return Result<AssociationProjectCollaboratorDTO>.Success(result);
    }

    public async Task CreateWithoutValidations(Guid id, Guid projectId, Guid collaboratorId, PeriodDate periodDate)
    {
        IAssociationProjectCollaborator assPC;

        assPC = _factory.Create(id, projectId, collaboratorId, periodDate);
        await _assocRepository.AddAsync(assPC);
    }

}
