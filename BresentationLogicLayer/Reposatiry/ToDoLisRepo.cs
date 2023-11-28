using BresentationLogicLayer.Interfaces;
using DataAccessLayer.DBContext;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;


namespace BresentationLogicLayer.Reposatiry
{
    public class ToDoLisRepo : GenericRepo<Tasks>,ITodoListInterface
    {
        public ToDoLisRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
