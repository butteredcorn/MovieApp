﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;

namespace MovieApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;

        public ActorsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await _context.Actors
                .Select(
                    a =>
                        new
                        {
                            FullName = $"{a.FirstName} {a.LastName}",
                            a.Biography,
                            a.AvatarURL,
                            MovieIds = a.Movies.Select(m => m.Id)
                        }
                )
                .ToListAsync(cancellationToken);

            return View();
        }
    }
}
