using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	/// <summary>
	/// Кафедра
	/// </summary>
	public class Pulpit
	{
		public Pulpit()
		{
			Teachers = new List<Teacher>();
		}

		public int Id { get; set; }

		[Display(Name = "Аббревиатура")]
		public string PulpitAbbreviation { get; set; }

		[Display(Name = "Наименование")]
		public string PulpitName { get; set; }

		public ICollection<Teacher> Teachers { get; set; }
	}
}