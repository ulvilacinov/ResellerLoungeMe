using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ResellerLoungeMe.Application.Interfaces;
using ResellerLoungeMe.Application.Services;
using ResellerLoungeMe.Application.Utilities;
using ResellerLoungeMe.Core.Configuration;
using ResellerLoungeMe.Core.Interfaces;
using ResellerLoungeMe.Infrastructure.Adapters;

namespace ResellerLoungeMe
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();

            var loungeMeServerSettings = Configuration.GetSection("LoungeMeServerSettings");
            services.Configure<LoungeMeServerSettings>(loungeMeServerSettings);
            
            services.AddScoped<IAirportAdapter, AirportAdapter>();
            services.AddScoped<ILoungeAdapter, LoungeAdapter>();
            services.AddScoped<ITicketAdapter, TicketAdapter>();

            services.AddScoped<IAirportService, AirportService>();
            services.AddScoped<ILoungeService, LoungeService>();
            services.AddScoped<ITicketService, TicketService>();            

            services.AddScoped<IActionInvoker, ActionInvoker>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (ctx, next) =>
            {
                await next();

                if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
                {
                    //Re-execute the request so the user gets the error page
                    string originalPath = ctx.Request.Path.Value;
                    ctx.Items["originalPath"] = originalPath;
                    ctx.Request.Path = "/Error/404";
                    await next();
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error/500");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Airport}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
