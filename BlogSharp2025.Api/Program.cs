
using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.SqlServer;

namespace BlogSharp2025.Api;

public class Program
{
    private const string _connectionString = "Data Source=.;Integrated Security=True;initial catalog=BlogSharp2025; trust server certificate=true";
    public static void Main(string[] args)
    {

         
    var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //Register the AuthorDao for MSSqlServer for dependency injection
        builder.Services.AddScoped<IAuthorDao>(
            (_) => new AuthorDao(_connectionString)            );

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
