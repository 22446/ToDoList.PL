using AutoMapper;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.PL.ViewModels;

namespace ToDoList.PL.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index(string SearchValue)
        {
            if (string.IsNullOrEmpty(SearchValue))
            {
                var users = await _userManager.Users.Select(
                    U => new UserViewModel()
                    {
                        Id = U.Id,
                        Fname = U.Fname,
                        Lname = U.Lname,
                        Email = U.Email,
                        PhoneNumber = U.PhoneNumber,
                        Roles = _userManager.GetRolesAsync(U).Result

                    }).ToListAsync();
                return View(users);
            }
            else
            {
                var User = await _userManager.FindByEmailAsync(SearchValue);
                var Mapped = new UserViewModel()
                {
                    Id = User.Id,
                    Fname = User.Fname,
                    Lname = User.Lname,
                    PhoneNumber = User.PhoneNumber,
                    Roles = _userManager.GetRolesAsync(User).Result
                };

                return View(new List<UserViewModel>() { Mapped });
            }


        }
        public async Task<IActionResult> Details(string ID, string viewModel = "Details")
        {
            var user = await _userManager.FindByIdAsync(ID);
            if (user is null)
            {
                return NotFound();
            }
            var mapped = new UserViewModel()
            {
                Id = user.Id,
                Fname = user.Fname,
                Lname = user.Lname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles = _userManager.GetRolesAsync(user).Result
            };
            return View(viewModel, mapped);
        }
        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, "Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel model, string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByIdAsync(id);
                    user.Fname = model.Fname;
                    user.Lname = model.Lname;
                    user.PhoneNumber = model.PhoneNumber;
                    await _userManager.UpdateAsync(user);
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            
                try
                {
                    var user = await _userManager.FindByIdAsync(id);
                    await _userManager.DeleteAsync(user);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty,ex.Message);
                    return RedirectToAction("Error","Home");
                }  
        }
    }
}
