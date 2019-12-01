using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class FacultiesController : Controller
    {
	    private readonly ApplicationDbContext _context;

		public FacultiesController(ApplicationDbContext context)
		{
			_context = context;
		}

	    public async Task<IActionResult> Index()
	    {
		    return View(await _context.Faculties.ToListAsync());
	    }

	    public IActionResult Create()
	    {
		    return View();
	    }

	    [HttpPost]
	    [ValidateAntiForgeryToken]
	    public async Task<IActionResult> Create([Bind("Id,FacultyAbbreviation,FacultyName")] Faculty faculty)
	    {
		    if (ModelState.IsValid)
		    {
			    _context.Add(faculty);
			    await _context.SaveChangesAsync();
			    return RedirectToAction(nameof(Index));
		    }
		    return View(faculty);
	    }

	    public async Task<IActionResult> Delete(int? id)
	    {
		    if (id == null)
		    {
			    return NotFound();
		    }

		    var faculty = await _context.Faculties
			    .SingleOrDefaultAsync(m => m.Id == id);
		    if (faculty == null)
		    {
			    return NotFound();
		    }

		    return View(faculty);
	    }

	    [HttpPost, ActionName("Delete")]
	    [ValidateAntiForgeryToken]
	    public async Task<IActionResult> DeleteConfirmed(int id)
	    {
		    var faculty = await _context.Faculties.SingleOrDefaultAsync(m => m.Id == id);
		    _context.Faculties.Remove(faculty);
		    await _context.SaveChangesAsync();
		    return RedirectToAction(nameof(Index));
	    }

	}
}