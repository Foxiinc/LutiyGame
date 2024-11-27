using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

public class LeaderboardMiddleware
{
    private readonly RequestDelegate _next;

    public LeaderboardMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/api/users"))
        {
            context.Response.OnStarting(() =>
            {
                var users = context.Items["Users"] as List<Users>;
                if (users != null)
                {
                    var sortedUsers = users.OrderByDescending(u => u.CountSphere).ToList();
                    context.Items["SortedUsers"] = sortedUsers;
                }
                return Task.CompletedTask;
            });
        }

        await _next(context);
    }
}