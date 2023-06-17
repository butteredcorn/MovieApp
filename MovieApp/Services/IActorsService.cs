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
}
