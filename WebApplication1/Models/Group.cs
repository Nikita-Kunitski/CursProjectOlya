using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	/// <summary>
	/// Группа
	/// </summary>
	public class Group
	{
		public int Id { get; set; }

		public string Code { get; set; }

		public int? FacultyId { get; set; }

		public int? SpecialityId { get; set; }

		public Faculty Faculty { get; set; }

		public Speciality Speciality { get; set; }

		public int CountStudent { get; set; }
	}
}