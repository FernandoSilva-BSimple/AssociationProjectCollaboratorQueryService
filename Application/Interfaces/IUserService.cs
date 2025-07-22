using Application.DTO;

namespace Application.Interfaces;

public interface IUserService
{
    Task<Result<CreatedUserFromMessageDTO>> AddConsumedUserAsync(CreateUserFromMessageDTO userDTO);

}