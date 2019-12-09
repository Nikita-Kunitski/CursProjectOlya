using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	/// <summary>
	/// Тип аудитории
	/// </summary>
	public class AuditoriumType
	{
		public int Id { get; set; }

		[Display(Name = "Аббревиатура")]
		public string AuditoriumAbbreviation { get; set; }

		[Display(Name = "Полное наименование")]
		public string AuditoriumName { get; set; }
	}
}