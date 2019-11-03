using System;
using System.Collections.Generic;
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

		public string PulpitName { get; set; }

		public ICollection<Teacher> Teachers { get; set; }
	}
}