using Application.Models.Category;
using MediatR;


namespace Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<CategoryDto>
    {
        public UpdateCategoryRequestDto Reqeust { get; set; }
        public Guid Id { get; set; }

    }
}
