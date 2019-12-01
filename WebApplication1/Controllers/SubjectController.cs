using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	[Route("api/subject")]
	public class SubjectController:Controller
	{
		ApplicationDbContext db;
		public SubjectController(ApplicationDbContext context)
		{
			db = context;
		}

		[HttpGet]
		public IEnumerable<Subject> Get()
		{
			return db.Subjects.ToList();
		}

		[HttpGet("{id}")]
		public Subject Get(int id)
		{
			Subject subject = db.Subjects.FirstOrDefault(x => x.Id == id);
			return subject;
		}

		[HttpPost]
		public IActionResult Post([FromBody]Subject subject)
		{
			if (ModelState.IsValid)
			{
				db.Subjects.Add(subject);
				db.SaveChanges();
				return Ok(subject);
			}
			return BadRequest(ModelState);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody]Subject subject)
		{
			if (ModelState.IsValid)
			{
				db.Update(subject);
				db.SaveChanges();
				return Ok(subject);
			}
			return BadRequest(ModelState);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			Subject subject = db.Subjects.FirstOrDefault(x => x.Id == id);
			if (subject != null)
			{
				db.Subjects.Remove(subject);
				db.SaveChanges();
			}
			return Ok(subject);
		}
	}
}
