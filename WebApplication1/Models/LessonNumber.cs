using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	/// <summary>
	/// Номер занятия
	/// </summary>
	public class LessonNumber
	{
		public int Id { get; set; }
		[Display(Name = "Номер")]
		public int Number { get; set; }
		[Display(Name = "Начало")]
		public DateTime Begin { get; set; }
		[Display(Name = "Окончание")]
		public DateTime End { get; set; }
	}
}