using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Exceptions;
using MovieApp.Models;
using MovieApp.ViewModels;

namespace MovieApp.Services
{
    public interface IMoviesService
    {
        Task<IEnumerable<MovieDTO>> GetAll(CancellationToken cancellationToken);

        Task<MovieDTO> GetById(int id, CancellationToken cancellationToken);

        void Add(Movie Movie);

        void Update(int id, Movie Movie);

        void Delete(int id);
    }

    public class MoviesService : IMoviesService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public MoviesService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Add(Movie Movie)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MovieDTO>> GetAll(
            CancellationToken cancellationToken = default
        )
        {
            var movies = await _dbContext.Movies
                .Include(m => m.Images)
                .Include(m => m.Actors)
                .Include(m => m.Cinemas)
                .ToListAsync(cancellationToken);

            var movieDTOs = _mapper.Map<List<MovieDTO>>(movies);

            return movieDTOs;
        }

        public async Task<MovieDTO> GetById(int id, CancellationToken cancellationToken = default)
        {
            var movie =
                await _dbContext.Movies
                    .Where(m => m.Id == id)
                    .SingleOrDefaultAsync(cancellationToken)
                ?? throw new EntityNotFoundException<Movie>();

            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return movieDTO;
        }

        public void Update(int id, Movie Movie)
        {
            throw new NotImplementedException();
        }
    }
}
