using Application.Contracts.Persistence;
using Application.Models.Category;
using AutoMapper;
using MediatR;


namespace Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<CategoryDto> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {

            var categoryUpdateModel = mapper.Map<Domain.Entities.Category>(command.Reqeust);
            categoryUpdateModel.Id = command.Id;
            //Update Category
            var result = await categoryRepository.UpdateAsync(categoryUpdateModel);
            //
            return mapper.Map<CategoryDto>(result); // map category to Categorydto

        }

    }
}
