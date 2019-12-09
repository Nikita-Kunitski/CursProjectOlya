using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	/// <summary>
	/// Аудитория
	/// </summary>
	public class Auditorium
	{
		public int Id { get; set; }

		[Display(Name ="Номер аудитории")]
		public string AuditoriumNumber { get; set; }

		[Display(Name = "Объем аудитории")]
		public int AuditoriumCapacity { get; set; }

		public int? AuditoriumTypeId { get; set; }

		[Display(Name = "Тип аудитории")]
		public AuditoriumType AuditoriumType { get; set; }
	}
}