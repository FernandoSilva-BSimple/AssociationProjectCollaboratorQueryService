using Domain.Models;

namespace Application.DTO;

public class AssociationProjectCollaboratorDetailsDTO
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    public Guid CollaboratorId { get; set; }
    public PeriodDate PeriodDate { get; set; }
    public string CollaboratorName { get; set; }
    public string CollaboratorEmail { get; set; }
    public string ProjectTitle { get; set; }
    public string ProjectAcronym { get; set; }

    public AssociationProjectCollaboratorDetailsDTO(Guid id, Guid projectId, Guid collaboratorId, PeriodDate periodDate, string collaboratorName, string collaboratorEmail, string projectTitle, string projectAcronym)
    {
        Id = id;
        ProjectId = projectId;
        CollaboratorId = collaboratorId;
        PeriodDate = periodDate;
        CollaboratorName = collaboratorName;
        CollaboratorEmail = collaboratorEmail;
        ProjectTitle = projectTitle;
        ProjectAcronym = projectAcronym;
    }

    public AssociationProjectCollaboratorDetailsDTO() { }
}