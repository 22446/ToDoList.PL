using BresentationLogicLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace _objectInterface.PL.Controllers
{
    public class ObjectController : Controller
    {
       
        
        private readonly IUnitOfWork _unitOfWork;

        public ObjectController(IUnitOfWork unitOfWork)
        {
            
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var GetAll = await _unitOfWork.objectInterface.GetAllTasksAsync();
            return View(GetAll);
        }
        public async Task<IActionResult> Create(Objects objects)

        {
            
            if (ModelState.IsValid)
            {
                await _unitOfWork.objectInterface.AddAsync(objects);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objects);
        }
        public async Task<IActionResult> Upadte(int? Id)
        {   
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            var GetById = await _unitOfWork.objectInterface.GetTaskByIdAsync(Id.Value);
            if (GetById is null)
            {
                return NotFound();
            }
            return View(GetById);
        }
        [HttpPost]
        public async Task<IActionResult> Upadte(Objects  objects)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.objectInterface.Update(objects);
                    await _unitOfWork.CompleteAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(objects);
        }

        public async Task<IActionResult> Delete(Objects objects)
        {
            if (objects is not null)
            {
                 _unitOfWork.objectInterface.Delete(objects);
               await _unitOfWork.CompleteAsync();

            }
            return RedirectToAction(nameof(Index));
        }
    }
}

