using CRM.API.Middleware;
using CRM.Application;
using CRM.Infastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace CRM.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null); ;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<CRMDbContext>(options =>
            {
                options.UseInMemoryDatabase("CRMDatabaseName");
                //options.UseSqlServer("connection string");
            });

            //MassTransit
            builder.Services.AddMassTransit(busConfig =>
            {
                busConfig.SetKebabCaseEndpointNameFormatter();
                busConfig.AddConsumer(typeof(PricingAgreementConsumer));
                busConfig.UsingInMemory((context, config) =>
                {
                    config.ConfigureEndpoints(context);
                });
                //busConfig.UsingAzureServiceBus();
            });

            //MediatR
            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<CreateCustomerCommand>();
                config.RegisterServicesFromAssemblyContaining<GetProductsCommand>();
            });

            //DI
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton<IPIMService, PIMService>();
            builder.Services.AddSingleton<IExternalCRMService, ExternalCRMService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<AuthenticationMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
