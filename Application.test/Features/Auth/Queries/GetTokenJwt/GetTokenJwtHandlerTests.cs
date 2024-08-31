using Application.Features.Auth.Queries.GetTokenJwt;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using Moq;

namespace Application.test.Features.Auth.Queries.GetTokenJwt
{
    public class GetTokenJwtHandlerTests
    {
        //1.สร้าง request ที่จะใช้

        [Fact]
        public async Task Handle_InvalidEmail_ShouldReturnsNull()
        {
            //
            //GetTokenJwtQuery request = new()
            //{
            //    Email = "test@gmail.com",
            //    Password = "password"
            //};

            //var user = new IdentityUser
            //{
            //    Email = request.Email,
            //};

            //CancellationToken cancellationToken = CancellationToken.None;

            ////var userManagerMock = new Mock<UserManager<IdentityUser>>();
            //var userStoreMock = new Mock<IUserStore<IdentityUser>>();
            //var userManagerMock = new Mock<UserManager<IdentityUser>>(
            //    userStoreMock.Object, 
            //    default, 
            //    default,
            //    default, 
            //    default, 
            //    default, 
            //    default,
            //    default, 
            //    default
            //    );


            //userManagerMock.Setup(it => it.FindByEmailAsync(request.Email))
            //                    .Returns(Task.FromResult<IdentityUser>(null));

            //var mockConfiguration = new Mock<IConfiguration>();

            //var handler = new GetTokenJwtHandler(userManagerMock.Object,
            //                (Microsoft.Extensions.Configuration.IConfiguration)mockConfiguration.Object);

            //var result = await handler.Handle(request, cancellationToken);
            ////Act

            //Assert.Null(userManagerMock.Object);


            // Arrange
            GetTokenJwtQuery request = new()
            {
                Email = "someone@somewhere.com"
            };
            CancellationToken cancellationToken = CancellationToken.None;
            var userStoreMock = new Mock<IUserStore<IdentityUser>>();
            var mockUserManager = new Mock<UserManager<IdentityUser>>(
                userStoreMock.Object, default, default, default, default, default, default, default, default);
            mockUserManager.Setup(it => it.FindByEmailAsync(request.Email))
                .Returns(Task.FromResult<IdentityUser>(null));
            var mockConfiguration = new Mock<IConfiguration>();

            var handler = new GetTokenJwtHandler(mockUserManager.Object, mockConfiguration.Object);
            // Act
            var result = await handler.Handle(request, cancellationToken);
            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Handle_CorrectEmailInvalidPassword_ShouldReturnsNull()
        {
            // Arrange
            GetTokenJwtQuery request = new()
            {
                Email = "someone@somewhere.com",
                Password = "password"
            };
            var user = new IdentityUser
            {
                Email = request.Email
            };
            CancellationToken cancellationToken = CancellationToken.None;
            var userStoreMock = new Mock<IUserStore<IdentityUser>>();
            var mockUserManager = new Mock<UserManager<IdentityUser>>(
                userStoreMock.Object, default, default, default, default, default, default, default, default);
            mockUserManager.Setup(it => it.FindByEmailAsync(request.Email))
                .Returns(Task.FromResult(user));
            mockUserManager.Setup(it => it.CheckPasswordAsync(user, It.IsAny<string>()))
                .Returns(Task.FromResult(false));
            var mockConfiguration = new Mock<IConfiguration>();

            var handler = new GetTokenJwtHandler(mockUserManager.Object, mockConfiguration.Object);
            // Act
            var result = await handler.Handle(request, cancellationToken);
            // Assert
            Assert.Null(result);

        }

    }
}
