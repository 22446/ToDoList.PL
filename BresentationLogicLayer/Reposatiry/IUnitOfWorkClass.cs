using BresentationLogicLayer.Interfaces;
using DataAccessLayer.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BresentationLogicLayer.Reposatiry
{
    public class IUnitOfWorkClass : IUnitOfWork,IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public ITodoListInterface todoListInterface { get; set; }
        public IObjectInterface objectInterface { get; set; }
        public IUnitOfWorkClass(ApplicationDbContext dbContext)
        {
            todoListInterface = new ToDoLisRepo(dbContext);
            objectInterface = new ObjectRepo(dbContext);
            _dbContext = dbContext;
        }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }


    }
}
