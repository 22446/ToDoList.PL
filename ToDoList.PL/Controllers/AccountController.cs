using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ToDoList.PL.Helper;
using ToDoList.PL.ViewModels;

namespace ToDoList.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {


            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                
                var Email = await _userManager.FindByEmailAsync(model.Email);
                if (Email is null)
                {
                    var user = new ApplicationUser()
                    {
                        UserName = model.Email.Split("@")[0],
                        Email = model.Email,
                        Fname = model.Fname,
                        Lname = model.Lname,
                        IsActive = model.IsAgree
                    };
                    var Result = await _userManager.CreateAsync(user, model.Password);
                    if (Result.Succeeded)
                    {
                        return RedirectToAction(nameof(Login));
                    }
                    else
                    {
                        foreach (var item in Result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, item.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "already exsist");
                }


            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var User = await _userManager.FindByEmailAsync(model.Email);
                if (User is not null)
                {
                    var flag = await _userManager.CheckPasswordAsync(User, model.Password);
                    if (flag)
                    {
                        var Result = await _signInManager.PasswordSignInAsync(User, model.Password, model.IsAgree, false);
                        if (Result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invallid Login");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        public async Task<IActionResult> SendEmailTOretrive(ForgetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (ModelState.IsValid)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var SendUrlLink = Url.Action("SendEmailTOoretrive", "Account", new { email = model.Email, token }, Request.Scheme);
                if (user is not null)
                {
                    var email = new Email()
                    {
                        To = model.Email,
                        Subject = "Change your Password",
                        Body = SendUrlLink
                    };
                    EmailSend.SendEmail(email);
                    return RedirectToAction("CheckYourInpox");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email is not Exisit");
                }
            }
            return View("ForgetPassword", model);
        }
        public IActionResult CheckYourInpox()
        {
            return View();
        }
        public IActionResult SendEmailTOoretrive(string email,string token )
        {
            TempData["email"] = email;
            TempData["token"] = token;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendEmailTOoretrive(ResetPasswordViewModel model)
        {
            string email = TempData["email"] as string;
            string token = TempData["token"] as string;
            var user =await _userManager.FindByEmailAsync(email);
            var Reset=await _userManager.ResetPasswordAsync(user,token,model.Password);
           
                if(Reset.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    foreach (var item in Reset.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
            return View();
        }
          
        
    }
}
