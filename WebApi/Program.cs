using Application.Interfaces;
using Application.Services;
using Domain.Factory;
using Domain.Factory.CollaboratorFactory;
using Domain.Factory.ProjectFactory;
using Domain.Factory.UserFactory;
using Domain.IRepository;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using InterfaceAdapters.Consumers;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using WebApi.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// DB Context
builder.Services.AddDbContext<AssociationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<ICollaboratorService, CollaboratorService>();
builder.Services.AddTransient<IAssociationProjectCollaboratorService, AssociationProjectCollaboratorService>();

// Repositories
builder.Services.AddTransient<IAssociationProjectCollaboratorRepository, AssociationProjectCollaboratorRepositoryEF>();
builder.Services.AddTransient<IUserRepository, UserRepositoryEF>();
builder.Services.AddTransient<IProjectRepository, ProjectRepositoryEF>();
builder.Services.AddTransient<ICollaboratorRepository, CollaboratorRepositoryEF>();

// AutoMapper
builder.Services.AddAutoMapper(
    typeof(Infrastructure.DataModelMappingProfile),
    typeof(Application.ApplicationMappingProfile)
);
builder.Services.AddTransient<IAssociationProjectCollaboratorFactory, AssociationProjectCollaboratorFactory>();
builder.Services.AddTransient<IUserFactory, UserFactory>();
builder.Services.AddTransient<IProjectFactory, ProjectFactory>();
builder.Services.AddTransient<ICollaboratorFactory, CollaboratorFactory>();


// MassTransit - Only the consumer
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<AssociationProjectCollaboratorCreatedConsumer>();
    x.AddConsumer<ProjectCreatedConsumer>();
    x.AddConsumer<CollaboratorCreatedConsumer>();
    x.AddConsumer<UserCreatedConsumer>();


    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost");
        cfg.ConfigureEndpoints(context);
    });
});

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(host => true)
    .AllowCredentials());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }
