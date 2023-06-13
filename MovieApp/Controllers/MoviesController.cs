using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.ViewModels;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MoviesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var movies = await _context.Movies
                .Include(m => m.Images)
                .ToListAsync(cancellationToken);

            var movieDTOs = _mapper.Map<List<MovieDTO>>(movies);

            return View(movieDTOs);
        }
    }
}
