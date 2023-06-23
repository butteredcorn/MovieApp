using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = "";

        [Required(ErrorMessage = "Avatar is required.")]
        public string AvatarURL { get; set; } = "";

        [Required(ErrorMessage = "Biography is required.")]
        public string Biography { get; set; } = "";
        public string FullName => $"{FirstName} {LastName}";

        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
