using WatchDog;
using WatchDog.src.Models;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddWatchDogServices(
    opt =>
    {
        opt.IsAutoClear = false;
        opt.SetExternalDbConnString = builder.Configuration.GetConnectionString("PostgreSQL_Connection");
        opt.DbDriverOption = WatchDog.src.Enums.WatchDogDbDriverEnum.PostgreSql;
    }
);

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

app.UseWatchDogExceptionLogger();
app.UseWatchDog(
    settings =>
    {
        settings.WatchPagePassword = "admin123";
        settings.WatchPageUsername = "monies@001";
    }
);

app.Run();
