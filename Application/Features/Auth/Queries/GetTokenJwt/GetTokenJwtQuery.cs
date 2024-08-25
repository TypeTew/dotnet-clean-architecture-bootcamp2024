

using Application.Models.Register;
using MediatR;

namespace Application.Features.Auth.Queries.GetTokenJwt
{
    public class GetTokenJwtQuery : IRequest<LoginResponseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
