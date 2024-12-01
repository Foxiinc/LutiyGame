using Microsoft.AspNetCore.Builder;  
using Microsoft.Extensions.DependencyInjection;  
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services; // Include the services namespace

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); // Add this line to register controller services
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IServersRepository, ServersRepository>(); // Register ServersRepository
builder.Services.AddScoped<UserService>(); // Register UserService
builder.Services.AddScoped<ServerService>(); // Register ServerService
builder.Services.AddScoped<UpdatedLeaderboardService>(); // Register LeaderboardService

var app = builder.Build();

app.MapControllers(); // Ensure the application uses controllers
app.UseStaticFilesConfig(); // Enable serving static files

app.Run();