using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class AuditoriumTypesController : Controller
	{
		private readonly ApplicationDbContext _context;

		public AuditoriumTypesController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: AuditoriumTypes
		public async Task<IActionResult> Index()
		{
			return View(await _context.AuditoriumTypes.ToListAsync());
		}

		// GET: AuditoriumTypes/Create
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,AuditoriumAbbreviation,AuditoriumName")] AuditoriumType auditoriumType)
		{
			if (ModelState.IsValid)
			{
				_context.Add(auditoriumType);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(auditoriumType);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var auditoriumType = await _context.AuditoriumTypes
				.SingleOrDefaultAsync(m => m.Id == id);
			if (auditoriumType == null)
			{
				return NotFound();
			}

			return View(auditoriumType);
		}

		// POST: AuditoriumTypes/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var auditoriumType = await _context.AuditoriumTypes.SingleOrDefaultAsync(m => m.Id == id);
			_context.AuditoriumTypes.Remove(auditoriumType);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

	}
}
