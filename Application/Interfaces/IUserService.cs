using Application.DTO;
using Application.DTO.User;

namespace Application.Interfaces;

public interface IUserService
{
    Task<Result<CreatedUserFromMessageDTO>> AddConsumedUserAsync(CreateUserFromMessageDTO userDTO);
    Task<Result> UpdateConsumedUserAsync(UpdateUserFromMessageDTO dto);

}