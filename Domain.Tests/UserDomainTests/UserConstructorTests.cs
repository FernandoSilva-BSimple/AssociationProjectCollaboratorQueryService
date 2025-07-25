using Domain.Models;
using Moq;

namespace Domain.Tests.ProjectDomainTests;

public class UserConstructorTests
{

    [Fact]
    public void WhenCreatingUserWithId_ThenUserIsCreated()
    {
        //arrange
        Guid id = Guid.NewGuid();

        //act & assert
        new User(id, It.IsAny<string>(), It.IsAny<string>());

    }
}