using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesFilme.Model;
using RazorPagesFilmes.Data;


namespace RazorPagesFilmes.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesFilmes.Data.RazorPagesFilmesContext _context;

        public IndexModel(RazorPagesFilmes.Data.RazorPagesFilmesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        public SelectList Genres { get; set; }


        public async Task OnGetAsync()
        {
            var movies = from movie in _context.Movie
                         select movie;
            
            if (!string.IsNullOrEmpty(Search))
            {
                movies = movies.Where(m => m.Title.Contains(Search));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(m => m.Genre == MovieGenre);
            }

            Genres = new SelectList(await _context.Movie.Select(m => m.Genre).Distinct().ToListAsync());
            
            Movie = await movies.ToListAsync();
        }
    }
}
