using Domain.Interfaces;

namespace Domain.Models;

public class Collaborator : ICollaborator
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public PeriodDateTime PeriodDateTime { get; set; }

    public Collaborator(Guid id, Guid userId, PeriodDateTime periodDateTime)
    {
        Id = id;
        UserId = userId;
        PeriodDateTime = periodDateTime;
    }

}