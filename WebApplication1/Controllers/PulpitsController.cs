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
	public class PulpitsController:Controller
	{
		private readonly ApplicationDbContext _context;

		public PulpitsController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.Pulpits.ToListAsync());
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,PulpitName")] Pulpit pulpit)
		{
			if (ModelState.IsValid)
			{
				_context.Add(pulpit);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(pulpit);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var pulpit = await _context.Pulpits
				.SingleOrDefaultAsync(m => m.Id == id);
			if (pulpit == null)
			{
				return NotFound();
			}

			return View(pulpit);
		}

		//TODO продумать удаление кафедры
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var pulpit = await _context.Pulpits.SingleOrDefaultAsync(m => m.Id == id);
			_context.Pulpits.Remove(pulpit);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
