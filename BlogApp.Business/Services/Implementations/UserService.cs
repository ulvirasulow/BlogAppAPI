using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Business.DTOs.User;
using BlogApp.Business.Helpers.Exceptions.UserExceptions;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BlogApp.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;
        readonly IMapper _mapper;
        public UserService(UserManager<AppUser> userManager, IMapper mapper, IConfiguration config)
        {
            _userManager = userManager;
            _mapper = mapper;
            _config = config;
        }
        public async Task Register(RegisterDto dto)
        {
            if (await _userManager.FindByEmailAsync(dto.Email) != null)
            {
                throw new UserRegisterException("Bele bir email istifade olunur! Soxus gelme!");
            }

            var appUser = _mapper.Map<AppUser>(dto);

            var result = await _userManager.CreateAsync(appUser, dto.Password);

            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    sb.Append(error.Description + " ");
                }
                throw new UserRegisterException(sb.ToString());
            }
        }

        public async Task<string> Login(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);

            if (user == null) throw new UserLoginFailedException();

            var result = await _userManager.CheckPasswordAsync(user, dto.Password);

            if(!result) throw new UserLoginFailedException();

            var _claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            SecurityKey key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecurityKey"]));
            SigningCredentials _signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtToken = new JwtSecurityToken(
                audience: _config["Jwt:Audience"],
                issuer: _config["Jwt:Issuer"],
                claims:_claims,
                signingCredentials:_signingCredentials,
                expires:DateTime.UtcNow.AddMinutes(60)
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return token;
        }

    }
}
