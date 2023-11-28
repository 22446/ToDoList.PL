using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Objects
    {
        [Key]
        public int iDd { get; set; }
        [Required]
        public string  ObjectaName { get; set; }
        public ICollection<Tasks> tasks { get; set; } = new HashSet<Tasks>();
    }
}
