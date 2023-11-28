using BresentationLogicLayer.Interfaces;
using DataAccessLayer.DBContext;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BresentationLogicLayer.Reposatiry
{
    public class ObjectRepo : GenericRepo<Objects>,IObjectInterface
    {
        public ObjectRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
