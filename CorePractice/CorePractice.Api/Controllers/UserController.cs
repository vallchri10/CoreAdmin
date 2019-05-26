using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using Microsoft.Extensions.Options;

using CorePractice.Domain.DataModels;
using CorePractice.Data.DataServices.Abstract;

namespace CorePractice.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;
        private readonly AppSettings _appSettings;

        public UserController(IUserService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult User_Register([FromBody]User UserDomain)
        {
            _userService.User_Create(UserDomain, UserDomain.Password);
            return Ok(); 
        }

        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public IEnumerable<User> Users_Read()
        {
            return _userService.Users_Read(); 
        }

        [HttpGet("{id}")]
        public IActionResult User_Read(string id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }
    }
}