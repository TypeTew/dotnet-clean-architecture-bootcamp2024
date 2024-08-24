using Application.Models;
using MediatR;


namespace Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public CreateCategoryRequesrDto Reqeust { get; set; }
    }
}
