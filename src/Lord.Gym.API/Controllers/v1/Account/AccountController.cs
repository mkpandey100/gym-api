using AutoMapper;
using Lord.Core.API.Controllers;
using Lord.Gym.Application.Interfaces;
using Lord.Gym.Application.Models;
using Lord.Gym.Domain.Entities.Auth;
using Lord.Gym.Infrastructure.Authentication;
using Lord.Gym.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lord.Gym.API.Controllers.v1.Account
{
    [Route("api/v1/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IdentitySettings _appSettings;

        public AccountController(IUserService userService, IMapper mapper, IOptions<IdentitySettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterDto registerUser)
        {
            var user = new AppUser
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email,
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName
            };
            try
            {
                _userService.Create(user, registerUser.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDto loginUser)
        {
            try
            {
                var user = _userService.Authenticate(loginUser.Username, loginUser.Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                // return basic user info and authentication token
                return Ok(new
                {
                    Id = user.Id,
                    Username = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Token = tokenString
                });
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [ServiceFilter(typeof(ApiKeyAuthFilter))]
        public IActionResult GetAll()
        {
            try
            {
               return Ok();
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}