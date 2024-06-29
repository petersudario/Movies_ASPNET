using System.ComponentModel.DataAnnotations;

namespace RazorPagesFilme.Model
{
    public class Movie
    {
        public int Id { get; set; }
        [Display(Name = "Movie Title")]
        public string Title { get; set; } = string.Empty;
        [Display(Name = "Release Date")]
        [DataType (DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Movie genre")]
        public string Genre { get; set; } = string.Empty;
        [Display(Name = "Ticket price")]
        public decimal Price { get; set; }

        public int Rating { get; set; } = 0;
    }
}