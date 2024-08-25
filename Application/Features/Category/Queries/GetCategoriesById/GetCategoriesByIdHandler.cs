using Application.Contracts.Persistence;
using Application.Models.Category;
using AutoMapper;
using MediatR;


namespace Application.Features.Category.Queries.GetCategoriesById
{
    public class GetCategoriesByIdHandler : IRequestHandler<GetCategoriesByIdQuery, CategoryDto>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public GetCategoriesByIdHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoriesByIdQuery command, CancellationToken cancellationToken)
        {
            var _categories = await categoryRepository.GetByIdAsync(command.Id);

            var result = mapper.Map<CategoryDto>(_categories);

            return result;
        }

    }
}
