using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAdmin.Domain.DataModels;
using CoreAdmin.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CoreAdmin.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private IAccountRepository _accountRepository;
        private readonly AppSettings _appSettings;

        public AccountController(IAccountRepository accountRepository, IOptions<AppSettings> appSettings)
        {
            _accountRepository = accountRepository;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromBody]User UserDomain)
        {
            //_accountRepository//.User_Create(UserDomain, UserDomain.Password);
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody]User UserDomain)
        {
            //_accountRepository//.User_Create(UserDomain, UserDomain.Password);
            return Ok();
        }
    }
}