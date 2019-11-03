using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	/// <summary>
	/// Преподаватель
	/// </summary>
	public class Teacher
	{
		public int Id { get; set; }

		public string FullName { get; set; }

		public int? PulpitId { get; set; }

		public Pulpit Pulpit { get; set; }
	}
}