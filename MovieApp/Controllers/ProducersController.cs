using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;
using MovieApp.ViewModels;

namespace MovieApp.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProducersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var producers = await _context.Producers.ToListAsync(cancellationToken);

            var producerDTOs = _mapper.Map<List<ProducerDTO>>(producers);

            return View(producerDTOs);
        }
    }
}
