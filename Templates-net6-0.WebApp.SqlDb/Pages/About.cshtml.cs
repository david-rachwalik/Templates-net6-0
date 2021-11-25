using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Templates_net6_0.WebApp.SqlDb.Data;
using Templates_net6_0.WebApp.SqlDb.Models;
using Templates_net6_0.WebApp.SqlDb.Models.ViewModels;

namespace Templates_net6_0.WebApp.SqlDb.Pages;

public class AboutModel : PageModel
{
    private readonly MainContext _context;

    public AboutModel(MainContext context)
    {
        _context = context;
    }

    public IList<EnrollmentDateGroup> Students { get; set; }

    public async Task OnGetAsync()
    {
        IQueryable<EnrollmentDateGroup> data =
            from student in _context.Students
            group student by student.EnrollmentDate into dateGroup
            select new EnrollmentDateGroup()
            {
                EnrollmentDate = dateGroup.Key,
                StudentCount = dateGroup.Count()
            };

        Students = await data.AsNoTracking().ToListAsync();
    }
}