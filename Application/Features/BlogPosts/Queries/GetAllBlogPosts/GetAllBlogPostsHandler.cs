using Application.Contracts.Persistence;
using Application.Models.BlogPosts;
using AutoMapper;
using MediatR;


namespace Application.Features.BlogPosts.Queries.GetAllBlogPosts
{
    public class GetAllBlogPostsHandler : IRequestHandler<GetAllBlogPostsQuery, List<BlogPostDto>>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public GetAllBlogPostsHandler(
            IBlogPostRepository blogPostRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            this.blogPostRepository = blogPostRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<List<BlogPostDto>> Handle(GetAllBlogPostsQuery request, CancellationToken cancellationToken)
        {
            var _blogPosts = await blogPostRepository.GetAllBlogPosts();

            // automap
            var result = mapper.Map<List<BlogPostDto>>(_blogPosts);

            return result;
        }

    }
}