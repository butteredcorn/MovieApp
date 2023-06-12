using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.ViewModels;

namespace MovieApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ActorsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var actors = await _context.Actors.ToListAsync(cancellationToken);

            var actorDTOs = _mapper.Map<List<ActorDTO>>(actors);

            return View(actorDTOs);
        }
    }
}
