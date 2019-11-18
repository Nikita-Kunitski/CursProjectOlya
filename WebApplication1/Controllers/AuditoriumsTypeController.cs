using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	[Route("api/auditoriumType")]
	public class AuditoriumsTypeController : Controller
	{
		ApplicationDbContext db;
		public AuditoriumsTypeController(ApplicationDbContext context)
		{
			db = context;
		}

		[HttpGet]
		public IEnumerable<AuditoriumType> Get()
		{
			return db.AuditoriumTypes.ToList();
		}

		[HttpGet("{id}")]
		public IEnumerable<AuditoriumType> Get(int id)
		{
			AuditoriumType auditoriumType = db.AuditoriumTypes.FirstOrDefault(x => x.Id == id);
			return db.AuditoriumTypes.ToList();
		}

		[HttpPost]
		public IActionResult Post([FromBody]AuditoriumType product)
		{
			if (ModelState.IsValid)
			{
				db.AuditoriumTypes.Add(product);
				db.SaveChanges();
				return Ok(product);
			}
			return BadRequest(ModelState);
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody]AuditoriumType product)
		{
			if (ModelState.IsValid)
			{
				db.Update(product);
				db.SaveChanges();
				return Ok(product);
			}
			return BadRequest(ModelState);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			AuditoriumType auditoriumType = db.AuditoriumTypes.FirstOrDefault(x => x.Id == id);
			if (auditoriumType != null)
			{
				db.AuditoriumTypes.Remove(auditoriumType);
				db.SaveChanges();
			}
			return Ok(auditoriumType);
		}
	}
}
