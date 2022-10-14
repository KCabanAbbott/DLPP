


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

namespace datamgmt.web.Controllers
{
    public class LocalFolderRemediationController : Controller
    {
        private readonly DataMgmtDbContext _context;

        public LocalFolderRemediationController(DataMgmtDbContext context)
        {
            _context = context;
        }

        // GET: Plant_Site
        public async Task<IActionResult> Index(string searchString)
        {
   


            LocalFolderRemediationRepository localFolderRemediation = new LocalFolderRemediationRepository(_context);
            return localFolderRemediation != null ?
                        View(await localFolderRemediation.FindFolder(searchString)) :
                        Problem("Entity set 'AriesDbContext.UserAccounts'  is null.");
        }

        // GET: Plant_Site/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LocalFolderRemediation == null)
            {
                return NotFound();
            }

            var LocalFolderRemediationss = await _context.LocalFolderRemediation
                .FirstOrDefaultAsync(m => m.ID == id);
            if (LocalFolderRemediationss == null)
            {
                return NotFound();
            }

            return View(LocalFolderRemediationss);
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
        public async Task<IActionResult> Create([Bind("ID, StartTime, Name, EndTime, Email, EmailSignature, DeviceName, IsComplete")] LocalFolderRemediation LocalFolderRemediations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(LocalFolderRemediations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(LocalFolderRemediations);
        }

        // GET: Plant_Site/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LocalFolderRemediation == null)
            {
                return NotFound();
            }

            var LocalFolderRemediations = await _context.LocalFolderRemediation.FindAsync(id);
            if (LocalFolderRemediations == null)
            {
                return NotFound();
            }
            return View(LocalFolderRemediations);
        }

        // POST: Plant_Site/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID, StartTime,  Name,EndTime, Email, EmailSignature, DeviceName, IsComplete")] LocalFolderRemediation LocalFolderRemediations)
        {
            if (id != LocalFolderRemediations.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)                
            {
                try
                {
                    _context.Update(LocalFolderRemediations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalFolderRemediationsExists(LocalFolderRemediations.ID))
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
            return View(LocalFolderRemediations);
        }
        
        // GET: Plant_Site/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LocalFolderRemediation == null)
            {
                return NotFound();
            }

            var LocalFolderRemediations = await _context.LocalFolderRemediation
                .FirstOrDefaultAsync(m => m.ID == id);
            if (LocalFolderRemediations == null)
            {
                return NotFound();
            }

            return View(LocalFolderRemediations);
        }

        // POST: Plant_Site/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LocalFolderRemediation == null)
            {
                return Problem("Entity set 'DataMgmtDbContext.Plant_Site'  is null.");
            }
            var LocalFolderRemediations = await _context.LocalFolderRemediation.FindAsync(id);
            if (LocalFolderRemediations != null)
            {
                _context.LocalFolderRemediation.Remove(LocalFolderRemediations);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalFolderRemediationsExists(int id)
        {
            return (_context.LocalFolderRemediation?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
