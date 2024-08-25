using Application.Contracts.Persistence;
using Application.Features.Category.Queries.GetCategoriesById;
using Application.Models.BlogPosts;
using AutoMapper;
using MediatR;


namespace Application.Features.BlogPosts.Queries.GetCategoriesById
{
    public class GetBlogPostByIdHandler : IRequestHandler<GetBlogPostByIdQuery, BlogPostDto>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IMapper mapper;

        public GetBlogPostByIdHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            this.blogPostRepository = blogPostRepository;
            this.mapper = mapper;
        }

        public async Task<BlogPostDto> Handle(GetBlogPostByIdQuery command, CancellationToken cancellationToken)
        {
            var _blogPost = await blogPostRepository.GetByIdAsync(command.Id);
            var result = mapper.Map<BlogPostDto>(_blogPost);

            return result;
        }
    }
}
