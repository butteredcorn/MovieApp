using AutoMapper;
using Bogus.DataSets;
using MovieApp.AutoMapper;
using MovieApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.ViewModels
{
    public class MovieDTO : IMapFrom<Movie>
    {
        public int Id { get; set; }

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
        public IEnumerable<ActorDTO> ActorNames { get; set; } = Enumerable.Empty<ActorDTO>();
        public IEnumerable<CinemaDTO> CinemaNames { get; set; } = Enumerable.Empty<CinemaDTO>();

        public void Mapping(Profile profile)
        {
            profile
                .CreateMap<Movie, MovieDTO>()
                .ForMember(dto => dto.Genre, opt => opt.MapFrom(m => m.Genre.ToString()))
                .ForMember(dto => dto.ActorNames, opt => opt.MapFrom(m => m.Actors))
                .ForMember(dto => dto.CinemaNames, opt => opt.MapFrom(m => m.Cinemas))
                .ForMember(
                    dto => dto.ImageURLs,
                    opt => opt.MapFrom(m => m.Images.Select(i => i.Url))
                );
        }
    }
}
