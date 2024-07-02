using Guider.Application;
using Guider.Identity;
using Guider.Infrastructure;
using Guider.Infrastructure.Meeting;
using Guider.Persistence;
using Guider.WebApi.MIddlewares;
using Hangfire;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

namespace Guider.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            

            builder.Services.AddControllers();

            builder.Services.AddApplicationService(builder.Configuration)
                            .AddInfrastructureService(builder.Configuration)
                            .AddPersistanceService(builder.Configuration)
                            .AddIdentityServices(builder.Configuration);
            //builder.Services.AddSerilog((service, config) =>
            //{
            //    config.ReadFrom.Configuration(builder.Configuration)
            //          .ReadFrom.Services(service)
            //          .Enrich.FromLogContext()
            //          .WriteTo.MSSqlServer(connectionString: builder.Configuration.GetConnectionString("DevConnection"),
            //                               sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
            //                               {
            //                                   TableName = "Logs",
            //                                   AutoCreateSqlTable = true
            //                               }
            //                               )
            //          .WriteTo.Console();
            //});


            builder.Services.AddCors(
               options => options.AddPolicy(
                   "angularApp",
                   policy => policy.WithOrigins(builder.Configuration["AngularUrl"] ?? "http://localhost:4200/")
                .AllowAnyMethod()
                .SetIsOriginAllowed(policy => true)
                .AllowAnyHeader()
                .AllowCredentials()));

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
            app.UseStaticFiles();

            var staticPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(staticPath),
                RequestPath = "/wwwroot/Images"
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseSerilogRequestLogging();
            app.UseExceptionHandlerMiddleware();
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("angularApp");
            app.MapControllers();
            app.MapHub<MeetingHub>($"/{app.Configuration["MeetingHub:path"]}");
            app.UseHangfireDashboard();
            app.Run();
        }
    }
}
