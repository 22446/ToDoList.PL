using DataAccessLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;
using Microsoft.AspNetCore.Http;

namespace ToDoList.PL.ViewModels
{
    public class TaskViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Task Name Is Requierd"), MaxLength(40)]
        [Display(Name = "Task Descrition")]
        public string TaskName { get; set; }
        [Required(ErrorMessage = "Must ADD The Descrition")]
        [Display(Name = "Task Descrition")]
        public string TaskDescreption { get; set; }
        [Display(Name = "Time That Task Will Be Endedd")]
        public DateTime TimeEndTheTask { get; set; }
        [ForeignKey("Object")]
        public int? ObjectFK { get; set; }
        public Objects Object { get; set; }
        public string imageName { get; set; }
        public IFormFile formFile { get; set; }

    }
}
