using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Exceptions;
using MovieApp.Models;
using MovieApp.ViewModels;

namespace MovieApp.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<ActorDTO>> GetAll(CancellationToken cancellationToken);

        Task<ActorDTO> GetById(int id, CancellationToken cancellationToken);

        void Add(Actor actor);

        void Update(int id, Actor actor);

        void Delete(int id);
    }

    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ActorsService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Add(Actor actor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ActorDTO>> GetAll(
            CancellationToken cancellationToken = default
        )
        {
            var actors = await _dbContext.Actors.ToListAsync(cancellationToken);

            var actorDTOs = _mapper.Map<List<ActorDTO>>(actors);

            return actorDTOs;
        }

        public async Task<ActorDTO> GetById(int id, CancellationToken cancellationToken = default)
        {
            var actor =
                await _dbContext.Actors
                    .Where(a => a.Id == id)
                    .SingleOrDefaultAsync(cancellationToken)
                ?? throw new EntityNotFoundException<Actor>();

            var actorDTO = _mapper.Map<ActorDTO>(actor);

            return actorDTO;
        }

        public void Update(int id, Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
