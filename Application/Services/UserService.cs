using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Factory.UserFactory;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserFactory _userFactory;
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, IUserRepository userRepository, IUserFactory userFactory)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _userFactory = userFactory;
    }

    public async Task<Result<CreatedUserFromMessageDTO>> AddConsumedUserAsync(CreateUserFromMessageDTO userDTO)
    {
        var newUser = _userFactory.Create(userDTO.Id, userDTO.Names, userDTO.Email);
        var userCreated = await _userRepository.AddAsync(newUser);
        var userDTOCreated = _mapper.Map<CreatedUserFromMessageDTO>(userCreated);
        return Result<CreatedUserFromMessageDTO>.Success(userDTOCreated);
    }
}