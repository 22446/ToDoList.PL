using AutoMapper;
using DataAccessLayer.Migrations;
using ToDoList.PL.ViewModels;

namespace ToDoList.PL.Helper
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>();
        }
    }
}
