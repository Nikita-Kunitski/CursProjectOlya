
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	/// <summary>
	/// Предмет
	/// </summary>
	public class Subject
	{
		public int Id { get; set; }

		[Display(Name = "Аббревиатура")]
		public string SubjectAbbreviation { get; set; }

		[Display(Name = "Наименование")]
		public string SubjectName { get; set; }
	}
}