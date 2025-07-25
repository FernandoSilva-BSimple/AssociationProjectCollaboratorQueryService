using Domain.Factory;
using Domain.Factory.ProjectFactory;
using Domain.Factory.UserFactory;
using Domain.Models;
using Domain.Visitor;
using Domain.Visitors;
using Moq;

namespace Domain.Tests.ProjectDomainTests;

public class UserFactoryTests
{

    [Fact]
    public void WhenCreatingUser_ThenUserIsCreated()
    {
        //arrange
        var userFactory = new UserFactory();

        //act
        var user = userFactory.Create(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>());

        //assert
        Assert.NotNull(user);
    }

    [Fact]
    public void WhenCreatingUserFromVisitor_ThenUserIsCreated()
    {
        //arrange
        var userFactory = new UserFactory();
        var userVisitor = new Mock<IUserVisitor>();

        //act
        var user = userFactory.Create(userVisitor.Object);

        //assert
        Assert.NotNull(user);
    }
}