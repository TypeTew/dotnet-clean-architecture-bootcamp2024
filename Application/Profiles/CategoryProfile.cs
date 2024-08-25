using Application.Models.Category;
using AutoMapper;
using Domain.Entities;


namespace Application.Profiles
{
    public class CategoryProfile : Profile {
        public CategoryProfile() {
            CreateMap<Category, CategoryDto>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id));
            // ให้ CreateCategoryRequesrDto สามารถ map กลับไป Category
            CreateMap<CreateCategoryRequestDto, Category>();
            // ให้ UpdateCategoryRequesrDto สามารถ map กลับไป Category
            CreateMap<UpdateCategoryRequestDto, Category>();
            // ให้ DeleteCategoryRequestDto สามารถ map กลับไป Category
            CreateMap<DeleteCategoryRequestDto, Category>();

        }
    }
}
