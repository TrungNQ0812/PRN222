﻿using System;
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
    public class DocumentsController : Controller
    {
        private readonly InternalDocumentManagementContext _context;

        public DocumentsController(InternalDocumentManagementContext context)
        {
            _context = context;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            var internalDocumentManagementContext = _context.Documents.Include(d => d.Account).Include(d => d.Category).Include(d => d.DocumentStatus);
            return View(await internalDocumentManagementContext.ToListAsync());
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .Include(d => d.Account)
                .Include(d => d.Category)
                .Include(d => d.DocumentStatus)
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["DocumentStatusId"] = new SelectList(_context.DocumentStatuses, "DocumentStatusId", "DocumentStatusId");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentId,DocumentContent,DocumentTitle,CreateAt,UpdateAt,DocumentStatusId,AccountId,CategoryId")] Document document)
        {
            if (ModelState.IsValid)
            {
                _context.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", document.AccountId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", document.CategoryId);
            ViewData["DocumentStatusId"] = new SelectList(_context.DocumentStatuses, "DocumentStatusId", "DocumentStatusId", document.DocumentStatusId);
            return View(document);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", document.AccountId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", document.CategoryId);
            ViewData["DocumentStatusId"] = new SelectList(_context.DocumentStatuses, "DocumentStatusId", "DocumentStatusId", document.DocumentStatusId);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentId,DocumentContent,DocumentTitle,CreateAt,UpdateAt,DocumentStatusId,AccountId,CategoryId")] Document document)
        {
            if (id != document.DocumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.DocumentId))
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
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", document.AccountId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", document.CategoryId);
            ViewData["DocumentStatusId"] = new SelectList(_context.DocumentStatuses, "DocumentStatusId", "DocumentStatusId", document.DocumentStatusId);
            return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .Include(d => d.Account)
                .Include(d => d.Category)
                .Include(d => d.DocumentStatus)
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document != null)
            {
                _context.Documents.Remove(document);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
            return _context.Documents.Any(e => e.DocumentId == id);
        }
    }
}
