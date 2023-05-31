﻿using MARShop.Application.Models;
using MARShop.Infastructure.Repositories.AccountRepository;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MARShop.Application.AuthHandler.Commands.TokenCommand
{
    public class TokenCommandResponse
    {
        public string AccessToken { get; set; } = default!;
        public int Role { get; set; } = default!;
        public string UserName { get; set; } = default!;
    }
    public class TokenCommand : IRequest<TokenCommandResponse>
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
    public class TokenCommandHandler : IRequestHandler<TokenCommand, TokenCommandResponse>
    {
        private readonly IConfiguration _config;
        private readonly IAccountRepository _accountRepo;

        public TokenCommandHandler(IConfiguration config, IAccountRepository accountRepo)
        {
            _config = config;
            _accountRepo = accountRepo;
        }

        public async Task<TokenCommandResponse> Handle(TokenCommand request, CancellationToken cancellationToken)
        {
            // Verificamos credenciales con Identity
            var user = await _accountRepo.CheckAuth(request.UserName, request.Password);
            if (user is null)
            {
                throw new Exception();
            }

            // Generamos un token según los claims
            var claims = new List<Claim>{
                new Claim(DClaimType.Id, user.Id.ToString()),
                new Claim(DClaimType.Name, user.UserName),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return new TokenCommandResponse
            {
                AccessToken = jwt,
                Role = user.Role,
                UserName = user.UserName,
            };
        }
    }
}