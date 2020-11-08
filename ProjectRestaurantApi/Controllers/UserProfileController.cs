using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectRestaurantApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProjectRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private IPasswordHasher<ApplicationUser> passwordHasher;
        public UserProfileController(UserManager<ApplicationUser> userManager, IPasswordHasher<ApplicationUser> passwordHash)
        {
            _userManager = userManager;
            passwordHasher = passwordHash;

        }

        [HttpGet]
        [Authorize]
        
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetClaimsAsync(user);
            ApplicationUserModel app= new ApplicationUserModel();
            if (roles[0].Type.Equals("ManagerOnly"))
            {
                app.Role = "Manager";
            }
            if (roles[0].Type.Equals("CustomersOnly"))
            {
                app.Role = "Customer";
            }
            if (roles[0].Type.Equals("WaiterOnly"))
            {
                app.Role = "Waiter";
            }
            if (roles[0].Type.Equals("ChefOnly"))
            {
                app.Role = "Chef";
            }
            if (roles[0].Type.Equals("Super Admin"))
            {
                app.Role = "Super Admin";
            }
            app.Id = userId;
            app.UserName = user.UserName;
            app.Email = user.Email;
            app.FullName = user.FullName;
            app.PhoneNumber = user.PhoneNumber;

            return app;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> getprofileinfos(string managerid)
        {
            var user = await _userManager.FindByIdAsync(managerid);
            
            return Ok(user);
        }

        [HttpPost]
        [Route("editpassword")]
        public async Task<IActionResult> editpasswordAsync(ApplicationUserModel app)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(app.Id);
            if (user != null && await _userManager.CheckPasswordAsync(user, app.currentpassword))
            {

                if (!string.IsNullOrEmpty(app.Password))
                user.PasswordHash = passwordHasher.HashPassword(user, app.Password);

                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return Ok();
            }
            return Ok();
        }


        [HttpPost]
        [Route("editfullname")]
        public async Task<IActionResult> editnameAsync(ApplicationUser app)
        {
            
            ApplicationUser user = await _userManager.FindByIdAsync(app.Id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(app.FullName))
                    user.FullName = app.FullName;
               
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return Ok();
            }
            return Ok();
        }


        [HttpPost]
        [Route("editemail")]
        public async Task<IActionResult> editemailAsync(ApplicationUser app)
        {
            app.NormalizedEmail = app.Email;
            ApplicationUser user = await _userManager.FindByIdAsync(app.Id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(app.Email))
                {
                    user.Email = app.Email;
                    user.UserName = app.Email;
                }

                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return Ok();
                else
                    return Ok("no");
            }

            return Ok();
        }
    }
}
