using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();
            //dot per line 
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR")
                    .AddSupportedUICultures("tr-TR")
                    .SetDefaultCulture("tr-TR");
                //zaten türkçe tl işareti geliyordu ama bu fena bir bilgi değilmiş
                //çıtır gereksiz geldi



            });
        }
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123456";
            //Usermanager
            UserManager<IdentityUser> userManager = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();


            //Rolemanager
            RoleManager<IdentityRole> roleManager = app
                .ApplicationServices
                .CreateAsyncScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if (user is null)
            {
                user = new IdentityUser(adminUser)
                {
                    Email = "orkunözdemir@ankara.edu.tr",
                    PhoneNumber = "12354687945",
                    UserName = adminUser,
                    // EmailConfirmed = true,
                };

                var result = await userManager.CreateAsync(user, adminPassword);
                //saveledik
                if (!result.Succeeded)
                {
                    throw new Exception("Admin user could not created");
                }
                var roleResult = await userManager.AddToRolesAsync(user,
                    //new List<string>()
                    //{
                    //    "Admin",
                    //    "Editor",
                    //    "User"
                    //}
                    roleManager
                    .Roles
                    .Select(r => r.Name).ToList()
                    );
                if (!roleResult.Succeeded)
                {
                    throw new Exception("System Have problems with role definition for admin.");
                }
// bu sarı yanan ifadeler rahatsız edici geldi bana

            }

        }

    }
}
