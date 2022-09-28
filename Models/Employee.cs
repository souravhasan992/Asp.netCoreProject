using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvedinceFinal.Models
{
    public class Employee
    {
        [Key]
        public int Employee_ID { get; set; }

        [StringLength(50)]
        [DisplayName("Name")]
        public string Employee_Name { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public string Image { get; set; }
        [NotMapped]
        [DisplayName("Upload file")]
        public IFormFile ImageFile { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(50)]
        [DisplayName("M Status")]
        public string Marital_Status { get; set; }

        
        [DataType(DataType.Date)]
        [DisplayName("J Date")]
        public DateTime? Joining_Date { get; set; }
        [DisplayName("Deg")]
        public int? Designation_ID { get; set; }
        public virtual Designation Designation { get; set; }
    }
}
