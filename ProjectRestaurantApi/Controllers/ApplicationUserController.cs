using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ProjectRestaurantApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _singInManager;
        private readonly ApplicationSettings _appSettings;
        private readonly DatabaseContext _context;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, 
                                        SignInManager<ApplicationUser> signInManager,
                                        DatabaseContext context,
                                        IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _singInManager = signInManager;
            _appSettings = appSettings.Value;
            this._context = context;
        }

        [HttpPost]
        [Route("RegisterC")]
        //POST : /api/ApplicationUser/Register
        public async Task<Object> PostApplicationUserClient(ApplicationUserModel model)
        {
            var applicationUser = new ApplicationUser()
            {
              UserName= model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(applicationUser, new System.Security.Claims.Claim("ClientOnly", "Client"));
                    //await _userManager.AddClaimAsync(applicationUser, new System.Security.Claims.Claim("First Name", applicationUser.FullName));
                    await _userManager.AddClaimAsync(applicationUser, new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, applicationUser.Id));
                    
                    return Ok(result);
                    
                }
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        

        [HttpPost]
        [Route("Register")]
        //POST : /api/ApplicationUser/Register
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,

            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                if (result.Succeeded)
                {
                    if (model.Role=="Waiter")
                    {
                        await _userManager.AddClaimAsync(applicationUser, new System.Security.Claims.Claim("WaiterOnly", "Waiter"));
                        await _userManager.AddClaimAsync(applicationUser, new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, applicationUser.Id));

                    }
                    else if (model.Role=="Chef")
                    {
                        await _userManager.AddClaimAsync(applicationUser, new System.Security.Claims.Claim("ChefOnly", "Chef"));
                        await _userManager.AddClaimAsync(applicationUser, new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, applicationUser.Id));

                    }

                    return Ok(result);

                }
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("RegisterR")]
        //POST : /api/ApplicationUser/RegisterR
        public async Task<Object> PostApplicationUserResto(ApplicationUserModel model)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber
            };

            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(applicationUser, new System.Security.Claims.Claim("ManagerOnly", "Manager"));
                    await _userManager.AddClaimAsync(applicationUser, new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, applicationUser.Id));
                    return Ok(applicationUser);

                }
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return Ok(null);
        }

    }
}
