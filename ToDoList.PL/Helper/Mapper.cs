using AutoMapper;
using DataAccessLayer.Models;
using ToDoList.PL.ViewModels;

namespace ToDoList.PL.Helper
{
    public class Mapperr : Profile
    {
        public Mapperr()
        {
            CreateMap<Tasks, TaskViewModel>().ReverseMap();
        }
    }
}
