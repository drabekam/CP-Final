using Microsoft.EntityFrameworkCore;
using CP_Final.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// making the dbcontext use local host to use local SQL Server
builder.Services.AddDbContext<DBContext>(options =>
{
    //connections string
    options.UseSqlServer("Server=localhost; Database=FinalDB; Trusted_Connection=True;");
});

// Register the Swagger services
builder.Services.AddOpenApiDocument(configure =>
{
    configure.Title = "Your API";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseOpenApi(); // Serves the registered OpenAPI/Swagger documents
app.UseSwaggerUi3(); // Serves the Swagger UI 3 web frontend

app.UseAuthorization();
app.MapControllers();

app.Run();
