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
	public class TimetablesController : Controller
	{
		private readonly ApplicationDbContext _context;

		public TimetablesController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var applicationDbContext = _context.Timetables.Include(p => p.Auditorium)
														.Include(p => p.Group)
														.Include(p => p.Numbersubjectofday)
														.Include(p => p.Subject)
														.Include(p => p.Teacher);
			return View(await applicationDbContext.ToListAsync());
		}

		public async Task<IActionResult> Create()
		{
			ViewData["AuditoriumId"] = new SelectList(_context.Auditoriums, "AuditoriumNumber", "AuditoriumNumber");
			ViewData["GroupId"] = new SelectList(_context.Groups, "Code", "Code");
			ViewData["TeacherId"] = new SelectList(_context.Teachers, "FullName", "FullName");
			ViewData["LessonNumberId"] = new SelectList(_context.LessonNumbers.OrderBy(p=>p.Number), "Number", "Number");
			ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectAbbreviation", "SubjectAbbreviation");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,DayOfWeek,TypeLesson,Numbersubjectofday,Subject,Teacher,Auditorium,Group")]Timetable timeTable)
		{
			var getAuditorium = await _context.Auditoriums.FirstOrDefaultAsync(p => p.AuditoriumNumber == timeTable.Auditorium.AuditoriumNumber);
			var getGroup = await _context.Groups.FirstOrDefaultAsync(p => p.Code == timeTable.Group.Code);
			var getTeacher = await _context.Teachers.FirstOrDefaultAsync(p => p.FullName == timeTable.Teacher.FullName);
			var getLessonNumber = await _context.LessonNumbers.FirstOrDefaultAsync(p => p.Number == timeTable.Numbersubjectofday.Number);
			var getSubject = await _context.Subjects.FirstOrDefaultAsync(p => p.SubjectAbbreviation == timeTable.Subject.SubjectAbbreviation);
			timeTable.AuditoriumId = getAuditorium.Id;
			timeTable.Auditorium = getAuditorium;
			timeTable.GroupId = getGroup.Id;
			timeTable.Group = getGroup;
			timeTable.NumbersubjectofdayId = getLessonNumber.Id;
			timeTable.Numbersubjectofday = getLessonNumber;
			timeTable.TeacherId = getTeacher.Id;
			timeTable.Teacher = getTeacher;
			timeTable.SubjectId = getSubject.Id;
			timeTable.Subject = getSubject;
			if (ModelState.IsValid)
			{
				_context.Add(timeTable);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["AuditoriumId"] = new SelectList(_context.Auditoriums, "AuditoriumNumber", "AuditoriumNumber",timeTable.AuditoriumId);
			ViewData["GroupId"] = new SelectList(_context.Groups, "Code", "Code",timeTable.GroupId);
			ViewData["TeacherId"] = new SelectList(_context.Teachers, "FullName", "FullName",timeTable.TeacherId);
			ViewData["LessonNumberId"] = new SelectList(_context.LessonNumbers, "Number", "Number",timeTable.NumbersubjectofdayId);
			ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectAbbreviation", "SubjectAbbreviation",timeTable.SubjectId);
			return View(timeTable);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var timeTable = await _context.Timetables.SingleOrDefaultAsync(m => m.Id == id);
			if (timeTable == null)
			{
				return NotFound();
			}
			ViewData["AuditoriumId"] = new SelectList(_context.Auditoriums, "AuditoriumNumber", "AuditoriumNumber");
			ViewData["GroupId"] = new SelectList(_context.Groups, "Code", "Code");
			ViewData["TeacherId"] = new SelectList(_context.Teachers, "FullName", "FullName");
			ViewData["LessonNumberId"] = new SelectList(_context.LessonNumbers.OrderBy(p => p.Number), "Number", "Number");
			ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectAbbreviation", "SubjectAbbreviation");
			return View(timeTable);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,DayOfWeek,TypeLesson,Numbersubjectofday,Subject,Teacher,Auditorium,Group")]Timetable timeTable)
		{
			if (id != timeTable.Id)
			{
				return NotFound();
			}
			var getAuditorium = await _context.Auditoriums.FirstOrDefaultAsync(p => p.AuditoriumNumber == timeTable.Auditorium.AuditoriumNumber);
			var getGroup = await _context.Groups.FirstOrDefaultAsync(p => p.Code == timeTable.Group.Code);
			var getTeacher = await _context.Teachers.FirstOrDefaultAsync(p => p.FullName == timeTable.Teacher.FullName);
			var getLessonNumber = await _context.LessonNumbers.FirstOrDefaultAsync(p => p.Number == timeTable.Numbersubjectofday.Number);
			var getSubject = await _context.Subjects.FirstOrDefaultAsync(p => p.SubjectAbbreviation == timeTable.Subject.SubjectAbbreviation);
			timeTable.AuditoriumId = getAuditorium.Id;
			timeTable.Auditorium = getAuditorium;
			timeTable.GroupId = getGroup.Id;
			timeTable.Group = getGroup;
			timeTable.NumbersubjectofdayId = getLessonNumber.Id;
			timeTable.Numbersubjectofday = getLessonNumber;
			timeTable.TeacherId = getTeacher.Id;
			timeTable.Teacher = getTeacher;
			timeTable.SubjectId = getSubject.Id;
			timeTable.Subject = getSubject;
			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(timeTable);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!TimetableExists(timeTable.Id))
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
			ViewData["AuditoriumId"] = new SelectList(_context.Auditoriums, "AuditoriumNumber", "AuditoriumNumber", timeTable.AuditoriumId);
			ViewData["GroupId"] = new SelectList(_context.Groups, "Code", "Code", timeTable.GroupId);
			ViewData["TeacherId"] = new SelectList(_context.Teachers, "FullName", "FullName", timeTable.TeacherId);
			ViewData["LessonNumberId"] = new SelectList(_context.LessonNumbers, "Number", "Number", timeTable.NumbersubjectofdayId);
			ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectAbbreviation", "SubjectAbbreviation", timeTable.SubjectId);
			return View(timeTable);
		}

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var timetables = await _context.Timetables.Include(p => p.Auditorium)
												.Include(p => p.Group)
												.Include(p => p.Numbersubjectofday)
												.Include(p => p.Subject)
												.Include(p => p.Teacher)
												.SingleOrDefaultAsync(m => m.Id == id);
			if (timetables == null)
			{
				return NotFound();
			}

			return View(timetables);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var timetables = await _context.Timetables.SingleOrDefaultAsync(m => m.Id == id);
			_context.Timetables.Remove(timetables);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool TimetableExists(int id)
		{
			return _context.Timetables.Any(e => e.Id == id);
		}
	}
}
