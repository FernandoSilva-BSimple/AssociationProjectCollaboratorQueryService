using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public class AssociationFactory : IDesignTimeDbContextFactory<AssociationDbContext>
{
    public AssociationDbContext CreateDbContext(string[] args)
    {
        // Path to your WebApi project folder (where appsettings.json lives)
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../WebApi");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<AssociationDbContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

        return new AssociationDbContext(optionsBuilder.Options);
    }
}
