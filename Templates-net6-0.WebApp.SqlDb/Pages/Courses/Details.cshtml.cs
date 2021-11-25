using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Templates_net6_0.WebApp.SqlDb.Data;
using Templates_net6_0.WebApp.SqlDb.Models;

namespace Templates_net6_0.WebApp.SqlDb.Pages.Courses;

public class DetailsModel : PageModel
{
    private readonly MainContext _context;

    public DetailsModel(MainContext context)
    {
        _context = context;
    }

    public Course Course { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Course = await _context.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .FirstOrDefaultAsync(m => m.CourseID == id);

        if (Course == null)
        {
            return NotFound();
        }
        return Page();
    }
}