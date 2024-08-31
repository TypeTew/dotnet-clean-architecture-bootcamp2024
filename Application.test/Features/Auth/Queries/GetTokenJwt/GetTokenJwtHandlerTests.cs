using Application.Features.Auth.Queries.GetTokenJwt;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Identity;
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
            GetTokenJwtQuery request = new()
            {
                Email = "test@gmail.com",
                Password = "password"
            };

            var user = new IdentityUser
            {
                Email = request.Email,
            };

            CancellationToken cancellationToken = CancellationToken.None;

            //var userManagerMock = new Mock<UserManager<IdentityUser>>();
            var userStoreMock = new Mock<IUserStore<IdentityUser>>();
            var userManagerMock = new Mock<UserManager<IdentityUser>>(
                userStoreMock.Object, 
                default, 
                default,
                default, 
                default, 
                default, 
                default,
                default, 
                default
                );


            userManagerMock.Setup(it => it.FindByEmailAsync(request.Email))
                                .Returns(Task.FromResult<IdentityUser>(null));

            var mockConfiguration = new Mock<IConfiguration>();

            var handler = new GetTokenJwtHandler(userManagerMock.Object,
                            (Microsoft.Extensions.Configuration.IConfiguration)mockConfiguration.Object);

            var result = await handler.Handle(request, cancellationToken);
            //Act

            Assert.Null(userManagerMock.Object);
        }
    }
}
