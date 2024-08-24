using Application.Models;
using MediatR;


namespace Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public CreateCategoryRequestDto Reqeust { get; set; }
    }
}
