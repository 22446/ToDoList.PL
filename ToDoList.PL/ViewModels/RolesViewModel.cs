using System;

namespace ToDoList.PL.ViewModels
{
    public class RolesViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public RolesViewModel()
        {
            ID = Guid.NewGuid().ToString();
        }
    }
}
