using Application.Contracts.Persistence;
using Application.Models.Category;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CreateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {

            var categoryModel = mapper.Map<Domain.Entities.Category>(command.Reqeust);
            //Save Category
            var result = await categoryRepository.CreateAsync(categoryModel);
            //
            return mapper.Map<CategoryDto>(result); // map category to Categorydto

        }
    }
}
