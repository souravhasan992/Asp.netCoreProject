using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvedinceFinal.Models
{
    public class Designation
    {
        public Designation()
        {
            Employees = new HashSet<Employee>();
        }
        [Key]
        public int Designation_ID { get; set; }

        [StringLength(50)]
        public string Designation_Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
