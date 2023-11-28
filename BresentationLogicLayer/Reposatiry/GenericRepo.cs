using BresentationLogicLayer.Interfaces;
using DataAccessLayer.DBContext;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BresentationLogicLayer.Reposatiry
{
    public class GenericRepo<T> : IGenericRepo<T> where T:class
    {
        private readonly ApplicationDbContext dbContext;

        public GenericRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(T Entity)
        {
            await dbContext.AddAsync(Entity);
            
        }

        public void Delete(T Entity)
        {
            dbContext.Remove(Entity);
           
        }

        public async Task <IEnumerable<T>> GetAllTasksAsync()
        {
            if (typeof(T)==typeof(Tasks) ) {
                return  (IEnumerable<T>)await dbContext.tasks.Include(a => a.Object).ToListAsync();
            }
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetTaskByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T Entity)
        {
            dbContext.Update(Entity);
         
        }
    }
}

