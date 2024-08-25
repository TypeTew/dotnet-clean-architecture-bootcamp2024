using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace Application.Features.Register.Commands.CreateAccount
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, bool>
    {
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;

        public CreateAccountHandler(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<bool> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = new IdentityUser
            {
                UserName = request.RegisterModel.Email.Trim(),
                Email = request.RegisterModel.Email.Trim(),
            };

            var identityResult = await userManager.CreateAsync(user, request.RegisterModel.Password);
            if (identityResult.Succeeded is false)
            {
                return false;
            }

            identityResult = await userManager.AddToRolesAsync(user, ["Reader", "Writer"]);
            if (identityResult.Succeeded is false)
            {
                return false;
            }

            return true;

        }

    }
}
