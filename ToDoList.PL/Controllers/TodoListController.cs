using AutoMapper;
using BresentationLogicLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Threading.Tasks;
using ToDoList.PL.Helper;
using ToDoList.PL.ViewModels;

namespace ToDoList.PL.Controllers
{
    [Authorize]
    public class TodoListController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoListController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {

            var GetAll = await _unitOfWork.todoListInterface.GetAllTasksAsync();
            var mapindex = _mapper.Map<IEnumerable<Tasks>, IEnumerable<TaskViewModel>>(GetAll);
            return View(mapindex);
        }
        public async Task<IActionResult> Create(TaskViewModel taskVM)
        {
            ViewBag.Object = await _unitOfWork.objectInterface.GetAllTasksAsync();
            if (ModelState.IsValid)
            {
                taskVM.imageName = DocumentSetting.UploadFile(taskVM.formFile, "Images");
                var CreteVm = _mapper.Map<TaskViewModel, Tasks>(taskVM);
                await _unitOfWork.todoListInterface.AddAsync(CreteVm);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskVM);
        }
        public async Task<IActionResult> Upadte(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            ViewBag.Object = await _unitOfWork.objectInterface.GetAllTasksAsync();
            var GetById = await _unitOfWork.todoListInterface.GetTaskByIdAsync(Id.Value);
            var CreteVm = _mapper.Map<Tasks, TaskViewModel>(GetById);

            if (CreteVm is null)
            {
                return NotFound();
            }
            return View(CreteVm);
        }
        [HttpPost]
        public async Task< IActionResult> Upadte(TaskViewModel taskVM)
        {


            if (ModelState.IsValid)
            {
               
                    try
                    {
                    if (taskVM.formFile is not null)
                    {
                        taskVM.imageName = DocumentSetting.UploadFile(taskVM.formFile, "Images");
                    }
                         var CreteVm = _mapper.Map<TaskViewModel, Tasks>(taskVM);
                        _unitOfWork.todoListInterface.Update(CreteVm);
                        await _unitOfWork.CompleteAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
            }
            return View(taskVM);
        }

        public async Task<IActionResult> Delete(TaskViewModel taskVM)
        {
            var CreteVm = _mapper.Map<TaskViewModel, Tasks>(taskVM);

            if (CreteVm is not null)
            {
                _unitOfWork.todoListInterface.Delete(CreteVm);
                var Count = await _unitOfWork.CompleteAsync();
                if (Count > 0 && taskVM.formFile is not null)
                {
                    DocumentSetting.DeleteFile(taskVM.imageName, "Images");
                }

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
