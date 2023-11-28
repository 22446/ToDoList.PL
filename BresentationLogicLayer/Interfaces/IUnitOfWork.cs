using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BresentationLogicLayer.Interfaces
{
    public interface IUnitOfWork
    {
        public ITodoListInterface  todoListInterface { get; set; }
        public IObjectInterface objectInterface { get; set; }

        public Task<int> CompleteAsync();
    }
}
