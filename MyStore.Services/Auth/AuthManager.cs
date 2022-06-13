using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MyStore.Data;
using MyStore.Services;
using MyStore.Entities;
using System.Threading.Tasks;
using MyStore.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;

namespace MyStore.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApiUser _user;

        public AuthManager(UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
           var jwtSettings = _configuration.GetSection("Jwt");
           var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("lifetime").Value));
           var token = new JwtSecurityToken(
                    issuer: jwtSettings.GetSection("validIssuer").Value,
                    claims: claims,
                    expires: expiration,
                    signingCredentials: signingCredentials
                );
            return token;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Environment.GetEnvironmentVariable("KEY"); ;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            return new SigningCredentials(secret,SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            { 
                new Claim(ClaimTypes.Name, _user.UserName)            
            };

            var roles = await _userManager.GetRolesAsync(_user);
            
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;

        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<bool> ValidateUser(LoginUserModel loginUserModel)
        {
            _user = await _userManager.FindByNameAsync(loginUserModel.Email);
            return (_user != null && await _userManager.CheckPasswordAsync(_user, loginUserModel.Password));
        }
    }
}
