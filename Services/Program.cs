using PathFinder.Services;
using PathFinder.Services.Impl;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IPathFinderService, PathFinderService>();

        builder.Services.AddSingleton<IBuildApiDataService, BuildApiDataService>();
        builder.Services.AddSingleton<IBuildGraphService, BuildGraphService>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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