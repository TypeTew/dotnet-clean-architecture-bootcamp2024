using Application.Models.BlogPosts;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class BlogPostsProfile : Profile
    {
        public BlogPostsProfile()
        {
            CreateMap<BlogPost, BlogPostDto>();
            // ให้ CreateBlogPostRequestDto สามารถ map กลับไป BlogPost
            CreateMap<CreateBlogPostRequestDto, BlogPost>()
               .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => new List<Category>()));


        }
    }
}
