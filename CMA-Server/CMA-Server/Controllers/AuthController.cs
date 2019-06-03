using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CMA.Db.Models;
using CMA.DTO.RequestModels;
using CMA.DTO.ViewModels;
using CMA.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CMA_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthController(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            registerUser.Email = registerUser.Email.ToLower();

            if (await _userRepository.IsUserExists(registerUser.Email))
                return BadRequest("User already exists");

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Email = registerUser.Email,
                Name = registerUser.Name,
                Address = registerUser.Address,
                RequestFrom = registerUser.RequestFrom,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System",
                ModifiedAt = DateTime.UtcNow,
                ModifiedBy = "System"
            };

            var createdUser = await _userRepository.Register(newUser, registerUser.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            var sUser = await _userRepository.Login(loginUser.Username.ToLower(), loginUser.Password);

            if (sUser == null)
                return Unauthorized();

            await _userRepository.UpdateUserLastLoggedIn(sUser);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, sUser.Id.ToString()),
                new Claim(ClaimTypes.Name, sUser.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var userToken = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new ValidUser {
                Id = sUser.Id.ToString(),
                Name = sUser.Name,
                Token = tokenHandler.WriteToken(userToken)
            });
        }
    }
}