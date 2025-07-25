using Application.DTO.Project;
using Application.Interfaces;
using Domain.Messages;
using MassTransit;

namespace WebApi.Consumers;

public class ProjectUpdatedConsumer : IConsumer<ProjectUpdatedMessage>
{
    private readonly IProjectService _projectService;

    public ProjectUpdatedConsumer(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task Consume(ConsumeContext<ProjectUpdatedMessage> context)
    {
        var message = context.Message;

        var dto = new UpdateProjectFromMessageDTO(
            message.Id,
            message.Title,
            message.Acronym,
            message.PeriodDate
        );

        await _projectService.UpdateConsumedProjectAsync(dto);
    }
}
