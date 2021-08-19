
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using PCode.DTO;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PCode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly PCode.Service.IAuthenticationService _authService;
        private readonly IConfiguration _configuration;
        public AuthenticationController(PCode.Service.IAuthenticationService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticationDTO request)
        {
            var account = await _authService.Get(request.UserName, request.Password);

            if (account == null)
                return Unauthorized(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = this.BuildUserToken(account);

            var token = tokenHandler.CreateToken(tokenDescriptor);


            //add generic response later.
            return Ok(new
            {
                Token = tokenHandler.WriteToken(token),
                UserName = account.UserName
            });
        }


        private SecurityTokenDescriptor BuildUserToken(AuthenticationDTO user)
        {
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("UserName", user.UserName)
                }),
                Expires = DateTime.Now.AddDays(7),
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:Jwt:Key"])), SecurityAlgorithms.HmacSha256Signature)
            };
        }
    }
}
