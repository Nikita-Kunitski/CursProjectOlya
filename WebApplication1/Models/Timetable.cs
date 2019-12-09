using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
	/// <summary>
	/// Расписание
	/// </summary>
	public class Timetable
	{
		public int Id { get; set; }

		[Display(Name = "День недели")]
		public DayOfWeek DayOfWeek { get; set; }

		[Display(Name = "Тип занятия")]
		public TypeLesson TypeLesson { get; set; }

		[Display(Name = "Номер пары")]
		public LessonNumber Numbersubjectofday { get; set; }

		public int? GroupId { get; set; }

		public int? AuditoriumId { get; set; }

		public int? TeacherId { get; set; }

		public int? SubjectId { get; set; }

		public int? NumbersubjectofdayId { get; set; }

		public int? SpecialityId { get; set; }

		[Display(Name = "Спецтальность")]
		public Speciality Speciality { get; set; }

		[Display(Name = "Предмет")]
		public Subject Subject { get; set; }

		[Display(Name = "Преподаватель")]
		public Teacher Teacher { get; set; }

		[Display(Name = "Аудитория")]
		public Auditorium Auditorium { get; set; }

		[Display(Name = "Группа")]
		public Group Group { get; set; }
	}
}