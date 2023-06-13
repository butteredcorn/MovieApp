using AutoMapper;
using Bogus.DataSets;
using MovieApp.AutoMapper;
using MovieApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.ViewModels
{
    public class CinemaDTO : IMapFrom<Cinema>
    {
        [Display(Name = "Name")]
        public required string Name { get; set; }

        [Display(Name = "Description")]
        public required string Description { get; set; }

        [Display(Name = "Logo")]
        public required string LogoURL { get; set; }
        public IEnumerable<int> MovieIds { get; set; } = Enumerable.Empty<int>();

        public void Mapping(Profile profile)
        {
            profile
                .CreateMap<Cinema, CinemaDTO>()
                .ForMember(
                    dto => dto.MovieIds,
                    opt => opt.MapFrom(c => c.Movies.Select(m => m.Id))
                );
        }
    }
}
