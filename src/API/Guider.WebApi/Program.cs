
using Guider.Application;
using Guider.Persistence;
using Serilog;

namespace Guider.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
           builder.Services.AddSerilog((service, config) =>
           {
               config.ReadFrom.Configuration(builder.Configuration)
                     .ReadFrom.Services(service)
                     .Enrich.FromLogContext()
                     //.WriteTo.MSSqlServer(connectionString: "Data Source=.;Initial Catalog=MyDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True",
                     //                     sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
                     //                     {
                     //                         TableName = "Logs",
                     //                         BatchPostingLimit = 5,
                     //                         AutoCreateSqlTable = true
                     //                     }

                     //                     )
                     .WriteTo.Console();
           });


            builder.Services.AddControllers();

            builder.Services.AddApplicationService()
                            .AddPersistanceService(builder.Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();
            app.UseDeveloperExceptionPage();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
