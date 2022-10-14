using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using datamgmt.domain.DataModels.Admin;
using datamgmt.domain.DbContexts;
using datamgmt.domain.Repositories;
using datamgmt.domain.Repositories.Interfaces;

namespace datamgmt.web.Controllers
{
    public class USBExceptionController : Controller
    {
        private readonly DataMgmtDbContext _context;

        public USBExceptionController(DataMgmtDbContext context)
        {
            _context = context;
        }

        // GET: Plant_Site
        public async Task<IActionResult> Index(string searchFirst, string searchEmail, string searchLast, string search511)
        {



            USBRepository uSBRepository = new USBRepository(_context);
            return uSBRepository != null ?
                        View(await uSBRepository.FindUSB(searchFirst, searchEmail, searchLast, search511)) :
                        Problem("Entity set 'DataMgmtDbContext.USBException'  is null.");

        }


        // GET: Plant_Site/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.USBException == null)
            {
                return NotFound();
            }

            var uSBException = await _context.USBException
                .FirstOrDefaultAsync(m => m.ID == id);
            if (uSBException == null)
            {
                return NotFound();
            }

            return View(uSBException);
        }

        // GET: Plant_Site/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plant_Site/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(" ID , UPI , Abbott511, EmailID, Organization, FirstName, LastName, Country, RequestedDate, ArcherException, AddOrRemove, ReadWrite, ItemType, Path")] USBException USBExceptions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(USBExceptions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(USBExceptions);
        }

        // GET: Plant_Site/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.USBException == null)
            {
                return NotFound();
            }

            var USBExceptions = await _context.USBException.FindAsync(id);
            if (USBExceptions == null)
            {
                return NotFound();
            }
            return View(USBExceptions);
        }

        // POST: Plant_Site/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(" ID , UPI , Abbott511, EmailID, Organization, FirstName, LastName, Country, RequestedDate, ArcherException, AddOrRemove, ReadWrite, ItemType, Path")] USBException USBExceptions)
        {
            if (id != USBExceptions.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(USBExceptions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!USBExceptionExists(USBExceptions.ID))
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
            return View(USBExceptions);
        }

        // GET: Plant_Site/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.USBException == null)
            {
                return NotFound();
            }

            var USBExceptions = await _context.USBException
                .FirstOrDefaultAsync(m => m.ID == id);
            if (USBExceptions == null)
            {
                return NotFound();
            }

            return View(USBExceptions);
        }

        // POST: Plant_Site/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.USBException == null)
            {
                return Problem("Entity set 'DataMgmtDbContext.Plant_Site'  is null.");
            }
            var USBExceptions = await _context.USBException.FindAsync(id);
            if (USBExceptions != null)
            {
                _context.USBException.Remove(USBExceptions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool USBExceptionExists(int id)
        {
            return (_context.USBException?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
