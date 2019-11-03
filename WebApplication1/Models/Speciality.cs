using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	/// <summary>
	/// Специальность
	/// </summary>
	public class Speciality
	{
		public int Id { get; set; }

		public string Code { get; set; }

		public string SpecialityAbbreviation { get; set; }

		public string SpecialityName { get; set; }

		public int? FacultyId { get; set; }

		public Faculty Faculty { get; set; }
	}
}