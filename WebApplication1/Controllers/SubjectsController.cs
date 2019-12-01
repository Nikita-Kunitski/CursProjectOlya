using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class SubjectsController:Controller
	{
		private readonly ApplicationDbContext _context;

		public SubjectsController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.Subjects.ToListAsync());
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,SubjectAbbreviation,SubjectName")] Subject subject)
		{
			if (ModelState.IsValid)
			{
				_context.Add(subject);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(subject);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var subject = await _context.Subjects
				.SingleOrDefaultAsync(m => m.Id == id);
			if (subject == null)
			{
				return NotFound();
			}
			return View(subject);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var subject = await _context.Subjects.SingleOrDefaultAsync(m => m.Id == id);
			_context.Subjects.Remove(subject);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
