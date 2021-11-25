using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Templates_net6_0.WebApp.SqlDb.Data;
using Templates_net6_0.WebApp.SqlDb.Models;

namespace Templates_net6_0.WebApp.SqlDb.Pages.Movies;

public class IndexModel : PageModel
{
    private readonly MainContext _context;

    public IndexModel(MainContext context)
    {
        _context = context;
    }

    public IList<Movie> Movie { get; set; }
    [BindProperty(SupportsGet = true)]
    public string SearchString { get; set; }
    public SelectList Genres { get; set; }
    [BindProperty(SupportsGet = true)]
    public string MovieGenre { get; set; }

    public async Task OnGetAsync()
    {
        // Use LINQ to get list of genres.
        IQueryable<string> genreQuery = from m in _context.Movies
                                        orderby m.Genre
                                        select m.Genre;

        var movies = from m in _context.Movies
                        select m;

        if (!string.IsNullOrEmpty(SearchString))
        {
            movies = movies.Where(s => s.Title.Contains(SearchString));
        }

        if (!string.IsNullOrEmpty(MovieGenre))
        {
            movies = movies.Where(x => x.Genre == MovieGenre);
        }
        Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
        Movie = await movies.ToListAsync();
    }
}