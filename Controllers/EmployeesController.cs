using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvedinceFinal.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace EvedinceFinal.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EvidancefinalDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EmployeesController(EvidancefinalDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var EvidancefinalDbContext = _context.employee.Include(b => b.Designation);
            return View(await EvidancefinalDbContext.ToListAsync());

        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.employee.Include(b => b.Designation)
                .FirstOrDefaultAsync(m => m.Employee_ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["Designation_ID"] = new SelectList(_context.designation, "Designation_ID", "Designation_Name");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Employee_ID,Employee_Name,Address,Email,Image,ImageFile,DOB,Gender,Marital_Status,Joining_Date,Designation_ID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                //Image Create Work
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(employee.ImageFile.FileName);
                string extension = Path.GetExtension(employee.ImageFile.FileName);
                employee.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await employee.ImageFile.CopyToAsync(fileStream);
                }
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {

                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();

            }
            ViewData["Designation_ID"] = new SelectList(_context.designation, "Designation_ID", "Designation_Name", employee.Designation_ID);
            return View(employee);
        }


        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["Designation_ID"] = new SelectList(_context.designation, "Designation_ID", "Designation_Name", employee.Designation_ID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Employee_ID,Employee_Name,Address,Email,Image,ImageFile,DOB,Gender,Marital_Status,Joining_Date,Designation_ID")] Employee employee)
        {
            if (id != employee.Employee_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(employee.ImageFile.FileName);
                string extension = Path.GetExtension(employee.ImageFile.FileName);
                employee.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await employee.ImageFile.CopyToAsync(fileStream);
                }
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Employee_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Designation_ID"] = new SelectList(_context.designation, "Designation_ID", "Designation_Name", employee.Designation_ID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.employee.Include(b => b.Designation)
                .FirstOrDefaultAsync(m => m.Employee_ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.employee.FindAsync(id);
            //Image Delete Work
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", employee.Image);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            _context.employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.employee.Any(e => e.Employee_ID == id);
        }
    }
}

