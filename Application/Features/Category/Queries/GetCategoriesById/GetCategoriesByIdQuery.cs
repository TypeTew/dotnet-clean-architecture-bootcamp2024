using Application.Models;
using MediatR;


namespace Application.Features.Category.Queries.GetCategoriesById
{
    public class GetCategoriesByIdQuery : IRequest<CategoryDto>
    {
        public Guid Id { get; set; }
    }
}
