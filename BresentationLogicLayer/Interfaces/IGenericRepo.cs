using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BresentationLogicLayer.Interfaces
{
    public interface IGenericRepo<T>
    {
        public Task<IEnumerable<T>> GetAllTasksAsync();
        public Task<T> GetTaskByIdAsync(int id);
        public void Update(T Entity);
        public void Delete(T Entity);
        public Task AddAsync(T Entity);
    }
}
