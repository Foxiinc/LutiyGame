using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Добавьте контекст базы данных
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Пример получения пользователей
app.MapGet("/users", async (MyDbContext db) =>
{
#pragma warning disable CS8604 // Possible null reference argument.
    return await db.Users.ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
});

app.Run();