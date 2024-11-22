using Microsoft.AspNetCore.Mvc;
using Method_Library.Data;
using System.Linq;
using System.Threading.Tasks;

public class LanguageMainMenuViewComponent : ViewComponent
{
    private readonly AppDbContext _context;

    public LanguageMainMenuViewComponent(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var languages = _context.Languages.OrderBy(l => l.Name).ToList();
        return View(languages);
    }
}
