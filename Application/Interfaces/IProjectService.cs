using Application.DTO;
using Application.DTO.Project;

namespace Application.Interfaces;

public interface IProjectService
{
    Task<Result<CreatedProjectFromMessageDTO>> AddConsumedProjectAsync(CreateProjectFromMessageDTO projectDTO);
    Task<Result> UpdateConsumedProjectAsync(UpdateProjectFromMessageDTO dto);
}