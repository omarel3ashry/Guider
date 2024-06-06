
using Guider.Application;
using Guider.Persistence;
using Guider.WebApi.Hubs;
using Serilog;

namespace Guider.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSerilog((service, config) =>
            {
                config.ReadFrom.Configuration(builder.Configuration)
                      .ReadFrom.Services(service)
                      .Enrich.FromLogContext()
                      .WriteTo.MSSqlServer(connectionString: "Data Source=.;Initial Catalog=MyDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True",
                                           sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
                                           {
                                               TableName = "Logs",
                                               BatchPostingLimit = 5,
                                               AutoCreateSqlTable = true
                                           }

                                           )
                      .WriteTo.Console();
            });

            builder.Services.AddCors(
                 options => options.AddPolicy(
                     "client-side",
                     policy => policy.WithOrigins(builder.Configuration["ClientSideUrl"] ?? "http://localhost:4200")
             .AllowAnyMethod()
             .SetIsOriginAllowed(pol => true)
             .AllowAnyHeader()
             .AllowCredentials()));

            builder.Services.AddSignalR();

            builder.Services.AddControllers();

            builder.Services.AddApplicationService()
                            .AddPersistanceService(builder.Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("client-side");
            app.MapControllers();
            app.MapHub<MeetingHub>("/meetingHub");

            app.Run();
        }
    }
}
