﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Method_Library.Data;
using Method_Library.Models;
using Method_Library.ViewModels;

namespace Method_Library.Controllers
{
    public class SnippetsController : Controller
    {
        private readonly AppDbContext _context;

        public SnippetsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Snippets
        public async Task<IActionResult> Index()
        {
            var snippets = await _context.Snippets
                .Include(c => c.Categories)
                .Include(c => c.Categories.Languages)
                .ToListAsync();

            return View(snippets);
        }

        public async Task<IActionResult> Display(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snippets = await _context.Snippets
                .Include(c => c.Categories)
                .Include(c => c.Categories.Languages)
                .FirstOrDefaultAsync(m => m.Id == id);

            var currentCategory = _context.Categories.FirstOrDefault(c => c.Id == snippets.CategoryId);
            ViewData["CurrentCategory"] = currentCategory;

            if (snippets == null)
            {
                return NotFound();
            }

            return View(snippets);
        }


        // GET: Snippets/Create
        //Create Snippet without preset
        public IActionResult Create(int? categoryId, int? languageId)
        {
            var viewModel = new SnippetsViewModel
            {
                Categories = _context.Categories.Select(l => new SelectListItem
                {
                    Value = l.Id.ToString(),
                    Text = l.Name,
                }).ToList(),
                Language = new Languages()
            };

            if (categoryId.HasValue && languageId.HasValue)
            {
                ViewBag.CategoryId = categoryId;
                ViewBag.LanguageId = languageId;
                viewModel.Language = _context.Languages.FirstOrDefault(l => l.Id == languageId);
            }
            return View(viewModel);
        }

        // POST: Snippets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SnippetsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var snippets = new Snippets
                {
                    Name = viewModel.Name,
                    Code = viewModel.Code,
                    CategoryId = viewModel.SelectedCategoryId
                };
                _context.Add(snippets);
                _context.SaveChanges();
                return RedirectToAction(nameof(Display), new { id = snippets.Id});
            }

            viewModel.Categories = _context.Categories.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Name
            }).ToList();

            return View(viewModel);
        }

        // GET: Snippets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snippets = await _context.Snippets.FindAsync(id);
            if (snippets == null)
            {
                return NotFound();
            }
            return View(snippets);
        }

        // POST: Snippets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Code")] Snippets snippets)
        {
            if (id != snippets.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snippets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnippetsExists(snippets.Id))
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
            return View(snippets);
        }

        // GET: Snippets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snippets = await _context.Snippets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snippets == null)
            {
                return NotFound();
            }

            return View(snippets);
        }

        // POST: Snippets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snippets = await _context.Snippets.FindAsync(id);
            if (snippets != null)
            {
                _context.Snippets.Remove(snippets);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnippetsExists(int id)
        {
            return _context.Snippets.Any(e => e.Id == id);
        }
    }
}
