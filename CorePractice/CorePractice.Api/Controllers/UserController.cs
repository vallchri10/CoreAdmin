using Microsoft.AspNetCore.Mvc;
using CorePractice.Domain.Models;
using CorePractice.Data.DataServices.Abstract;
using Microsoft.AspNetCore.Authorization;
using CorePractice.Data.DataSources;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using Microsoft.Extensions.Options;

namespace CorePractice.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;

        }



        private readonly AppSettings _appSettings;




        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult User_Register([FromBody]User UserDomain)
        {
            _userService.User_Create(UserDomain, UserDomain.Password);
            return Ok(); 
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User UserDomain)
        {
            var user = _userService.Authenticate(UserDomain.Username, UserDomain.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.UserID,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }
















        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _userService.GetAll(); 
        }


        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }




    }
}