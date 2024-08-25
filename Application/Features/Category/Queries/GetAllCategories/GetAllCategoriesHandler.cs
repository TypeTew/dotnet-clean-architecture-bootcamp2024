using Application.Contracts.Persistence;
using Application.Models.Category;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {

        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public GetAllCategoriesHandler(ICategoryRepository categoryRepository,IMapper mapper) 
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request , CancellationToken cancellationToken)
        {
            var _categories = await categoryRepository.GetAllCategories();
            
            // automap
            var result = mapper.Map<List<CategoryDto>>(_categories);

            return result;
        }

    }
}
