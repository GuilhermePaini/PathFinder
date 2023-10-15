using PathFinder.Services;
using PathFinder.Services.Impl;
using QuickGraph.Algorithms.Services;

internal class Program
{
    private static readonly string CORS_CONFIGURATION = "corsconfig";

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IPathFinderService, PathFinderService>();

        builder.Services.AddSingleton<IBuildApiDataService, BuildApiDataService>();
        builder.Services.AddSingleton<IBuildGraphService, BuildGraphService>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddHealthChecks();

        builder.Services.AddCors(o => o.AddPolicy(CORS_CONFIGURATION, builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(CORS_CONFIGURATION);
        app.UseHealthChecks("/status");

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}