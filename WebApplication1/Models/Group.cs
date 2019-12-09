using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	/// <summary>
	/// Группа
	/// </summary>
	public class Group
	{
		public int Id { get; set; }

		[Display(Name = "Код группы")]
		public string Code { get; set; }

		public int? FacultyId { get; set; }

		public int? SpecialityId { get; set; }

		[Display(Name = "Факультет")]
		public Faculty Faculty { get; set; }

		[Display(Name = "Специальность")]
		public Speciality Speciality { get; set; }

		[Display(Name = "Количество студентов")]
		public int CountStudent { get; set; }
	}
}