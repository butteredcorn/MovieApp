using AutoMapper;
using Bogus.DataSets;
using MovieApp.AutoMapper;
using MovieApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.ViewModels
{
    public class ActorDTO : IMapFrom<Actor>
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public required string FullName { get; set; }

        [Display(Name = "Last Name")]
        public required string FirstName { get; set; }

        [Display(Name = "Full Name")]
        public required string LastName { get; set; }

        [Display(Name = "Biography")]
        public required string Biography { get; set; }

        [Display(Name = "Avatar")]
        public required string AvatarURL { get; set; }
        public IEnumerable<int> MovieIds { get; set; } = Enumerable.Empty<int>();

        public void Mapping(Profile profile)
        {
            profile
                .CreateMap<Actor, ActorDTO>()
                .ForMember(dto => dto.FullName, opt => opt.MapFrom(a => a.FullName))
                .ForMember(
                    dto => dto.MovieIds,
                    opt => opt.MapFrom(a => a.Movies.Select(m => m.Id))
                );
        }
    }
}
