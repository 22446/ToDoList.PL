using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Tasks
    {
        
        public int id { get; set; }
        
        public string TaskName { get; set; }
       
        public string TaskDescreption { get; set; }
        
        public DateTime TimeEndTheTask { get; set; }
        [ForeignKey("Object")]
        public int? ObjectFK { get; set; }
        public Objects Object { get; set; }
        public string imageName { get; set; }
        
     
    }
}
