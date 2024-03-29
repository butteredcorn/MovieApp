﻿using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string AvatarURL { get; set; } = "";
        public string Biography { get; set; } = "";

        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
