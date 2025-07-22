using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AssociationDbContext : DbContext
{
    public AssociationDbContext(DbContextOptions<AssociationDbContext> options)
        : base(options) { }

    public DbSet<AssociationProjectCollaboratorDataModel> Associations => Set<AssociationProjectCollaboratorDataModel>();
    public DbSet<ProjectDataModel> Projects => Set<ProjectDataModel>();
    public DbSet<CollaboratorDataModel> Collaborators => Set<CollaboratorDataModel>();
    public DbSet<UserDataModel> Users => Set<UserDataModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssociationProjectCollaboratorDataModel>()
            .OwnsOne(a => a.PeriodDate);

        modelBuilder.Entity<ProjectDataModel>()
            .OwnsOne(p => p.PeriodDate);

        modelBuilder.Entity<CollaboratorDataModel>()
            .OwnsOne(c => c.PeriodDateTime);

        base.OnModelCreating(modelBuilder);
    }
}
