using Microsoft.AspNetCore.Authentication.Cookies;

namespace Mobilya_Sitesi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/Login/Index";
            });
            builder.Services.AddHttpClient();
          
          

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                );
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Home}/{id?}");

            app.Run();
        }
    }
}
