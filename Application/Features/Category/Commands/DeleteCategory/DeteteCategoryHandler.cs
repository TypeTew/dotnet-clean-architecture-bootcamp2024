

using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.DeleteCategory
{
    public class DeteteCategoryHandler : IRequestHandler<DeteteCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public DeteteCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<CategoryDto> Handle(DeteteCategoryCommand command, CancellationToken cancellationToken)
        {

            //Delete Category
            var result = await categoryRepository.DeleteAsync(command.Id);
            //
            return mapper.Map<CategoryDto>(result); // map category to Categorydto

        }
    }
}
