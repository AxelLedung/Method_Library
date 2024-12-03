using Microsoft.AspNetCore.Mvc;
using Method_Library.Data;
using System.Linq;
using System.Threading.Tasks;

public class HomeSideMenuViewComponent : ViewComponent
{
    private readonly AppDbContext _context;

    public HomeSideMenuViewComponent(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
