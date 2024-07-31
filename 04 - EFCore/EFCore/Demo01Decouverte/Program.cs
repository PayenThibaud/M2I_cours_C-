
using Demo01Decouverte;
using Demo01Decouverte.Data;

using var context = new DecouverteDbContext();

var monLivre = new Livre()
{
    Titre = "Les fleurs du mal",
    Auteur = "Charles Baudelaire",
    DatePublication = new DateTime(1857, 06, 21),
    Description = "Un livre qu'il est rempli de poèmes"
};

// CREATE

//// Prépraration de la requête SQL
//context.Livres.Add(monLivre);
//// Exécute les modifications qui ont été effectuées
//context.SaveChanges();

// READ

// Lire un enregistrement
var result = context.Livres.FirstOrDefault(l => l.Titre.StartsWith("Clean"));
Console.WriteLine(result?.Titre);

// Afficher tous les livres
context.Livres.ToList().ForEach(l => Console.WriteLine(l.Auteur));

// ces deux lignes sont équivalentes
var livre = context.Livres.Find(1);
livre = context.Livres.FirstOrDefault(l => l.Id == 1);

// Récupérer une liste d'éléments avec un filtre
var vieuxLivres = context.Livres.Where(l => l.DatePublication < new DateTime(1900, 1, 1)).ToList();
vieuxLivres.ForEach(l => Console.WriteLine($"{l.DatePublication:d}"));

//// UPDATE 
//livre.Titre = "Clean Code";
//context.Livres.Update(livre);
//context.SaveChanges();


//// DELETE
var fleursDuMal = context.Livres.Find(3);
context.Livres.Remove(fleursDuMal);
context.SaveChanges();

Console.ReadKey();