using Domain.Interfaces;
using Infrastructure.DataModel;
using Infrastructure.Repositories;
using Moq;
using Xunit;

namespace Infrastructure.Tests.UserRepositoryTests;

public class UserRepositoryUpdateAsyncTests : RepositoryTestBase
{
    [Fact]
    public async Task WhenUpdatingUser_ThenDataIsUpdated()
    {
        // Arrange
        var id = Guid.NewGuid();
        var originalName = "João Original";
        var originalEmail = "joao@original.com";

        var updatedName = "João Atualizado";
        var updatedEmail = "joao@novo.com";

        var originalDM = new UserDataModel
        {
            Id = id,
            Names = originalName,
            Email = originalEmail
        };

        context.Users.Add(originalDM);
        await context.SaveChangesAsync();

        // Mock de IUser com dados atualizados
        var userMock = new Mock<IUser>();
        userMock.Setup(u => u.Id).Returns(id);
        userMock.Setup(u => u.Names).Returns(updatedName);
        userMock.Setup(u => u.Email).Returns(updatedEmail);

        var repository = new UserRepositoryEF(context, null!);

        // Act
        await repository.UpdateAsync(userMock.Object);

        // Assert
        var updated = await context.Users.FindAsync(id);
        Assert.NotNull(updated);
        Assert.Equal(updatedName, updated!.Names);
        Assert.Equal(updatedEmail, updated.Email);
    }
}
