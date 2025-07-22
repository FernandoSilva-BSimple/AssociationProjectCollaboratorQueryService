using Application.DTO;
using Application.Interfaces;
using Domain.Messages;
using MassTransit;

namespace WebApi.Consumers;

public class ProjectCreatedConsumer : IConsumer<ProjectCreatedMessage>
{
    private readonly IProjectService _projectService;

    public ProjectCreatedConsumer(IProjectService projectService)
    {
        _projectService = projectService;
    }
    public async Task Consume(ConsumeContext<ProjectCreatedMessage> context)
    {
        var message = context.Message;

        var dto = new CreateProjectFromMessageDTO(message.Id, message.Title, message.Acronym, message.PeriodDate);

        await _projectService.AddConsumedProjectAsync(dto);
    }
}