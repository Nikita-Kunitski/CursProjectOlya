using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

		[Display(Name = "Аббревиатура")]
		public string FacultyAbbreviation { get; set; }

		[Display(Name = "Наименование")]
		public string FacultyName { get; set; }

		public ICollection<Speciality> Specialities { get; set; }
	}
}