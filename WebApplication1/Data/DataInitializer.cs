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
		public static async Task InitializeAsync(UserManager<ApplicationUser> userManager,
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
