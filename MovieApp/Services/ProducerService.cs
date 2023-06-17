using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Exceptions;
using MovieApp.Models;
using MovieApp.ViewModels;

namespace MovieApp.Services
{
    public interface IProducersService
    {
        Task<IEnumerable<ProducerDTO>> GetAll(CancellationToken cancellationToken);

        Task<ProducerDTO> GetById(int id, CancellationToken cancellationToken);

        void Add(Producer Producer);

        void Update(int id, Producer Producer);

        void Delete(int id);
    }

    public class ProducersService : IProducersService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProducersService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Add(Producer Producer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProducerDTO>> GetAll(
            CancellationToken cancellationToken = default
        )
        {
            var producers = await _dbContext.Producers.ToListAsync(cancellationToken);

            var producerDTOs = _mapper.Map<List<ProducerDTO>>(producers);

            return producerDTOs;
        }

        public async Task<ProducerDTO> GetById(
            int id,
            CancellationToken cancellationToken = default
        )
        {
            var producer =
                await _dbContext.Producers
                    .Where(p => p.Id == id)
                    .SingleOrDefaultAsync(cancellationToken)
                ?? throw new EntityNotFoundException<Producer>();

            var producerDTO = _mapper.Map<ProducerDTO>(producer);

            return producerDTO;
        }

        public void Update(int id, Producer Producer)
        {
            throw new NotImplementedException();
        }
    }
}
