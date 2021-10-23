using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIWithIdentityAndJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] User model)
        {
            var user = _userService.Authenticate(model.Email,model.Password);
            if (user == null) return BadRequest();

            var token = JwtGenerator.Generate(user, _configuration["Jwt:Key"], _configuration["Jwt:Issuer"]);
            return Ok(token);
        }


    }
}
