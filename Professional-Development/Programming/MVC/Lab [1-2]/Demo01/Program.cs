using ITIEntities;
using ITIEntities.Data;
using ITIEntities.Repo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace Demo01;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        //builder.Services.AddScoped<IEntityRepo<Department>, EntityRepo<Department>>();
        //builder.Services.AddScoped<IEntityRepo<Student>, EntityRepo<Student>>();
        //builder.Services.AddScoped<IEntityRepo<Course>, EntityRepo<Course>>();
        builder.Services.AddScoped<StudentCourseRepo, StudentCourseRepo>();
        builder.Services.AddScoped<ITIContext, ITIContext>();
        builder.Services.AddIdentity<IdentityUser, IdentityRole>(s =>
        {
            s.SignIn.RequireConfirmedEmail = false;
            //s.Password.RequireUppercase = false;
            //s.Password.RequireLowercase = false;
        }).AddEntityFrameworkStores<ITIContext>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection(); // redirect form http tp https
        app.UseStaticFiles(); // if need only static files return directly don't go to any controllers

        app.UseRouting();// extract(Controller, Action) from the request 

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

       
        app.Run();
    }
}
