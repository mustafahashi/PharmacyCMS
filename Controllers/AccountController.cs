using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using pharmacy.DTO;
 
 
using pharmacyCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pharmacyCMS.Controllers
{
    public class AccountController : Controller
    {


        private readonly ApplicationDbContext _context;
        
        public AccountController(ApplicationDbContext context )
        {
             
            _context = context;
        }

        [HttpGet("login")]
        public IActionResult Login(string returnurl)
        {
            ViewBag.ReturnUrl = returnurl;  
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult>   Login(login obj ,String ReturnUrl)
        {

            var user = _context.AppUser.SingleOrDefault(x => x.UserName == obj.username);
            if (user == null) return Unauthorized("user name doesent exist");
            //using var hmac = new HMACSHA512(user.PasswordSalt);
            //var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(obj.password));
            //for (int i = 0; i < computedHash.Length; i++)
            //{
            //    if (computedHash[i] != user.PasswordHash[i])
            //    {
            //        return Unauthorized("password invalid");
            //    }

            //}
            bool a = await authorize(obj);
            if (!a) return Unauthorized("unauthorized");

            return Redirect("/sales/view");
        }
        public async Task<bool> authorize(login obj) {
            bool val= true;
            try {
                var claim = new List<Claim>();
                claim.Add(new Claim("username", obj.username));
                claim.Add(new Claim(ClaimTypes.NameIdentifier, obj.username));
                var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                var calimsPrenciple = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync(calimsPrenciple);
            }
            catch { val = false; }
            return val;
        }
        public IActionResult registeration()
        {
            return View();
        }
     

        [HttpPost]
        public IActionResult registeration(login obj)
        {
            if (CheckNAme(obj.username)) return BadRequest("UserName is taken");
            using var hmac = new HMACSHA512();

            AppUser obj1 = new AppUser();
            obj1.UserName = obj.username.ToLower();
            obj1.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(obj.password));
            obj1.PasswordSalt = hmac.Key;
            _context.AppUser.Add(obj1);
            _context.SaveChanges();

            return View(); 
        }
        private bool CheckNAme(string name)
        {
            return _context.AppUser.Any(x => x.UserName == name.ToLower());
        }
    }
}
