using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	/// <summary>
	/// Номер занятия
	/// </summary>
	public class LessonNumber
	{
		public int Id { get; set; }
		public int Number { get; set; }
		public DateTime Begin { get; set; }
		public DateTime End { get; set; }
	}
}