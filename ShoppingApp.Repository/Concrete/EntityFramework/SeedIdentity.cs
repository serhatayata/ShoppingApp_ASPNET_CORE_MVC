using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Repository.Concrete.EntityFramework
{
    public class SeedIdentity
    {
        public static async Task CreateIdentityUsers(IServiceProvider serviceProvider,IConfiguration configuration)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var username = configuration["Data:AdminUser:username"];
            var email = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];

            var Nusername = configuration["Data:User:username"];
            var Nemail = configuration["Data:User:email"];
            var Npassword = configuration["Data:User:password"];
            var Nrole = configuration["Data:User:role"];

            if (await userManager.FindByNameAsync(username) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                ApplicationUser user = new ApplicationUser()
                {
                    UserName=username,
                    Email = email,
                    Name = "Serhat",
                    Surname = "Ayata"
                };
                
                IdentityResult result = await userManager.CreateAsync(user,password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
            if (await userManager.FindByNameAsync(Nusername) == null)
            {
                if (await roleManager.FindByNameAsync(Nrole) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(Nrole));
                }

                ApplicationUser user2 = new ApplicationUser()
                {
                    UserName = Nusername,
                    Email = Nemail,
                    Name = "Serhat",
                    Surname = "Ayata"
                };

                IdentityResult result2 = await userManager.CreateAsync(user2, Npassword);

                if (result2.Succeeded)
                {
                    await userManager.AddToRoleAsync(user2,Nrole);
                }
            }
        }
    }
}
