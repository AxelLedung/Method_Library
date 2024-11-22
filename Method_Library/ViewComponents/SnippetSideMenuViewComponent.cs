using Microsoft.AspNetCore.Mvc;
using Method_Library.Data;
using Method_Library.Models;
using System.Linq;
using System.Threading.Tasks;
using Method_Library.Controllers;
using Microsoft.EntityFrameworkCore;

public class SnippetSideMenuViewComponent : ViewComponent
{
    private readonly AppDbContext _context;

    public SnippetSideMenuViewComponent(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var currentCategory = ViewData["CurrentCategory"] as Categories;

        // Fetch categories with the same LanguageId
        var snippets = await _context.Snippets
            .Where(c => c.CategoryId == currentCategory.Id)
            .ToListAsync();
        return View(snippets);

    }
}
