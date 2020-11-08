using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ProjectRestaurantApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectRestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly DatabaseContext _context;
        public ManagerController(DatabaseContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;

        }
        // GET: api/<ManagerController>
        [HttpGet]
        [Route("GetRequest")]
        public IActionResult GetResponseValue(string managerid)
        {
            var restid = _context.ApplicationUsers.Where(x => x.Id == managerid).FirstOrDefault().RestaurantId;
            var active = _context.Restaurant.Where(c => c.RestaurantId == restid).FirstOrDefault().RestaurantActive;
            RestaurantManagerBindingModel rest = new RestaurantManagerBindingModel();
            rest.active = active;
            rest.RestaurantId = (int)restid;
            return Ok(rest);
        }
        [HttpGet]
        [Route("RestActive")]
        public IActionResult RestActive(string managerid)
        {
            var restid = _context.ApplicationUsers.Where(x => x.Id == managerid).FirstOrDefault().RestaurantId;
            return Ok(restid);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> accept(ApplicationUserModel model)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                RestaurantId=model.RestaurantId
            };
            var message = new MimeMessage();
            MailboxAddress from = new MailboxAddress("Admin", "restaurantemail2@gmail.com");
            MailboxAddress to = new MailboxAddress("User", model.Email);
            Guid password = Guid.NewGuid();
            try
            {
                var result = await _userManager.CreateAsync(applicationUser, password.ToString());
                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(applicationUser, new System.Security.Claims.Claim("ManagerOnly", "Manager"));
                    await _userManager.AddClaimAsync(applicationUser, new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, applicationUser.Id));
                    //return Ok(applicationUser);
                    message.From.Add(from);
                    message.To.Add(to);
                    message.Subject = "Restaurant manager request";
                    message.Body = new TextPart("plain")
                    {
                        Text = "Your e-mail is: " + model.Email + " and your password is: " + password + ". \n You can change the password whenever you want."
                    };

                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("restaurantemail2@gmail.com", "Admin&123");
                        client.Send(message);
                        client.Disconnect(true);
                    }
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult Test()
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress from = new MailboxAddress("Admin", "restaurantemail2@gmail.com");
            message.From.Add(from);
            MailboxAddress to = new MailboxAddress("User", "norabitar0910@gmail.com");
            message.To.Add(to);
            message.Subject = "This is email subject";
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1>Hello World!</h1>";
            bodyBuilder.TextBody = "Hello World!";
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("restaurantemail2@gmail.com", "Admin&123");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
            return Ok();
        }

    }
}
