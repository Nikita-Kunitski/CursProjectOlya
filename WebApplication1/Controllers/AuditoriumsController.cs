using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class AuditoriumsController:Controller
	{
		private readonly ApplicationDbContext _context;

		public AuditoriumsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Auditoriums
		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Auditoriums.Include(a => a.AuditoriumType);
			return View(await applicationDbContext.ToListAsync());
		}


		// GET: Auditoriums/Create
		public IActionResult Create()
		{
			ViewData["AuditoriumTypeId"] = new SelectList(_context.AuditoriumTypes, "AuditoriumAbbreviation", "AuditoriumAbbreviation");
			return View();
		}

		// POST: Auditoriums/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,AuditoriumNumber,AuditoriumCapacity,AuditoriumType")] Auditorium auditorium)
		{
			var gettype = await _context.AuditoriumTypes.FirstOrDefaultAsync(t =>
				t.AuditoriumAbbreviation == auditorium.AuditoriumType.AuditoriumAbbreviation);
			auditorium.AuditoriumType = gettype;
			auditorium.AuditoriumTypeId = gettype.Id;
			if (ModelState.IsValid)
			{
				_context.Add(auditorium);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["AuditoriumTypeId"] = new SelectList(_context.AuditoriumTypes, "Id", "Id", auditorium.AuditoriumTypeId);
			return View(auditorium);
		}

		// GET: Auditoriums/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var auditorium = await _context.Auditoriums.SingleOrDefaultAsync(m => m.Id == id);
			if (auditorium == null)
			{
				return NotFound();
			}
			ViewData["AuditoriumTypeId"] = new SelectList(_context.AuditoriumTypes, "AuditoriumAbbreviation", "AuditoriumAbbreviation");
			return View(auditorium);
		}

		// POST: Auditoriums/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,AuditoriumNumber,AuditoriumCapacity,AuditoriumType")] Auditorium auditorium)
		{
			if (id != auditorium.Id)
			{
				return NotFound();
			}

			var gettype = await _context.AuditoriumTypes.FirstOrDefaultAsync(t =>
				t.AuditoriumAbbreviation == auditorium.AuditoriumType.AuditoriumAbbreviation);
			auditorium.AuditoriumType = gettype;
			auditorium.AuditoriumType.Id = gettype.Id;
			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(auditorium);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!AuditoriumExists(auditorium.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["AuditoriumTypeId"] = new SelectList(_context.AuditoriumTypes, "Id", "Id", auditorium.AuditoriumTypeId);
			return View(auditorium);
		}

		// GET: Auditoriums/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var auditorium = await _context.Auditoriums
				.Include(a => a.AuditoriumType)
				.SingleOrDefaultAsync(m => m.Id == id);
			if (auditorium == null)
			{
				return NotFound();
			}

			return View(auditorium);
		}

		// POST: Auditoriums/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var auditorium = await _context.Auditoriums.SingleOrDefaultAsync(m => m.Id == id);
			_context.Auditoriums.Remove(auditorium);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool AuditoriumExists(int id)
		{
			return _context.Auditoriums.Any(e => e.Id == id);
		}
	}
}
