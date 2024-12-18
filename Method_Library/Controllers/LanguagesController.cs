﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Method_Library.Data;
using Method_Library.Models;

namespace Method_Library.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly AppDbContext _context;

        public LanguagesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Languages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Languages.ToListAsync());
        }

        public async Task<IActionResult> Display(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languages = await _context.Languages
                .Include(c => c.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);



            if (languages == null)
            {
                return NotFound();
            }

            return View(languages);
        }

        // GET: Languages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Languages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Languages languages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(languages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Display), new { id = languages.Id });
            }
            return View(languages);
        }

        // GET: Languages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languages = await _context.Languages.FindAsync(id);
            if (languages == null)
            {
                return NotFound();
            }
            return View(languages);
        }

        // POST: Languages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Languages languages)
        {
            if (id != languages.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(languages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguagesExists(languages.Id))
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
            return View(languages);
        }

        // GET: Languages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var languages = await _context.Languages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languages == null)
            {
                return NotFound();
            }

            return View(languages);
        }

        // POST: Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var languages = await _context.Languages.FindAsync(id);
            if (languages != null)
            {
                _context.Languages.Remove(languages);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguagesExists(int id)
        {
            return _context.Languages.Any(e => e.Id == id);
        }
    }
}
