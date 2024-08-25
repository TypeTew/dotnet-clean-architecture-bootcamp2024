using Application.Models.Auth;
using MediatR;


namespace Application.Features.Register.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<bool>
    {
        public RegisterRequestDto RegisterModel { get; set; }
    }
}
