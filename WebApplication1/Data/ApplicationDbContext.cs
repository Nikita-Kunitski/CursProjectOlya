using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<Auditorium> Auditoriums { get; set; }
		public DbSet<AuditoriumType> AuditoriumTypes { get; set; }
		public DbSet<Faculty> Faculties { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<LessonNumber> LessonNumbers { get; set; }
		public DbSet<Pulpit> Pulpits { get; set; }
		public DbSet<Speciality> Specialities { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Timetable> Timetables { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
