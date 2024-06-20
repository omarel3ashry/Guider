
using Guider.Application;
using Guider.Identity;
using Guider.Persistence;
using Guider.WebApi.MIddlewares;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Guider.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddSerilog((service, config) =>
            //{
            //    config.ReadFrom.Configuration(builder.Configuration)
            //          .ReadFrom.Services(service)
            //          .Enrich.FromLogContext()
            //          .WriteTo.MSSqlServer(connectionString: "Data Source=.;Initial Catalog=MyDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True",
            //                               sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
            //                               {
            //                                   TableName = "Logs",
            //                                   BatchPostingLimit = 5,
            //                                   AutoCreateSqlTable = true
            //                               }

            //                               )
            //          .WriteTo.Console();
            //});
            

            builder.Services.AddControllers();

            builder.Services.AddApplicationService()
                            .AddPersistanceService(builder.Configuration)
                            .AddAddIdentityServices(builder.Configuration);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                        },
                        new string[]{ }
                    }
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseSerilogRequestLogging();
            app.UseExceptionHandlerMiddleware();
            app.UseHttpsRedirection();
            app.UseCors("AllowAllOrigins");
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
