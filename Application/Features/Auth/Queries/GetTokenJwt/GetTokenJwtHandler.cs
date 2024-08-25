using Application.Contracts.Persistence;
using Application.Features.BlogPosts.Queries.GetAllBlogPosts;
using Application.Models.BlogPosts;
using Application.Models.Register;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Queries.GetTokenJwt
{
    public class GetTokenJwtHandler : IRequestHandler<GetTokenJwtQuery,LoginResponseDto>
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        public GetTokenJwtHandler(UserManager<IdentityUser> userManager , IConfiguration configuration) 
        { 
            this.userManager = userManager;
            this.configuration = configuration;
        }


        public async Task<LoginResponseDto> Handle(GetTokenJwtQuery request, CancellationToken cancellationToken)
        {

            var identityUser = await userManager.FindByEmailAsync(request.Email);
            if (identityUser is null) {
                return null;
            }

            var checkPasswordResult = await userManager.CheckPasswordAsync(identityUser, request.Password);
            if(checkPasswordResult is false)
            {
                return null;
            }

            var roles = await userManager.GetRolesAsync(identityUser);

            var token = await GenerateJwtToken(identityUser, roles);

            var response = new LoginResponseDto
            {
                Email = request.Email,
                Roles = roles.ToList(),
                Token = token
            };

            return response;
        }

        public async Task<string> GenerateJwtToken(IdentityUser identityUser, IList<string> role)
        {
            var claims = new List<Claim> { 
                new Claim(ClaimTypes.Email,identityUser.Email)
            };


            claims.AddRange(role.Select(role => new Claim(ClaimTypes.Role,role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
