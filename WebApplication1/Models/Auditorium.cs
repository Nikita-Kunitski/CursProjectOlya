using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	/// <summary>
	/// Аудитория
	/// </summary>
	public class Auditorium
	{
		public int Id { get; set; }

		public string AuditoriumNumber { get; set; }

		public int AuditoriumCapacity { get; set; }

		public int? AuditoriumTypeId { get; set; }

		public AuditoriumType AuditoriumType { get; set; }
	}
}