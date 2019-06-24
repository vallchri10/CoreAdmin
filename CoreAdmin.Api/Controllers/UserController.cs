using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

using CoreAdmin.Domain.DataModels;
using CoreAdmin.Repository.Abstract;

namespace CoreAdmin.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        private readonly AppSettings _appSettings;

        public UserController(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult User_Register([FromBody]User UserDomain)
        {
            _userRepository.User_Create(UserDomain, UserDomain.Password);
            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public IEnumerable<User> Users_Read()
        {
            return _userRepository.Users_Read();
        }

        [HttpGet("{id}")]
        public IActionResult User_Read(string id)
        {
            var user = _userRepository.GetById(id);
            return Ok(user);
        }
    }
}