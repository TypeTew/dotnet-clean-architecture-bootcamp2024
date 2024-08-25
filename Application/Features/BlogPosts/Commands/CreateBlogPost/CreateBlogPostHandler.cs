using Application.Contracts.Persistence;
using Application.Models.BlogPosts;
using AutoMapper;
using MediatR;


namespace Application.Features.BlogPosts.Commands.CreateBlogPost
{
    public class CreateBlogPostHandler : IRequestHandler<CreateBlogPostCommand, BlogPostDto>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CreateBlogPostHandler(
            IBlogPostRepository blogPostRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            this.blogPostRepository = blogPostRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<BlogPostDto> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
        {
            var blogPost = mapper.Map<Domain.Entities.BlogPost>(request.Reqeust);

            //list Categories
            foreach (var categoryId in request.Reqeust.Categories)
            {
                var category = await categoryRepository.GetByIdAsync(categoryId);
                if (category is not null)
                {
                    blogPost.Categories.Add(category);
                }

            }

            //save BlogPost
            var result = await blogPostRepository.CreateAsync(blogPost);
            //
            return mapper.Map<BlogPostDto>(result); // map BlogPos to BlogPostDto


        }

    }
}
