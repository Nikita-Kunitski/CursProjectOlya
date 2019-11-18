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
	[Route("api/auditorium")]
	public class AuditoriumController: Controller
	{
		ApplicationDbContext db;
		public AuditoriumController(ApplicationDbContext context)
		{
			db = context;
		}

		[HttpGet]
		public IEnumerable<Auditorium> Get()
		{
			var auditoriums = db.Auditoriums.Include(a => a.AuditoriumType);
			return auditoriums.ToList();
		}

		[HttpGet("{id}")]
		public Auditorium Get(int id)
		{
			Auditorium auditoriums = db.Auditoriums.Include(a => a.AuditoriumType).FirstOrDefault(x => x.Id == id);
			return auditoriums;
		}

		[HttpPost]
		public IActionResult Post([FromBody]Auditorium auditorium)
		{
			if (ModelState.IsValid)
			{
				db.Auditoriums.Add(auditorium);
				db.SaveChanges();
				return Ok(auditorium);
			}
			return BadRequest(ModelState);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody]Auditorium auditorium)
		{
			if (ModelState.IsValid)
			{
				db.Update(auditorium);
				db.SaveChanges();
				return Ok(auditorium);
			}
			return BadRequest(ModelState);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			Auditorium auditorium = db.Auditoriums.FirstOrDefault(x => x.Id == id);
			if (auditorium != null)
			{
				db.Auditoriums.Remove(auditorium);
				db.SaveChanges();
			}
			return Ok(auditorium);
		}
	}
}
