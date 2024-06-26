using System.Data.Common;
using MicroServ.Api.Models.Repositories;
using MicroServ.Api.Models.Services;
using Microsoft.Data.SqlClient;

namespace MicroServ.Api;

public class Program
{
    public static void Main(string[] args)
    {
        if(args.Length > 0)
        {
            foreach(string arg in args)
            {
                Console.WriteLine(arg);
            }
        }

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddTransient<DbConnection>(sp => new SqlConnection(args[0]));
        builder.Services.AddScoped<ITodoRepository, ITodoService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
            app.UseSwagger();
            app.UseSwaggerUI();
        //}

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
