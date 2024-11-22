using Microsoft.AspNetCore.Mvc;
using Method_Library.Data;
using System.Linq;
using System.Threading.Tasks;
using Method_Library.Models;
using Microsoft.EntityFrameworkCore;

public class CategorySideMenuViewComponent : ViewComponent
{
    private readonly AppDbContext _context;

    public CategorySideMenuViewComponent(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var currentLanguage = ViewData["CurrentLanguage"] as Languages;

        // Fetch categories with the same LanguageId
        var categories = await _context.Categories
            .Where(c => c.LanguageId == currentLanguage.Id)
            .ToListAsync();
        return View(categories);
    }
}
