using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class SpecialitiesController : Controller
	{
		private readonly ApplicationDbContext _context;

		public SpecialitiesController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Specialities.Include(a => a.Faculty);
			return View(await applicationDbContext.ToListAsync());
		}

		public IActionResult Create()
		{
			ViewData["FacultyId"] = new SelectList(_context.Faculties, "FacultyAbbreviation", "FacultyAbbreviation");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Code,SpecialityAbbreviation,SpecialityName,Faculty")] Speciality speciality)
		{
			var gettype = await _context.Faculties.FirstOrDefaultAsync(t =>
				t.FacultyAbbreviation == speciality.Faculty.FacultyAbbreviation);
			speciality.Faculty = gettype;
			speciality.FacultyId= gettype.Id;
			if (ModelState.IsValid)
			{
				_context.Add(speciality);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Id", speciality.FacultyId);
			return View(speciality);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var speciality = await _context.Specialities
				.Include(a => a.Faculty)
				.SingleOrDefaultAsync(m => m.Id == id);
			if (speciality == null)
			{
				return NotFound();
			}

			return View(speciality);
		}

		// POST: Auditoriums/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var speciality = await _context.Specialities.SingleOrDefaultAsync(m => m.Id == id);
			_context.Specialities.Remove(speciality);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
