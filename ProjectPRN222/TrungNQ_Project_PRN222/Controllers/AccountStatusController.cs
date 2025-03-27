using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrungNQ_Project_PRN222.DAL;
using TrungNQ_Project_PRN222.Models;

namespace TrungNQ_Project_PRN222.Controllers
{
    public class AccountStatusController : Controller
    {
        private readonly InternalDocumentManagementContext _context;

        public AccountStatusController(InternalDocumentManagementContext context)
        {
            _context = context;
        }

        // GET: AccountStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountStatuses.ToListAsync());
        }

        // GET: AccountStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountStatus = await _context.AccountStatuses
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (accountStatus == null)
            {
                return NotFound();
            }

            return View(accountStatus);
        }

        // GET: AccountStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusId,StatusName")] AccountStatus accountStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountStatus);
        }

        // GET: AccountStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountStatus = await _context.AccountStatuses.FindAsync(id);
            if (accountStatus == null)
            {
                return NotFound();
            }
            return View(accountStatus);
        }

        // POST: AccountStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusId,StatusName")] AccountStatus accountStatus)
        {
            if (id != accountStatus.StatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountStatusExists(accountStatus.StatusId))
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
            return View(accountStatus);
        }

        // GET: AccountStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountStatus = await _context.AccountStatuses
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (accountStatus == null)
            {
                return NotFound();
            }

            return View(accountStatus);
        }

        // POST: AccountStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountStatus = await _context.AccountStatuses.FindAsync(id);
            if (accountStatus != null)
            {
                _context.AccountStatuses.Remove(accountStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountStatusExists(int id)
        {
            return _context.AccountStatuses.Any(e => e.StatusId == id);
        }
    }
}
