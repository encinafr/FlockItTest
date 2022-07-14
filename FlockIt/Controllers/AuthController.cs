using FlockIt.Dtos;
using FlockIt.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlockIt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(ILogger<AuthController> logger, IUserService userService, ITokenService tokenService)
        {
            _logger = logger;
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userService.Get(loginDto.Username);

            if (user == null) return Unauthorized("Invalid username");

            if (user.Password != loginDto.Password) return Unauthorized("Invalid password");

            return new UserDto
            {
                Username = user.Name,
                Token = await _tokenService.CreateToken(user),
            };
        }
    }
}
