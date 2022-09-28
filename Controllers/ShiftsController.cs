using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvedinceFinal.Models;
using static EvedinceFinal.Helper;

namespace EvedinceFinal.Controllers
{
    public class ShiftsController : Controller
    {
        private readonly EvidancefinalDbContext _context;

        public ShiftsController(EvidancefinalDbContext context)
        {
            _context = context;
        }

        // GET: Shifts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shift.ToListAsync());
        }

        // GET: Shifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shift = await _context.Shift
                .FirstOrDefaultAsync(m => m.Shift_ID == id);
            if (shift == null)
            {
                return NotFound();
            }

            return View(shift);
        }

        // GET: Transaction/AddOrEdit(Insert)
        // GET: Transaction/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Shift());
            else
            {
                var shift = await _context.Shift.FindAsync(id);
                if (shift == null)
                {
                    return NotFound();
                }
                return View(shift);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Shift_ID,Date,ShortCode,Onetime,OvertimeStart,OvertimeEnd,ShiftType")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    shift.Date = DateTime.Now;
                    _context.Add(shift);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(shift);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ShiftExists(shift.Shift_ID))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Shift.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", shift) });
        }



        // GET: Shifts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shift = await _context.Shift
                .FirstOrDefaultAsync(m => m.Shift_ID == id);
            if (shift == null)
            {
                return NotFound();
            }

            return View(shift);
        }

        // POST: Shifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shift = await _context.Shift.FindAsync(id);
            _context.Shift.Remove(shift);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShiftExists(int id)
        {
            return _context.Shift.Any(e => e.Shift_ID == id);
        }
    }
}
