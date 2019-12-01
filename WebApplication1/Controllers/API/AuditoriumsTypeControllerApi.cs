using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers.API
{
	[Route("api/auditoriumType")]
	public class AuditoriumsTypeControllerApi : Controller
	{
		ApplicationDbContext db;
		public AuditoriumsTypeControllerApi(ApplicationDbContext context)
		{
			db = context;
		}

		[HttpGet]
		public IEnumerable<AuditoriumType> Get()
		{
			return db.AuditoriumTypes.ToList();
		}

		[HttpGet("{id}")]
		public AuditoriumType Get(int id)
		{
			AuditoriumType auditoriumType = db.AuditoriumTypes.FirstOrDefault(x => x.Id == id);
			return auditoriumType;
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
