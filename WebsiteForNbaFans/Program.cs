using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using WebsiteForNbaFans.Helpers.Configuration;
using WebsiteForNbaFans.Models;
using WebsiteForNbaFans.Operations;
using WebsiteForNbaFans.Operations.Caching;
using WebsiteForNbaFans.Operations.RapidAPI;
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

            builder.Services.AddHttpClient();

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



            //builder.Services.AddDbContext<NbaWebContext>(options => options.UseSqlServer(connectionString));
            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped<IArticleOperation, ArticleOperation>();
            builder.Services.AddMemoryCache();
            builder.Services.AddSingleton<ICacher, Cacher>();
            builder.Services.AddHttpClient("RapidApiOperation", (serviceProvider, client) =>
            {
                var settings = serviceProvider.GetRequiredService<IOptions<Api>>().Value;

                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "bd1b6dbc0fmsh7127f53a0567a3fp186c00jsn4e252554a54b");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", settings.RapidHost);

                client.BaseAddress = new Uri($"https://{settings.RapidHost}");

            });

            builder.Services.AddScoped<IRapidApiOperation, RapidApiOperation>();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);

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