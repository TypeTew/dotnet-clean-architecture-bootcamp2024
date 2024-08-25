using Application.Models.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.DeleteCategory
{
    public class DeteteCategoryCommand : IRequest<CategoryDto>
    {
        public Guid Id { get; set; }
    }
}
