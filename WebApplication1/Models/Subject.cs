using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	/// <summary>
	/// Предмет
	/// </summary>
	public class Subject
	{
		public int Id { get; set; }

		public string SubjectAbbreviation { get; set; }

		public string SubjectName { get; set; }
	}
}