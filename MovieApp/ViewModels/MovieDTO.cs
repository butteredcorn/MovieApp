using AutoMapper;
using Bogus.DataSets;
using MovieApp.AutoMapper;
using MovieApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.ViewModels
{
    public class MovieDTO : IMapFrom<Movie>
    {
        [Display(Name = "Title")]
        public required string Title { get; set; }

        [Display(Name = "Genre")]
        public required string Genre { get; set; }

        [Display(Name = "Description")]
        public required string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<string> ImageURLs { get; set; } = Enumerable.Empty<string>();
        public IEnumerable<int> ActorIds { get; set; } = Enumerable.Empty<int>();
        public IEnumerable<int> CinemaIds { get; set; } = Enumerable.Empty<int>();

        public void Mapping(Profile profile)
        {
            profile
                .CreateMap<Movie, MovieDTO>()
                .ForMember(dto => dto.Genre, opt => opt.MapFrom(m => m.Genre.ToString()))
                .ForMember(dto => dto.ActorIds, opt => opt.MapFrom(m => m.Actors.Select(a => a.Id)))
                .ForMember(
                    dto => dto.CinemaIds,
                    opt => opt.MapFrom(m => m.Cinemas.Select(c => c.Id))
                )
                .ForMember(
                    dto => dto.ImageURLs,
                    opt => opt.MapFrom(m => m.Images.Select(i => i.Url))
                );
        }
    }
}
