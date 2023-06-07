using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public required string Url { get; set; }
    }
}
