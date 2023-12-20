// using namespace.Interfaces;
// using namespace.Services;

using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.AddScoped<NasaApodService>();

builder.Services.AddHttpClient(); // Agregar configuración básica de HttpClient
builder.Services.AddHttpClient<NasaApodService>(); // Agregar servicio concreto que utiliza HttpClient

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder
            .AllowAnyOrigin()  // Permitir cualquier origen
            .AllowAnyMethod()  // Permitir cualquier método (GET, POST, etc.)
            .AllowAnyHeader(); // Permitir cualquier encabezado
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
