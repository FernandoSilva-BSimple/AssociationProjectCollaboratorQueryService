using Application.DTO;

namespace Application.Interfaces;

public interface ICollaboratorService
{
    Task<Result<CreatedCollaboratorFromMessageDTO>> AddConsumedCollaboratorAsync(CreateCollaboratorFromMessageDTO collaboratorDTO);

}