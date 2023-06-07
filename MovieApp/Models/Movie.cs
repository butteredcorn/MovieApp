using MovieApp.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; } 
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public Genre Genre { get; set; }

        public List<Image> Images { get; set; } = new List<Image>();

        [ForeignKey("ProducerId")]
        public int ProducerId { get; set; }
        public required Producer Producer { get; set; }

        public List<ActorMovie> ActorMovies { get; set; } = new List<ActorMovie>();

        // cinemas have many movies, but a movie can only be purchased from one cinema
        [ForeignKey("CinemaId")]
        public int CinemaId { get; set; }
        public Cinema? Cinema { get; set; }
    }
}
