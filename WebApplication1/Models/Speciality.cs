using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	/// <summary>
	/// Специальность
	/// </summary>
	public class Speciality
	{
		public int Id { get; set; }

		[Display(Name = "Код специальности")]
		public string Code { get; set; }

		[Display(Name = "Аббревиатура")]
		public string SpecialityAbbreviation { get; set; }

		[Display(Name = "Наименование")]
		public string SpecialityName { get; set; }

		public int? FacultyId { get; set; }

		[Display(Name = "Факультет")]
		public Faculty Faculty { get; set; }
	}
}