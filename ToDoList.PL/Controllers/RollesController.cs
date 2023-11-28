using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.PL.ViewModels;

namespace ToDoList.PL.Controllers
{
    public class RollesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RollesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {

            var users = await _roleManager.Roles.Select(
                   U => new RolesViewModel()
                   {
                       ID = U.Id,
                       Name = U.Name

                   }).ToListAsync();
            return View(users);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RolesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Mapped = new IdentityRole()
                {
                    Id = model.ID,
                    Name = model.Name
                };
                await _roleManager.CreateAsync(Mapped);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Details(string ID, string viewModel = "Details")
        {
            var user = await _roleManager.FindByIdAsync(ID);
            if (user is null)
            {
                return NotFound();
            }
            var mapped = new RolesViewModel()
            {
                Name = user.Name
               
            };
            return View(viewModel, mapped);
        }
        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, "Edit");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RolesViewModel model, string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _roleManager.FindByIdAsync(id);
                    user.Name = model.Name;
                    
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
                var user = await _roleManager.FindByIdAsync(id);
                await _roleManager.DeleteAsync(user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }
    }
}

