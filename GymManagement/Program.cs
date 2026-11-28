using GymManagement.Context;
using GymManagement.Repositories.Classes;
using GymManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace GymManagement;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();


        //register service in DI container
        builder.Services.AddDbContext<GymDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //options.UseSqlServer(builder.Configuration.GetSection("GetConnectionString")["DefaultConnection"]);
            //options.UseSqlServer(builder.Configuration["GetConnectionString:DefaultConnection"]);
        });

        // 
        builder.Services.AddScoped<IplanRepositiory, planRepositiory>();
        builder.Services.AddScoped<IMemberShipRepositiory, MemberShipRepositiory>();

        //builder.Services.AddSingleton<IplanRepositiory, planRepositiory>();

        //builder.Services.AddTransient<IplanRepositiory, planRepositiory>();
        /*
        1]  AddSingleton
        --> Ask Clr to create one instance per application
        --> All requests share the same instance

        2] AddScoped
        --> Ask Clr to create one instance per HTTP request
        --> services within the same request share the same instance

        3] AddTransient
        --> Ask CLR to create a new instance every time the service is requested
        */

        /*
         - Singelton service can not depend on scoped service [Liftetime mismatch]
         - Scoped service can depend on singelton service

         - Singeltion -> Singelton
         - Singelton -> Not allowed -> Scoped
         - Scoped -> Scoped
         - Scoped -> allowed -> Singelton
         */



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.Run();
    }
}
