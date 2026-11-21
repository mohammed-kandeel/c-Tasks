using MVC_1.Middlewares;

namespace MVC_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //API
            //builder.Services.AddControllers(); 

            //Register services for Full MVC Framework [Controllers , Views , Razor pages , and more]
            //builder.Services.AddMvc();

            //Register the core MVC services 
            //builder.Services.AddMvcCore();

            //Razor
            //builder.Services.AddRazorPages();

            var app = builder.Build();

            // Middleware pipeline
            // Configure the HTTP request pipeline.
            //1] Exception handling middleware 

            app.UseMiddleware<RequestTimingMiddleware>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

                //Tell the browser to use HTTPS for future requests
                //2] HSTS --> HTTP STRICT TRANSPORT SECUIRTY
                app.UseHsts();
            }

            //3] Redirect any incoming http request to https
            app.UseHttpsRedirection();

            //4] Serve public assets / files [wwwroot]
            //app.UseStaticFiles();

            //5] Match the incoming url with the available endpoints/actions
            app.UseRouting();

            //6] Cross origin resource sharing
            //app.UseCors();

            //7] Identifies who the current user is [login] [JWT , COOKIES]
            //app.UseAuthentication();

            //8] Enable the app to read and write session data
            //app.UseSession();

            
            //Inline middleware [Custom middleware]
            //app.Use(async (context, next) =>
            //{
            //    //Before next [Request]
            //    Console.WriteLine($"Hello");
            //    //next
            //    await next(context);
            //    //After next [Response]
            //    Console.WriteLine($"Bye");
            //});


            //9] Authenticated user is allowed to access resource
            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
