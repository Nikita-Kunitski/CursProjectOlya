using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers.API
{
	[Route("api/faculties")]
	public class FacultiesControllerApi : Controller
	{
		ApplicationDbContext db;

		public FacultiesControllerApi(ApplicationDbContext db)
		{
			this.db = db;
		}

		public IEnumerable<Faculty> Get()
		{
			return db.Faculties.ToList();
		}
	}
}
