using Application;
using Application.DTO;

public interface IAssociationProjectCollaboratorService
{
    Task<Result<CreatedAssociationProjectCollaboratorFromMessageDTO>> AddConsumedAssociationProjectCollaboratorAsync(CreateAssociationProjectCollaboratorFromMessageDTO dto);
    Task<Result<AssociationProjectCollaboratorDTO>> GetByIdAsync(Guid id);
    Task<Result<AssociationProjectCollaboratorDetailsDTO>> GetAssociationDetailsAsync(Guid id);
    Task<Result<IEnumerable<AssociationProjectCollaboratorDetailsDTO>>> GetAllWithDetailsByCollaboratorIdAsync(Guid collaboratorId);
    Task<Result<IEnumerable<AssociationProjectCollaboratorDetailsDTO>>> GetAllWithDetailsByProjectIdAsync(Guid projectId);
}