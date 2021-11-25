using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Templates_net6_0.WebApp.SqlDb.Data;
using Templates_net6_0.WebApp.SqlDb.Models;

namespace Templates_net6_0.WebApp.SqlDb.Pages.Students;

public class DetailsModel : PageModel
{
    private readonly MainContext _context;

    public DetailsModel(MainContext context)
    {
        _context = context;
    }

    public Student Student { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Student = await _context.Students
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

        if (Student == null)
        {
            return NotFound();
        }
        return Page();
    }
}