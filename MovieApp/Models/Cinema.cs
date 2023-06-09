using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string LogoURL { get; set; } = "";
        public string Description { get; set; } = "";

        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
