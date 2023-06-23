using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Models;
using MovieApp.Services;
using MovieApp.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace MovieApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var actorDTOs = await _service.GetAll(cancellationToken);
            return View(actorDTOs);
        }

        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var actor = await _service.GetById(id, cancellationToken);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [Bind("FirstName", "LastName", "Biography, AvatarURL")] Actor actor,
            CancellationToken cancellationToken
        )
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.Add(actor, cancellationToken);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("FirstName", "LastName", "Biography, AvatarURL")] Actor actor,
            CancellationToken cancellationToken
        )
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.Update(id, actor, cancellationToken);

            return RedirectToAction("Details", new { id });
        }

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var actor = await _service.GetById(id, cancellationToken);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }

        // delete view
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var actor = await _service.GetById(id, cancellationToken);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }

        // actual deletion
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(
            int id,
            CancellationToken cancellationToken
        )
        {
            var actor = await _service.GetById(id, cancellationToken);
            if (actor == null)
            {
                return View("NotFound");
            }
            await _service.Delete(id, cancellationToken);
            return RedirectToAction("Index");
        }
    }
}
