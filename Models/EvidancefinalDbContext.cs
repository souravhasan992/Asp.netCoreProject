using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EvedinceFinal.Models
{
    public class EvidancefinalDbContext : DbContext
    {
            public EvidancefinalDbContext(DbContextOptions<EvidancefinalDbContext> options) : base(options)
            {

            }
            public DbSet<Employee> employee { get; set; }
            public DbSet<Designation> designation { get; set; }
            public DbSet<EmployeeRegistration> employeeRegistrations { get; set; }
            public DbSet<Shift> Shift { get; set; }
    }
}
