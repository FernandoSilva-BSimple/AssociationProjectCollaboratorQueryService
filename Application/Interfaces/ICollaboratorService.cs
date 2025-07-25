using Application.DTO;

namespace Application.Interfaces;

public interface ICollaboratorService
{
    Task<Result<CreatedCollaboratorFromMessageDTO>> AddConsumedCollaboratorAsync(CreateCollaboratorFromMessageDTO collaboratorDTO);
    Task<Result> UpdateConsumedCollaboratorAsync(UpdateCollaboratorFromMessageDTO dto);

}