using Exercice04.Data;
using Exercice04.Models;
using Exercice04.Repositories;
using Exercice04.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<AnimalFakeDb>();


// méthodes à utiliser pour enregistrer un db context et pouvoir utiliser efcore

// - dans le cas où on utilise OnConfiguring pour le ConnectionString
// builder.Services.AddDbContext<ApplicationDbContext>();

// dans le cas où on utilise le fichier appsettings.json pour le ConnectionString
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddScoped<AnimalRepository>();

builder.Services.AddScoped<IRepository<Animal>, AnimalRepository>();
//builder.Services.AddScoped<IRepository<Animal>, AnimalFakeDb>();

builder.Services.AddScoped<IUploadService, UploadService>();

// Ajout du service Session
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Utilisation du MiddleWare Session (/!\  l'ordre des middleware a un impact)
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Animal}/{action=Index}/{id?}");

app.Run();
