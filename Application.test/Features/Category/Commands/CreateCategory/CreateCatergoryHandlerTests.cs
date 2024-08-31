

using Application.Contracts.Persistence;
using Application.Features.Category.Commands.CreateCategory;
using Application.Profiles;
using AutoMapper;
using Moq;

namespace Application.test.Features.Category.Commands.CreateCategory
{

    public class CreateCatergoryHandlerTests
    {
        //Fact นับเป็น 1 case
        //Theory ถ้าต้องเทสหลายๆค่า


        //การตั้งชื่อ เอา method มาตั้งชื่อ
        [Fact]
        public async void Handler_HappyFlow_CatergoryShouldCreated()
        {
            //Arrage คือการเตรียมดาต้า
            var command = new CreateCategoryCommand
            {
                Reqeust = new Models.Category.CreateCategoryRequestDto()
                {
                    Name = "Test Category",
                    UrlHandle = "test-category"
                }
            };

            var token = CancellationToken.None;
            var categoryRepository = new Mock<ICategoryRepository>();
            //Create Data
            categoryRepository.Setup(it => it.CreateAsync(
                                It.IsAny<Domain.Entities.Category>()))
                                .ReturnsAsync(new Domain.Entities.Category
                                {
                                    Name = "Test -22",
                                    UrlHandle = "Test-UrlHandle",
                                    Id = Guid.NewGuid()
                                });

            var mapper = new MapperConfiguration(config => config.AddProfile<CategoryProfile>()).CreateMapper();

            var hanler = new CreateCategoryHandler(categoryRepository.Object, mapper);

            //Act
            var result = await hanler.Handle(command,token);

            //Assert
            Assert.NotNull(result);
        }






    }
}
