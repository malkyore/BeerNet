using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using BeerNet.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace BeerNet.Controllers
{
    [Produces("application/json")]
    
    public class AccountController : Controller
    {
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        private IConfiguration _configuration;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            var builder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json");
            _configuration = builder.Build();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("BeerNet/Login")]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            var result =  _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (result.Result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.UserName == model.Username);

                if (appUser != null)
                {
                    return Json(GenerateJwtToken(model.Username, appUser));
                }
            }

            this.HttpContext.Response.StatusCode = 401;
            return Json("Invalid Login Attempt");
            //throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("BeerNet/Register")]
        public async Task<object> Register([FromBody] LoginViewModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
      
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Json(GenerateJwtToken(model.Username, user));
            }
      
            throw new ApplicationException("UNKNOWN_ERROR");
        }

        private string GenerateJwtToken(string email, ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JwtKey")));//_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration.GetValue<string>("JwtExpireDays")));//_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration.GetValue<string>("JwtIssuer"),//_configuration["JwtIssuer"],
                _configuration.GetValue<string>("JwtIssuer"),     //_configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}