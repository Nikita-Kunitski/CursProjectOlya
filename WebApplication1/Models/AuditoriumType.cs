using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	/// <summary>
	/// Тип аудитории
	/// </summary>
	public class AuditoriumType
	{
		public int Id { get; set; }

		public string AuditoriumAbbreviation { get; set; }

		public string AuditoriumName { get; set; }
	}
}