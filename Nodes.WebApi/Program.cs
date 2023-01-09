using System.Reflection;
using AutoMapper;
using System.Xml.Linq;
using Notes.Application.Common.Mappings;
using Notes.Application.Interfaces;
using Notes.Application;
using Notes.Persistence;
using Nodes.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// добавление AutoMapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemplyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemplyMappingProfile(typeof(INotesDbContext).Assembly));
});


// добавление сервиса из Application
builder.Services.AddApplication();

// добавление сервиса Persistence (котекст с базой)
builder.Services.AddPersistence(builder.Configuration);

// добавление контроллеров
builder.Services.AddControllers();

// добавление корса
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});


using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<NotesDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        Console.Write(ex.ToString());
    }
}


var app = builder.Build();

app.UseCustomExceptionHandler();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//app.MapGet("/", () => "Hello World!");

app.Run();

