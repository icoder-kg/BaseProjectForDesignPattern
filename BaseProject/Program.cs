using BaseProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace BaseProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var identityDbContext = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            identityDbContext.Database.Migrate();
            if (!userManager.Users.Any())
            {
                userManager.CreateAsync(new AppUser() { UserName = "User1", Email = "user1@outlook.com" }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "User2", Email = "user2@outlook.com" }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "User3", Email = "user3@outlook.com" }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "User4", Email = "user4@outlook.com" }, "Password12*").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "User5", Email = "user6@outlook.com" }, "Password12*").Wait();
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}