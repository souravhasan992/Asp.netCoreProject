using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvedinceFinal.Models;
using Microsoft.AspNetCore.Hosting;
using EvedinceFinal.ViewModels;
using System.IO;

namespace EvedinceFinal.Controllers
{
    public class EmployeeRegistrationsController : Controller
    {
        private readonly EvidancefinalDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EmployeeRegistrationsController(EvidancefinalDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            List<VmEmpRegList> list = _context.employeeRegistrations.Select(t => new VmEmpRegList
            {
                Reg_ID = t.Reg_ID,
                Reg_Name = t.Reg_Name,
                Gender = t.Gender,
                DoB = t.DoB,
                Email = t.Email,
                ImageName = t.ImageName,
                ImageUrl = t.ImageUrl
            }).ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> AddOrEdit(VmEmpRegCreate vec)
        {
            var result = false;
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(vec.ImageFile.FileName);
            string extension = Path.GetExtension(vec.ImageFile.FileName);
            string fileWithExtension = fileName + extension;
            EmployeeRegistration employeeRegistration = new EmployeeRegistration();
            employeeRegistration.Reg_Name = vec.Reg_Name;
            employeeRegistration.Gender = vec.Gender;
            employeeRegistration.DoB = vec.DoB;
            employeeRegistration.Email = vec.Email;
            employeeRegistration.ImageName = fileWithExtension;
            employeeRegistration.ImageUrl = wwwRootPath + "/VM_Images/" + fileName + extension;
            string serverPath = Path.Combine(wwwRootPath + "/VM_Images/" + fileName + extension);
            using (var fileStream = new FileStream(serverPath, FileMode.Create))
            {
                await vec.ImageFile.CopyToAsync(fileStream);
            }
            if (ModelState.IsValid)
            {
                if (vec.Reg_ID == 0)
                {
                    _context.employeeRegistrations.Add(employeeRegistration);
                    _context.SaveChanges();
                    result = true;
                }
                else
                {
                    employeeRegistration.Reg_ID = vec.Reg_ID;
                    _context.Entry(employeeRegistration).State = EntityState.Modified;
                    _context.SaveChanges();
                    result = true;
                }
            }
            if (result)
            {
                return RedirectToAction("Index", "EmployeeRegistrations");
            }
            else
            {
                if (vec.Reg_ID == 0)
                {
                    return View("Create");
                }
                else
                {
                    return View("Edit");
                }
            }
        }
        public IActionResult Edit(int id)
        {
            EmployeeRegistration employeeRegistration = _context.employeeRegistrations.SingleOrDefault(t => t.Reg_ID == id);
            VmEmpRegCreate vec = new VmEmpRegCreate();
            vec.Reg_ID = employeeRegistration.Reg_ID;
            vec.Reg_Name = employeeRegistration.Reg_Name;
            vec.Gender = employeeRegistration.Gender;
            vec.DoB = employeeRegistration.DoB;
            vec.Email = employeeRegistration.Email;
            vec.ImageUrl = employeeRegistration.ImageUrl;
            vec.ImageName = employeeRegistration.ImageName;
            return View(vec);
        }
        public IActionResult Delete(int id)
        {
            EmployeeRegistration employeeRegistration = _context.employeeRegistrations.SingleOrDefault(t => t.Reg_ID == id);
            {
                _context.employeeRegistrations.Remove(employeeRegistration);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }

}
