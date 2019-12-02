using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;

namespace WebApplication1.Data
{
	public class DataInitializer
	{
		public static async Task InitializeAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager)
		{
			string adminEmail = "admin@gmail.com";
			string password = "1234Qwerty.";
			if (await roleManager.FindByNameAsync("admin") == null)
			{
				await roleManager.CreateAsync(new IdentityRole("admin"));
			}

			if (await roleManager.FindByNameAsync("teacher") == null)
			{
				await roleManager.CreateAsync(new IdentityRole("teacher"));
			}

			if (await roleManager.FindByNameAsync("nonConfrimedTeacher") == null)
			{
				await roleManager.CreateAsync(new IdentityRole("nonConfrimedTeacher"));
			}
			
			#region Типы аудиторий

			List<AuditoriumType> auditoriumTypes = new List<AuditoriumType>();
			AuditoriumType auditoriumType1= new AuditoriumType() { AuditoriumName = "Лекционная", AuditoriumAbbreviation = "ЛК" };
			AuditoriumType auditoriumType2 = new AuditoriumType()
				{AuditoriumName = "Лаборатория", AuditoriumAbbreviation = "ЛБ"};
			auditoriumTypes.Add(auditoriumType1);
			auditoriumTypes.Add(auditoriumType2);
			if (!context.AuditoriumTypes.Any())
			{
				context.AuditoriumTypes.AddRange(auditoriumTypes.ToArray());
			}

			#endregion

			#region Аудитории

			List<Auditorium> auditoria = new List<Auditorium>();
			auditoria.Add(new Auditorium()
			{
				AuditoriumNumber = "101-3а",
				AuditoriumCapacity = 100,
				AuditoriumTypeId = auditoriumType1.Id,
				AuditoriumType = auditoriumType1
			});
			auditoria.Add(new Auditorium()
			{
				AuditoriumNumber = "420-4",
				AuditoriumCapacity = 50,
				AuditoriumTypeId = auditoriumType2.Id,
				AuditoriumType = auditoriumType2
			});
			auditoria.Add(new Auditorium()
			{
				AuditoriumNumber = "220-4",
				AuditoriumCapacity = 65,
				AuditoriumTypeId = auditoriumType2.Id,
				AuditoriumType = auditoriumType2
			});

			if (!context.Auditoriums.Any())
			{
				context.Auditoriums.AddRange(auditoria.ToArray());
			}

			#endregion

			#region Кафедра

			List<Pulpit> pulpits = new List<Pulpit>();
			pulpits.Add(new Pulpit() { PulpitAbbreviation = "ИСиТ", PulpitName = "Информационные системы и технологии" });
			pulpits.Add(new Pulpit() { PulpitAbbreviation = "ДЭВи", PulpitName = "Дизайн электронных веб-изданий" });
			pulpits.Add(new Pulpit() { PulpitAbbreviation = "ВМ", PulpitName = "Высшей математики" });
			pulpits.Add(new Pulpit() { PulpitAbbreviation = "ПОИТ", PulpitName = "Программное обеспечение информационных технологий" });
			if (!context.Pulpits.Any())
			{
				context.Pulpits.AddRange(pulpits.ToArray());
			}

			#endregion

			#region Факультет

			List<Faculty> faculties = new List<Faculty>();
			faculties.Add(new Faculty(){FacultyAbbreviation="ФИТ", FacultyName="Факультет информационных технологий"});
			faculties.Add(new Faculty() { FacultyAbbreviation = "ИЭФ", FacultyName = "Инженерно-экономический факультет" });
			faculties.Add(new Faculty() { FacultyAbbreviation = "ТОВ", FacultyName = "Факультет теории органических веществ" });
			faculties.Add(new Faculty() { FacultyAbbreviation = "ЛХ", FacultyName = "Факультет лесного хозяйства" });
			if (!context.Faculties.Any());
			{
				context.Faculties.AddRange(faculties.ToArray());
			}

			#endregion

			#region Специальность

			List<Speciality> specialities = new List<Speciality>();
			specialities.Add(new Speciality()
			{
				Code = "1-23-65-800",
				SpecialityAbbreviation = "ИСиТ",
				SpecialityName = "Информационные системы и технологии",
				FacultyId = faculties[0].Id,
				Faculty = faculties[0]
			});
			specialities.Add(new Speciality()
			{
				Code = "2-45-20-210",
				SpecialityAbbreviation = "ПОИТ",
				SpecialityName = "Программное обеспечение информационных технологий",
				FacultyId = faculties[0].Id,
				Faculty = faculties[0]
			});
			specialities.Add(new Speciality()
			{
				Code = "21-3-65-50",
				SpecialityAbbreviation = "БТ",
				SpecialityName = "Био-технологии",
				FacultyId = faculties[2].Id,
				Faculty = faculties[2]
			});
			if (!context.Specialities.Any())
			{
				context.Specialities.AddRange(specialities.ToArray());
			}

			#endregion

			#region Группы

			List<Group> groups = new List<Group>();
			groups.Add(new Group()
			{
				Code = "1",
				FacultyId = faculties[0].Id,
				Faculty = faculties[0],
				SpecialityId = specialities[0].Id,
				Speciality = specialities[0],
				CountStudent = 15
			});
			groups.Add(new Group()
			{
				Code = "2",
				FacultyId = faculties[0].Id,
				Faculty = faculties[0],
				SpecialityId = specialities[0].Id,
				Speciality = specialities[0],
				CountStudent = 15
			});
			groups.Add(new Group()
			{
				Code = "4",
				FacultyId = faculties[0].Id,
				Faculty = faculties[0],
				SpecialityId = specialities[1].Id,
				Speciality = specialities[1],
				CountStudent = 23
			});
			groups.Add(new Group()
			{
				Code = "5",
				FacultyId = faculties[0].Id,
				Faculty = faculties[0],
				SpecialityId = specialities[1].Id,
				Speciality = specialities[1],
				CountStudent = 25
			});

			if (!context.Groups.Any())
			{
				context.Groups.AddRange(groups.ToArray());
			}

			#endregion

			#region Предмет

			List<Subject> subjects = new List<Subject>();
			subjects.Add(new Subject(){SubjectAbbreviation="ВМ", SubjectName="Высшая математика"});
			subjects.Add(new Subject() { SubjectAbbreviation = "ОАиП", SubjectName = "Основы алгоритмизации и программирования" });
			subjects.Add(new Subject() { SubjectAbbreviation = "Физ. Культ.", SubjectName = "Физическая культура" });
			subjects.Add(new Subject() { SubjectAbbreviation = "Фил.", SubjectName = "Философия" });
			subjects.Add(new Subject() { SubjectAbbreviation = "БД", SubjectName = "Базы данных" });
			subjects.Add(new Subject() { SubjectAbbreviation = "ИГ", SubjectName = "Инженерная графика" });
			subjects.Add(new Subject() { SubjectAbbreviation = "ОИТ", SubjectName = "Основы информационных технологий" });
			if (!context.Subjects.Any())
			{
				context.Subjects.AddRange(subjects.ToArray());
			}

			#endregion

			#region Преподаватели

			List<Teacher> teachers = new List<Teacher>();
			teachers.Add(new Teacher() { FullName="Асмыкович И. К.", PulpitId=pulpits[2].Id, Pulpit=pulpits[2]});
			teachers.Add(new Teacher() { FullName = "Романенко Д. М.", PulpitId = pulpits[1].Id, Pulpit = pulpits[1] });
			teachers.Add(new Teacher() { FullName = "Буснюк Н. Н.", PulpitId = pulpits[0].Id, Pulpit = pulpits[0] });
			teachers.Add(new Teacher() { FullName = "Пацей Н. В.", PulpitId = pulpits[3].Id, Pulpit = pulpits[3] });
			teachers.Add(new Teacher() { FullName = "Олеферович А. В.", PulpitId = pulpits[0].Id, Pulpit = pulpits[0] });
			if (!context.Teachers.Any())
			{
				context.Teachers.AddRange(teachers.ToArray());
			}

			#endregion

			#region Времена пар

			List<LessonNumber> list = new List<LessonNumber>();
			list.Add(new LessonNumber() { Number = 1,
				Begin = new DateTime(year: DateTime.Today.Year, month: DateTime.Today.Month, day: DateTime.Today.Day, hour: 8, minute: 00, second: 0),
				End = new DateTime(year: DateTime.Today.Year, month: DateTime.Today.Month, day: DateTime.Today.Day, hour: 08, minute: 00, second: 0) });
			list.Add(new LessonNumber() { Number = 2,
				Begin = new DateTime(year: DateTime.Today.Year, month: DateTime.Today.Month, day: DateTime.Today.Day, hour: 9, minute: 50, second: 0),
				End = new DateTime(year: DateTime.Today.Year, month: DateTime.Today.Month, day: DateTime.Today.Day, hour: 11, minute: 25, second: 0) });
			list.Add(new LessonNumber() { Number = 3,
				Begin = new DateTime(year: DateTime.Today.Year, month: DateTime.Today.Month, day: DateTime.Today.Day, hour: 11, minute: 40, second: 0),
				End = new DateTime(year: DateTime.Today.Year, month: DateTime.Today.Month, day: DateTime.Today.Day, hour: 13, minute: 15, second: 0) });
			list.Add(new LessonNumber() { Number = 4,
				Begin = new DateTime(year: DateTime.Today.Year, month: DateTime.Today.Month, day: DateTime.Today.Day, hour: 13, minute: 50, second: 0),
				End = new DateTime(year: DateTime.Today.Year, month: DateTime.Today.Month, day: DateTime.Today.Day, hour: 15, minute: 25, second: 0) });
			list.Add(new LessonNumber() { Number = 5,
				Begin = new DateTime(year: DateTime.Today.Year, month: DateTime.Today.Month, day: DateTime.Today.Day, hour: 15, minute: 40, second: 0),
				End = new DateTime(year: DateTime.Today.Year, month: DateTime.Today.Month, day: DateTime.Today.Day, hour: 17, minute: 15, second: 0) });
			list.Add(new LessonNumber() { Number = 6,
				Begin = new DateTime(year: DateTime.Today.Year, month: DateTime.Today.Month, day: DateTime.Today.Day, hour: 17, minute: 30, second: 0),
				End = new DateTime(year: DateTime.Today.Year, month: DateTime.Today.Month, day: DateTime.Today.Day, hour: 19, minute: 05, second: 0) });
			list.Add(new LessonNumber() { Number = 7,
				Begin = new DateTime(year: DateTime.Today.Year, month: DateTime.Today.Month, day: DateTime.Today.Day, hour: 19, minute: 20, second: 0),
				End = new DateTime(year: DateTime.Today.Year, month: DateTime.Today.Month, day: DateTime.Today.Day, hour: 20, minute: 55, second: 0) });
			if (!context.LessonNumbers.Any())
			{
				context.LessonNumbers.AddRange(list.ToArray());
			}
			#endregion

			context.SaveChanges();

			if (await userManager.FindByNameAsync(adminEmail) == null)
			{
				ApplicationUser admin = new ApplicationUser { Email = adminEmail, UserName = adminEmail };
				IdentityResult result = await userManager.CreateAsync(admin, password);
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(admin, "admin");
				}
			}
			
		}
	}
}
