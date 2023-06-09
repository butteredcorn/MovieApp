using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;

namespace MovieApp.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await _context.Producers
                .Select(
                    p =>
                        new
                        {
                            FullName = $"{p.FirstName} {p.LastName}",
                            p.Biography,
                            p.AvatarURL,
                            MovieIds = p.Movies.Select(m => m.Id)
                        }
                )
                .ToListAsync(cancellationToken);

            return View();
        }
    }
}
