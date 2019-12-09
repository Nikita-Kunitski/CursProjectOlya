using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	/// <summary>
	/// Преподаватель
	/// </summary>
	public class Teacher
	{
		public int Id { get; set; }

		[Display(Name = "Полное имя")]
		public string FullName { get; set; }

		public int? PulpitId { get; set; }

		[Display(Name = "Кафедра")]
		public Pulpit Pulpit { get; set; }
	}
}