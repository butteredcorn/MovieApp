using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

        Task Add(Actor actor, CancellationToken cancellationToken);

        Task Update(int id, Actor actor, CancellationToken cancellationToken);

        Task Delete(int id, CancellationToken cancellationToken);
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

        public async Task Add(Actor actor, CancellationToken cancellationToken)
        {
            _dbContext.Add(actor);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var actor =
                await _dbContext.Actors
                    .Where(a => a.Id == id)
                    .SingleOrDefaultAsync(cancellationToken)
                ?? throw new EntityNotFoundException<Actor>();

            _dbContext.Remove(actor);
            await _dbContext.SaveChangesAsync(cancellationToken);
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
            var actor = await _dbContext.Actors
                .Where(a => a.Id == id)
                .SingleOrDefaultAsync(cancellationToken);

            var actorDTO = _mapper.Map<ActorDTO>(actor);

            return actorDTO;
        }

        public async Task Update(int id, Actor updatedActor, CancellationToken cancellationToken)
        {
            var actor =
                await _dbContext.Actors
                    .Where(a => a.Id == id)
                    .SingleOrDefaultAsync(cancellationToken)
                ?? throw new EntityNotFoundException<Actor>();

            // could also just go through each property, check if changed and change on the found entity
            _dbContext.Entry(actor).State = EntityState.Detached;
            updatedActor.Id = id;
            _dbContext.Update(updatedActor);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
