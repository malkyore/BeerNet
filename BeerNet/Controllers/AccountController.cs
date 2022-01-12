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
using BeerNet.Models;
using BeerNet.MathFunctions;

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

        [HttpGet]
        [Route("BeerNet/userSettings")]
        public IActionResult GetUserInfo()
        {
            string userID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            DataAccess accessor = new DataAccess();
            userSettings currentUserSettings = accessor.GetAll<userSettings>().FirstOrDefault();
            if(currentUserSettings == null)
            {
                currentUserSettings = generateDefaultUserSettings();
                accessor.Post(currentUserSettings);
            }
            return Json(currentUserSettings);
        }

        [HttpPost]
        [Route("BeerNet/userSettings")]
        public IActionResult UpdateUserInfo([FromBody]userSettings currentUserSettings)
        {
            string userID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            DataAccess accessor = new DataAccess();
            userSettings existingUserSettings = accessor.GetAll<userSettings>().FirstOrDefault();
            if (existingUserSettings == null)
            {
                existingUserSettings = generateDefaultUserSettings();
                accessor.Post(currentUserSettings);
                existingUserSettings = accessor.GetAll<userSettings>().FirstOrDefault();
                existingUserSettings.firstName = currentUserSettings.firstName;
                existingUserSettings.lastName = currentUserSettings.lastName;
                existingUserSettings.theme = currentUserSettings.theme;
            }
            else
            {
                existingUserSettings.firstName = currentUserSettings.firstName;
                existingUserSettings.lastName = currentUserSettings.lastName;
                existingUserSettings.theme = currentUserSettings.theme;
            }
            currentUserSettings = GlobalFunctions.AddIdIfNeeded(existingUserSettings, existingUserSettings.idString);
            return Json(accessor.Post(currentUserSettings));
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
            DataAccess accessor = new DataAccess();
            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
      
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                accessor.Post(generateDefaultUserSettings());
                return Json(GenerateJwtToken(model.Username, user));
            }
            else
            {
                if(result.Errors.Count() > 0)
                {
                    return Json(result.Errors);
                }
            }
      
            throw new ApplicationException("UNKNOWN_ERROR");
        }

        public userSettings generateDefaultUserSettings()
        {
            userSettings currentUserSettings = new userSettings
            {
                firstName = "",
                lastName = "",
                userID = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                userCreatedDate = DateTimeOffset.Now,
                theme = "dark"
            };
            return currentUserSettings;
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