using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvedinceFinal.Models
{
    public class EmployeeRegistration
    {
        [Key]
        public int Reg_ID { get; set; }
        public string Reg_Name { get; set; }
        public string Gender { get; set; }
        public DateTime DoB { get; set; }
        public string Email { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }

        
    }
}
