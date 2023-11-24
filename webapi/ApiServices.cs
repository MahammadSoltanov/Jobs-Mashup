namespace webapi;

public static class ApiServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowReactFrontend", builder =>
            {
                builder.WithOrigins("https://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        return services;
    }

}
