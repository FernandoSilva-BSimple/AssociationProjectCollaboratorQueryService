using Application.DTO;

namespace Application.Interfaces;

public interface IProjectService
{
    Task<Result<CreatedProjectFromMessageDTO>> AddConsumedProjectAsync(CreateProjectFromMessageDTO projectDTO);

}