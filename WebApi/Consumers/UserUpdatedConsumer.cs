using Application.DTO.User;
using Application.Interfaces;
using Domain.Messages;
using MassTransit;

public class UserUpdatedConsumer : IConsumer<UserUpdatedMessage>
{
    private readonly IUserService _userService;

    public UserUpdatedConsumer(IUserService userService)
    {
        _userService = userService;
    }

    public async Task Consume(ConsumeContext<UserUpdatedMessage> context)
    {
        var message = context.Message;

        var dto = new UpdateUserFromMessageDTO(message.Id, message.Names, message.Email);
        await _userService.UpdateConsumedUserAsync(dto);
    }
}
