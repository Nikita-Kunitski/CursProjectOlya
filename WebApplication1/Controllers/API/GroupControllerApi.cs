using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers.API
{
	[Route("api/groups")]
	public class GroupControllerApi:Controller
	{
		ApplicationDbContext db;

		public GroupControllerApi(ApplicationDbContext db)
		{
			this.db = db;
		}

		public IEnumerable<Group> Get()
		{
			return db.Groups.Include(p=>p.Speciality).ToList();
		}
	}
}
