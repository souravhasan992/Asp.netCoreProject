using EvedinceFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EvedinceFinal.Controllers
{
    public class DemoController : Controller
    {
        //GET: DemoController
        public EvidancefinalDbContext _context;
        public DemoController(EvidancefinalDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        //GET: DemoController/Details/5
        public async Task<JsonResult> Load()
        {
            List<Emp> LstEmp = new List<Emp>();
            LstEmp = await _context.employee.Select(e => new Emp
            {
                EmpID = e.Employee_ID.ToString(),
                Designation = e.Designation.Designation_Name,
                FullName = e.Employee_Name
            }).ToListAsync();

            return Json(LstEmp);
        }

        //GET: DemoController/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: DemoController/Create
       [HttpPost]
        public async Task<JsonResult> Create(DateTime datetime, IFormFile file)
        {
            var x = datetime.ToString();
            var data = file;
            string fileByte = "";
            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    fileByte = Convert.ToBase64String(fileBytes);
                    //act on the Base64 data
                }
            }

            try
            {
                //await _context.employee.AddAsync(new Employee { Joining_Date = x, Picture = fileByte });
                await _context.SaveChangesAsync();
                return Json(true);
            }
            catch (Exception ex)
            {
                var z = ex;
                return Json(false);
            }
        }

        //GET: DemoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //POST: DemoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GET: DemoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //POST: DemoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
