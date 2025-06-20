using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AssociationDbContext : DbContext
{
    public AssociationDbContext(DbContextOptions<AssociationDbContext> options)
        : base(options) { }

    public DbSet<AssociationProjectCollaboratorDataModel> Associations => Set<AssociationProjectCollaboratorDataModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssociationProjectCollaboratorDataModel>()
            .OwnsOne(a => a.PeriodDate);

        base.OnModelCreating(modelBuilder);
    }
}
