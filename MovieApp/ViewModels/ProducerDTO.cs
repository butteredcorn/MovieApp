using AutoMapper;
using Bogus.DataSets;
using MovieApp.AutoMapper;
using MovieApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.ViewModels
{
    public class ProducerDTO : IMapFrom<Producer>
    {
        [Display(Name = "Full Name")]
        public required string FullName { get; set; }

        [Display(Name = "Biography")]
        public required string Biography { get; set; }

        [Display(Name = "Avatar")]
        public required string AvatarURL { get; set; }
        public IEnumerable<int> MovieIds { get; set; } = Enumerable.Empty<int>();

        public void Mapping(Profile profile)
        {
            profile
                .CreateMap<Producer, ProducerDTO>()
                .ForMember(
                    dto => dto.FullName,
                    opt => opt.MapFrom(p => $"{p.FirstName} {p.LastName}")
                )
                .ForMember(
                    dto => dto.MovieIds,
                    opt => opt.MapFrom(p => p.Movies.Select(m => m.Id))
                );
        }
    }
}
