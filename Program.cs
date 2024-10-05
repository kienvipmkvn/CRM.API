
using CommonService;
using CRMDbContext;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace CRM.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<CRMContext>(options =>
            {
                options.UseInMemoryDatabase("CRMDatabaseName");
                //options.UseSqlServer("connection string");
            });

            builder.Services.AddMassTransit(busConfig =>
            {
                busConfig.SetKebabCaseEndpointNameFormatter();
                busConfig.AddConsumers(typeof(Program).Assembly);
                busConfig.UsingInMemory((context, config) =>
                {
                    config.ConfigureEndpoints(context);
                });
                //busConfig.UsingAzureServiceBus();
            });

            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });

            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton<IPIMService, PIMService>();
            builder.Services.AddSingleton<ICRMService, CRMService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
