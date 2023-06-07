using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models
{
    public class ActorMovie
    {
        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
        public required Movie Movie { get; set; }
        [ForeignKey("ActorId")]
        public int ActorId { get; set; }
        public required Actor Actor { get; set; }    
    }
}
