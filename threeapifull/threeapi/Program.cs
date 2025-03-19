using THREEAPI.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<CovidService>();
builder.Services.AddScoped<CryptoService>();
builder.Services.AddScoped<MovieService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000")
                .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors();
app.MapGet("/", () => "Welcome to the 3Apisystem");

app.UseRouting();
app.MapControllers();

app.Run();
