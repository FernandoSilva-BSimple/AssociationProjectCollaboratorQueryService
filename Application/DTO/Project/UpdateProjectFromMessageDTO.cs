using Domain.Models;

namespace Application.DTO.Project;

public record UpdateProjectFromMessageDTO(Guid Id, string Title, string Acronym, PeriodDate PeriodDate);
