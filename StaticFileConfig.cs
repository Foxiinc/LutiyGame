using Microsoft.AspNetCore.Builder;

public static class StaticFileConfig
{
    public static void UseStaticFilesConfig(this IApplicationBuilder app)
    {
        app.UseStaticFiles(); // Enable serving static files
    }
}
