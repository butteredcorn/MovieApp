using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Exceptions;
using MovieApp.Models;
using MovieApp.ViewModels;

namespace MovieApp.Services
{
    public interface ICinemasService
    {
        Task<IEnumerable<CinemaDTO>> GetAll(CancellationToken cancellationToken);

        Task<CinemaDTO> GetById(int id, CancellationToken cancellationToken);

        void Add(Cinema Cinema);

        void Update(int id, Cinema Cinema);

        void Delete(int id);
    }

    public class CinemasService : ICinemasService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CinemasService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Add(Cinema Cinema)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CinemaDTO>> GetAll(
            CancellationToken cancellationToken = default
        )
        {
            var cinemas = await _dbContext.Cinemas.ToListAsync(cancellationToken);

            var cinemaDTOs = _mapper.Map<List<CinemaDTO>>(cinemas);

            return cinemaDTOs;
        }

        public async Task<CinemaDTO> GetById(int id, CancellationToken cancellationToken = default)
        {
            var cinema =
                await _dbContext.Cinemas
                    .Where(c => c.Id == id)
                    .SingleOrDefaultAsync(cancellationToken)
                ?? throw new EntityNotFoundException<Cinema>();

            var cinemaDTO = _mapper.Map<CinemaDTO>(cinema);

            return cinemaDTO;
        }

        public void Update(int id, Cinema Cinema)
        {
            throw new NotImplementedException();
        }
    }
}
