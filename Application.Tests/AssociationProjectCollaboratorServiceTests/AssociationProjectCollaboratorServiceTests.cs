using Application;
using Application.DTO;
using AutoMapper;
using Domain.Factory;
using Domain.Interfaces;
using Domain.IRepository;
using Domain.Models;
using Moq;
using Xunit;

public class AssociationProjectCollaboratorServiceTests
{
    private readonly Mock<IAssociationProjectCollaboratorRepository> _assocRepo = new();
    private readonly Mock<IAssociationProjectCollaboratorFactory> _factory = new();
    private readonly Mock<IProjectRepository> _projectRepo = new();
    private readonly Mock<ICollaboratorRepository> _collabRepo = new();
    private readonly Mock<IUserRepository> _userRepo = new();
    private readonly Mock<IMapper> _mapper = new();

    private readonly AssociationProjectCollaboratorService _service;

    public AssociationProjectCollaboratorServiceTests()
    {
        _service = new AssociationProjectCollaboratorService(
            _assocRepo.Object,
            _factory.Object,
            _collabRepo.Object,
            _projectRepo.Object,
            _userRepo.Object,
            _mapper.Object);
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsSuccess_WhenFound()
    {
        var id = Guid.NewGuid();
        var domainModel = Mock.Of<IAssociationProjectCollaborator>(a => a.Id == id);
        var dto = new AssociationProjectCollaboratorDTO { Id = id };

        _assocRepo.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(domainModel);
        _mapper.Setup(m => m.Map<AssociationProjectCollaboratorDTO>(domainModel)).Returns(dto);

        var result = await _service.GetByIdAsync(id);

        Assert.True(result.IsSuccess);
        Assert.Equal(id, result.Value.Id);
    }

    [Fact]
    public async Task AddConsumedAssociationProjectCollaboratorAsync_CreatesAndReturnsDTO()
    {
        var dto = new CreateAssociationProjectCollaboratorFromMessageDTO(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), new PeriodDate(new DateOnly(2024, 1, 1), new DateOnly(2024, 12, 31)));
        var entity = Mock.Of<IAssociationProjectCollaborator>();
        var created = Mock.Of<IAssociationProjectCollaborator>();
        var resultDTO = new CreatedAssociationProjectCollaboratorFromMessageDTO(dto.Id, dto.ProjectId, dto.CollaboratorId, dto.PeriodDate);

        _factory.Setup(f => f.Create(dto.Id, dto.ProjectId, dto.CollaboratorId, dto.PeriodDate)).Returns(entity);
        _assocRepo.Setup(r => r.AddAsync(entity)).ReturnsAsync(created);
        _mapper.Setup(m => m.Map<CreatedAssociationProjectCollaboratorFromMessageDTO>(created)).Returns(resultDTO);

        var result = await _service.AddConsumedAssociationProjectCollaboratorAsync(dto);

        Assert.True(result.IsSuccess);
        Assert.Equal(dto.Id, result.Value.Id);
    }

    [Fact]
    public async Task GetAssociationDetailsAsync_ReturnsDetails_WhenFound()
    {
        var assocId = Guid.NewGuid();
        var projectId = Guid.NewGuid();
        var collabId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var period = new PeriodDate(new DateOnly(2024, 1, 1), new DateOnly(2024, 12, 31));

        var assoc = Mock.Of<IAssociationProjectCollaborator>(a => a.Id == assocId && a.ProjectId == projectId && a.CollaboratorId == collabId && a.PeriodDate == period);
        var collab = Mock.Of<ICollaborator>(c => c.Id == collabId && c.UserId == userId);
        var project = Mock.Of<IProject>(p => p.Id == projectId && p.Title == "Proj" && p.Acronym == "P1");
        var user = Mock.Of<IUser>(u => u.Id == userId && u.Names == "User" && u.Email == "email@test.com");

        _assocRepo.Setup(r => r.GetByIdAsync(assocId)).ReturnsAsync(assoc);
        _collabRepo.Setup(r => r.GetByIdAsync(collabId)).ReturnsAsync(collab);
        _projectRepo.Setup(r => r.GetByIdAsync(projectId)).ReturnsAsync(project);
        _userRepo.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(user);

        var result = await _service.GetAssociationDetailsAsync(assocId);

        Assert.True(result.IsSuccess);
        Assert.Equal(assocId, result.Value.Id);
        Assert.Equal("User", result.Value.CollaboratorName);
    }

    [Fact]
    public async Task GetAllWithDetailsByCollaboratorIdAsync_ReturnsAssociations()
    {
        var collabId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var projectId = Guid.NewGuid();
        var period = new PeriodDate(new DateOnly(2024, 1, 1), new DateOnly(2024, 12, 31));

        var assoc = Mock.Of<IAssociationProjectCollaborator>(a =>
            a.Id == Guid.NewGuid() &&
            a.CollaboratorId == collabId &&
            a.ProjectId == projectId &&
            a.PeriodDate == period);

        var collab = Mock.Of<ICollaborator>(c => c.Id == collabId && c.UserId == userId);
        var project = Mock.Of<IProject>(p =>
            p.Id == projectId &&
            p.Title == "P" &&
            p.Acronym == "PX"
        );
        var user = Mock.Of<IUser>(u =>
                    u.Id == userId &&
                    u.Names == "N" &&
                    u.Email == "E"
                );
        _assocRepo.Setup(r => r.FindAllByCollaboratorAsync(collabId)).ReturnsAsync(new List<IAssociationProjectCollaborator> { assoc });
        _collabRepo.Setup(r => r.GetByIdAsync(collabId)).ReturnsAsync(collab);
        _projectRepo.Setup(r => r.GetByIdAsync(projectId)).ReturnsAsync(project);
        _userRepo.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(user);

        var result = await _service.GetAllWithDetailsByCollaboratorIdAsync(collabId);

        Assert.True(result.IsSuccess);
        Assert.Single(result.Value);
        Assert.Equal(collabId, result.Value.First().CollaboratorId);
    }

    [Fact]
    public async Task GetAllWithDetailsByProjectIdAsync_ReturnsAssociations()
    {
        var collabId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var projectId = Guid.NewGuid();
        var period = new PeriodDate(new DateOnly(2024, 1, 1), new DateOnly(2024, 12, 31));

        var assoc = Mock.Of<IAssociationProjectCollaborator>(a =>
            a.Id == Guid.NewGuid() &&
            a.CollaboratorId == collabId &&
            a.ProjectId == projectId &&
            a.PeriodDate == period);

        var collab = Mock.Of<ICollaborator>(c => c.Id == collabId && c.UserId == userId);
        var project = Mock.Of<IProject>(p =>
                    p.Id == projectId &&
                    p.Title == "P" &&
                    p.Acronym == "PX"
                );
        var user = Mock.Of<IUser>(u =>
                           u.Id == userId &&
                           u.Names == "N" &&
                           u.Email == "E"
                       );
        _assocRepo.Setup(r => r.FindAllByProjectAsync(projectId)).ReturnsAsync(new List<IAssociationProjectCollaborator> { assoc });
        _collabRepo.Setup(r => r.GetByIdAsync(collabId)).ReturnsAsync(collab);
        _projectRepo.Setup(r => r.GetByIdAsync(projectId)).ReturnsAsync(project);
        _userRepo.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync(user);

        var result = await _service.GetAllWithDetailsByProjectIdAsync(projectId);

        Assert.True(result.IsSuccess);
        Assert.Single(result.Value);
        Assert.Equal(projectId, result.Value.First().ProjectId);
    }
}
