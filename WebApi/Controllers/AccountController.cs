using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticatedUserModel>> Login (LoginUserModel loginUser )
        {
            var user = await _userManager.FindByEmailAsync(loginUser.Email);

            if (user == null) 
                return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginUser.Password, false);

            if(result.Succeeded)
            {
                return new AuthenticatedUserModel
                {
                    Token = _tokenService.CreateToken(user),
                    UserName = user.UserName
                };
            }

            return Unauthorized();
        }

        [HttpPost("Register")]
        public async Task<ActionResult<AuthenticatedUserModel>> Register (RegisterUserModel registerUser)
        {
            if(await _userManager.Users.AnyAsync(x => x.Email == registerUser.Email))
            {
                return BadRequest("Email taken");
            }

            if (await _userManager.Users.AnyAsync(x => x.UserName == registerUser.UserName))
            {
                return BadRequest("Username taken");
            }

            var user = new AppUser
            {
                Email = registerUser.Email,
                UserName = registerUser.UserName
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                return new AuthenticatedUserModel
                { 
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
                };

            }

            return BadRequest("Problem registering user");
        }
    }
}
