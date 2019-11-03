using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	/// <summary>
	/// Факультет
	/// </summary>
	public class Faculty
	{
		public Faculty()
		{
			Specialities = new List<Speciality>();
		}

		public int Id { get; set; }

		public string FacultyAbbreviation { get; set; }

		public string FacultyName { get; set; }

		public ICollection<Speciality> Specialities { get; set; }
	}
}