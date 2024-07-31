using Demo01.Data;

// builder => sert à construire et configurer l'application
var builder = WebApplication.CreateBuilder(args);

// Ajout de services.
// Des classes qui donnent des fonctionnalités réutilisables dans l'application
// Ex : pour la BDD, pour EfCore, Repositories, Controllers, FakeDb ...
// Elles vont être ENREGISTREES dans le CONTENEUR DE DEPNEDANCES
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<FakeContactDb>(); // Ne pas oublier sinon l'injection de dépendances de ce service ne fontionne pas

var app = builder.Build(); //méthode qui passe d'une application "en construction" à une application prête

// Ajout de Middlewares et configuration post build

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ajout de la configuration de la route par défaut (default)
// elle définit un pattern de base pour l'accès à nos controllers => /Home/Privacy
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ajout d'une 2e configuration avec une route "/test" qui redirige vers Privacy
app.MapControllerRoute(
    name: "customRoute",
    pattern: "test", 
    new
    {
        Controller = "Home",
        Action = "Privacy"
    });

app.Run();
