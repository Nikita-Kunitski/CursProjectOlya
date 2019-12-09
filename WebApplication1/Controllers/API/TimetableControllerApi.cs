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
	public class TimetableControllerApi : Controller
	{
		ApplicationDbContext db;

		public TimetableControllerApi(ApplicationDbContext db)
		{
			this.db = db;
		}

		[Route("api/timtables")]
		[HttpGet]
		public IEnumerable<Timetable> Get(string speciality, string faculty, string group)
		{
			return db.Timetables.Include(p => p.Auditorium)
				.Include(p => p.Group)
				.Include(p => p.Numbersubjectofday)
				.Include(p => p.Subject)
				.Include(p => p.Teacher)
				.Include(p => p.Speciality)
				.Where(p => p.Speciality.SpecialityAbbreviation == speciality && p.Group.Code==group).ToList();
		}

		[Route("api/specialities")]
		[HttpGet]
		public IEnumerable<Speciality> GetSpeciality()
		{
			return db.Specialities.ToList();
		}

		[Route("api/groups")]
		[HttpGet]
		public IEnumerable<Group> GetGroup()
		{
			return db.Groups.Include(p => p.Speciality).ToList();
		}

		[Route("api/faculties")]
		[HttpGet]
		public IEnumerable<Faculty> Get()
		{
			return db.Faculties.ToList();
		}
	}
}
