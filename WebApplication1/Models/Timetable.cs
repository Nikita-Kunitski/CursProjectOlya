using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	/// <summary>
	/// Расписание
	/// </summary>
	public class Timetable
	{
		public int Id { get; set; }

		public DayOfWeek DayOfWeek { get; set; }

		public TypeLesson TypeLesson { get; set; }

		public LessonNumber Numbersubjectofday { get; set; }

		public int? GroupId { get; set; }

		public int? AuditoriumId { get; set; }

		public int? TeacherId { get; set; }

		public int? SubjectId { get; set; }

		public int? NumbersubjectofdayId { get; set; }

		public int? SpecialityId { get; set; }

		public Speciality Speciality { get; set; }

		public Subject Subject { get; set; }

		public Teacher Teacher { get; set; }

		public Auditorium Auditorium { get; set; }

		public Group Group { get; set; }
	}
}