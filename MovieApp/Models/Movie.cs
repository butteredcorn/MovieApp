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

        public virtual ICollection<Image> Images { get; set; } = new List<Image>();

        [ForeignKey("ProducerId")]
        public int ProducerId { get; set; }
        public required virtual Producer Producer { get; set; }

        public virtual ICollection<Actor> Actors { get; set; } = new List<Actor>();
        public virtual ICollection<Cinema> Cinemas { get; set; } = new List<Cinema>();
    }
}
