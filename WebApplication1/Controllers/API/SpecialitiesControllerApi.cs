using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers.API
{
	[Route("api/specialities")]
	public class SpecialitiesControllerApi : Controller
	{
		ApplicationDbContext db;

		public SpecialitiesControllerApi(ApplicationDbContext db)
		{
			this.db = db;
		}

		[HttpGet]
		public IEnumerable<Speciality> Get()
		{
			return db.Specialities.ToList();
		}
	}
}
