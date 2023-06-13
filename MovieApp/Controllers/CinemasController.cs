using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.ViewModels;

namespace MovieApp.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CinemasController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var cinemas = await _context.Cinemas.ToListAsync(cancellationToken);

            var cinemaDTOs = _mapper.Map<List<CinemaDTO>>(cinemas);

            return View(cinemaDTOs);
        }
    }
}
