using DefenseSim.Data;
using DefenseSim.Data.Service;
using Microsoft.EntityFrameworkCore;
namespace DefenseSim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AttackDbContext>(option => option.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnectionString")));

            builder.Services.AddDbContext<DefenseDbContext>(option => option.UseSqlServer(
                builder.Configuration.GetConnectionString("DefenseConnectionString")));

            builder.Services.AddScoped<IAttackService, AttackService>();
            builder.Services.AddScoped<IDefenseService, DefenseService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Threats}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
