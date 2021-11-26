using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Templates_net6_0.WebApp.SqlDb.Data;
using Templates_net6_0.WebApp.SqlDb.Models;
using Templates_net6_0.WebApp.SqlDb.Models.ViewModels;

namespace Templates_net6_0.WebApp.SqlDb.Pages.Students;

public class CreateModel : PageModel
{
    private readonly MainContext _context;

    public CreateModel(MainContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public StudentDTO Student { get; set; }

    //public async Task<IActionResult> OnPostAsync()
    //{
    //    var emptyStudent = new Student();

    //    if (await TryUpdateModelAsync<Student>(
    //        emptyStudent,
    //        "student",   // Prefix for form value.
    //        s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
    //    {
    //        _context.Students.Add(emptyStudent);
    //        await _context.SaveChangesAsync();
    //        return RedirectToPage("./Index");
    //    }

    //    return Page();
    //}

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var entry = _context.Add(new Student());
        entry.CurrentValues.SetValues(Student);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
}