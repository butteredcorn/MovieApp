using AutoMapper;
using Bogus.DataSets;
using MovieApp.AutoMapper;
using MovieApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.ViewModels
{
    public class ActorDTO : IMapFrom<Actor>
    {
        [Display(Name = "FullName")]
        public required string FullName { get; set; }

        [Display(Name = "Biography")]
        public required string Biography { get; set; }

        [Display(Name = "AvatarUrl")]
        public required string AvatarURL { get; set; }
        public IEnumerable<int> MovieIds { get; set; } = Enumerable.Empty<int>();

        public void Mapping(Profile profile)
        {
            profile
                .CreateMap<Actor, ActorDTO>()
                .ForMember(
                    dto => dto.FullName,
                    opt => opt.MapFrom(a => $"{a.FirstName} {a.LastName}")
                )
                .ForMember(
                    dto => dto.MovieIds,
                    opt => opt.MapFrom(a => a.Movies.Select(m => m.Id))
                );
        }
    }
}
