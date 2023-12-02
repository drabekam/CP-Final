using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(options => {
    options.UseSqlServer("Server=Envy; Database=FinalDB; Trusted_Connection=True; TrustServerCertificate=True");
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();


app.MapControllers();

app.Run();
