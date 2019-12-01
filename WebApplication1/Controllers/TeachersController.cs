using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class TeachersController : Controller
	{
		private readonly ApplicationDbContext _context;

		public TeachersController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Teachers.Include(a => a.Pulpit);
			return View(await applicationDbContext.ToListAsync());
		}

		public IActionResult Create()
		{
			ViewData["PulpitId"] = new SelectList(_context.Pulpits, "PulpitName", "PulpitName");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,FullName,Pulpit")] Teacher teacher)
		{
			if (teacher.Pulpit == null)
				ModelState.AddModelError(string.Empty,"Надо заполнить поле кафедры");
			if (ModelState.IsValid)
			{
				var gettype = await _context.Pulpits.FirstOrDefaultAsync(t => t.PulpitName == teacher.Pulpit.PulpitName);
				teacher.Pulpit = gettype;
				teacher.PulpitId = gettype.Id;
				_context.Add(teacher);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["PulpitId"] = new SelectList(_context.Pulpits, "Id", "Id", teacher.PulpitId);
			return View(teacher);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var teacher = await _context.Teachers.SingleOrDefaultAsync(m => m.Id == id);
			if (teacher == null)
			{
				return NotFound();
			}
			ViewData["PulpitId"] = new SelectList(_context.Pulpits, "PulpitName", "PulpitName");
			return View(teacher);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Pulpit")] Teacher teacher)
		{
			if (id != teacher.Id)
			{
				return NotFound();
			}

			var gettype = await _context.Pulpits.FirstOrDefaultAsync(t =>
				t.PulpitName == teacher.Pulpit.PulpitName);
			teacher.Pulpit = gettype;
			teacher.Pulpit.Id = gettype.Id;
			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(teacher);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!TeacherExists(teacher.Id))
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
			ViewData["PulpitId"] = new SelectList(_context.Pulpits, "Id", "Id", teacher.PulpitId);
			return View(teacher);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var teacher = await _context.Teachers.Include(a => a.Pulpit).SingleOrDefaultAsync(m => m.Id == id);
			if (teacher == null)
			{
				return NotFound();
			}

			return View(teacher);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var teacher = await _context.Teachers.SingleOrDefaultAsync(m => m.Id == id);
			_context.Teachers.Remove(teacher);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool TeacherExists(int id)
		{
			return _context.Teachers.Any(e => e.Id == id);
		}
	}
}
