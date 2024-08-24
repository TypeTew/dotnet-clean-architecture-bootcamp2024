using Application.Contracts.Persistence;
using Application.Features.Category.Queries.GetAllCategories;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
