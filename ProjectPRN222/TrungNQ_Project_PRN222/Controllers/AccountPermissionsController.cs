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
    public class AccountPermissionsController : Controller
    {
        private readonly InternalDocumentManagementContext _context;

        public AccountPermissionsController(InternalDocumentManagementContext context)
        {
            _context = context;
        }

        // GET: AccountPermissions
        public async Task<IActionResult> Index()
        {
            var internalDocumentManagementContext = _context.AccountPermissions.Include(a => a.Account).Include(a => a.Permission);
            return View(await internalDocumentManagementContext.ToListAsync());
        }

        // GET: AccountPermissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountPermission = await _context.AccountPermissions
                .Include(a => a.Account)
                .Include(a => a.Permission)
                .FirstOrDefaultAsync(m => m.AccountPermissionId == id);
            if (accountPermission == null)
            {
                return NotFound();
            }

            return View(accountPermission);
        }

        // GET: AccountPermissions/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "FullName");
            ViewData["PermissionId"] = new SelectList(_context.Permissions, "PermissionId", "PermissionName");
            return View();
        }

        // POST: AccountPermissions/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountPermissionId,AccountId,PermissionId")] AccountPermission accountPermission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountPermission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", accountPermission.AccountId);
            ViewData["PermissionId"] = new SelectList(_context.Permissions, "PermissionId", "PermissionId", accountPermission.PermissionId);
            return View(accountPermission);
        }

        // GET: AccountPermissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountPermission = await _context.AccountPermissions.FindAsync(id);
            if (accountPermission == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", accountPermission.AccountId);
            ViewData["PermissionId"] = new SelectList(_context.Permissions, "PermissionId", "PermissionId", accountPermission.PermissionId);
            return View(accountPermission);
        }

        // POST: AccountPermissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountPermissionId,AccountId,PermissionId")] AccountPermission accountPermission)
        {
            if (id != accountPermission.AccountPermissionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountPermission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountPermissionExists(accountPermission.AccountPermissionId))
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
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", accountPermission.AccountId);
            ViewData["PermissionId"] = new SelectList(_context.Permissions, "PermissionId", "PermissionId", accountPermission.PermissionId);
            return View(accountPermission);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountPermission = await _context.AccountPermissions
                .Include(a => a.Account)
                .Include(a => a.Permission)
                .FirstOrDefaultAsync(m => m.AccountPermissionId == id);
            if (accountPermission == null)
            {
                return NotFound();
            }

            return View(accountPermission);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountPermission = await _context.AccountPermissions.FindAsync(id);
            if (accountPermission != null)
            {
                _context.AccountPermissions.Remove(accountPermission);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountPermissionExists(int id)
        {
            return _context.AccountPermissions.Any(e => e.AccountPermissionId == id);
        }
    }
}
