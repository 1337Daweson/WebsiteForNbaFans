using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebsiteForNbaFans.Helpers.Configuration;
using WebsiteForNbaFans.Models;
using WebsiteForNbaFans.Operations;
using WebsiteForNbaFans.Repositories;

namespace WebsiteForNbaFans
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);


            builder.Configuration.SetBasePath(System.AppContext.BaseDirectory).AddJsonFile("appsettings.json");
            builder.Services.Configure<Api>(builder.Configuration.GetSection("Api"));

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp";
            });
            builder.Services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DbContext
            var connectionString = builder.Configuration.GetConnectionString("NbaWeb");



            builder.Services.AddDbContext<NbaWebContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ITeamOperation, TeamOperation>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.MapControllers();
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client-app";
                if (app.Environment.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:5173");
                }
            });



            app.Run();
        }
    }
}