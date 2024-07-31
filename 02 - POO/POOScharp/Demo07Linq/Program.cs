using Demo07Linq;

var mesNombres = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var mesNombresAuCarre = Enumerable.Range(1, 10).Select(n => n * n);

foreach (var n in mesNombres)
{
    Console.WriteLine(n);
}

Console.WriteLine("\n=====\n");

foreach (var n in mesNombresAuCarre)
{
    Console.WriteLine(n);
}

string maChaine = "john dupont";
Console.WriteLine(maChaine.ToUpper());
Console.WriteLine(maChaine.ToLower());

//string ToCapitalized(string value)
//{
//    string returnValue = "";
//    foreach (var mot in value.Split(" "))
//    {
//        returnValue += mot.Substring(0, 1).ToUpper() + mot.Substring(1).ToLower(); 
//    }
//    return returnValue;
//}

Console.WriteLine(maChaine.ToCapitalized());

int nbA = 24;

int somme = nbA.Add(10);

List<int> nombresPairs = new();

foreach(int n in mesNombres)
{
    if (n % 2 == 0) nombresPairs.Add(n);
}

var lesNombresPairs = mesNombres.Where(x => x % 2 == 0).ToDictionary(x => x.ToString());

List<Personne> mesPersonnes = new()
{
    new() { Nom = "DUPONT", Prenom = "John", Age = 47, Email = "j.dupont@gmail.com", Phone = "+33 147 741 256"},
    new() { Nom = "SCHMIT", Prenom = "Martha", Age = 29, Email = "m.schmit@hotmail.com", Phone = "+33 159 236 478"},
    new() { Nom = "DUPONT", Prenom = "Chloée", Age = 16, Email = "c.dupont@gmail.com", Phone = "+33 125 896 478"},
    new() { Nom = "MARTEZ", Prenom = "Clark", Age = 47, Email = "c.martez@aol.com", Phone = "+32 147 852 369"}
};

// Pour trouver un élément dans une collection, on peut utiliser la fonction 
Personne? chloee = mesPersonnes.Find(x => x.Prenom == "Chloée");


// Mais avec Linq, on peut optimiser la chose via trois méthodes possédant chacune une variante retournant la valeur par défaut en cas de condition non remplies ou de non trouvaille

// On peut chercher dans le listing à partir du début
Personne chloeeAvecLinq = mesPersonnes.First(x => x.Prenom == "Chloée");
Personne chloeeAvecLinqSecurise = mesPersonnes.FirstOrDefault(x => x.Prenom == "Chloée") ?? new() { Nom = "DUPONT", Prenom = "Chloée" };

// A partir de la fin
Personne chloeeAPartirDeLaFin = mesPersonnes.Last(x => x.Prenom == "Chloée");
Personne chloeeAPartirDeLaFinSecurise = mesPersonnes.LastOrDefault(x => x.Prenom == "Chloée") ?? new() { Nom = "DUPONT", Prenom = "Chloée" };

// A partir du début et s'assurer des non doublons de notre critère
Personne laSeuleEtUniqueChloee = mesPersonnes.Single(x => x.Prenom == "Chloée");
Personne? laSeuleEtUniqueChloeeSecure = mesPersonnes.SingleOrDefault(x => x.Prenom == "Chloée");

// Via les méthodes .First() et .Last() ainsi que leurs versions sécurisées, on peut, sans critère de sélection, avoir la première et dernière valeur de l'énumerable
var premierePersonneDeLaListe = mesPersonnes.FirstOrDefault();
var dernierePersonneDeLaListe = mesPersonnes.LastOrDefault();

// Si l'on veut désormais récupérer non pas une donnée mais plusieurs données, on peut utiliser .Where() suivi de critère de sélection également
var personnesEntre18Et35Ans = mesPersonnes.Where(x => x.Age > 17 && x.Age < 36).ToHashSet();

// Pour obtenir la série de données trié selon un critère, on peut utiliser .OrderBy() et .OrderByDescending()
var personnesTriesParAgeCroissant = mesPersonnes.OrderBy(x => x.Age).ToHashSet();
var personnesTriesParAgeDecroissant= mesPersonnes.OrderByDescending(x => x.Age).ToHashSet();
var personnesTrieesParNomPuisPrenom = mesPersonnes.OrderBy(x => x.Nom).OrderBy(x => x.Prenom).ToHashSet();

// Pour ne prendre qu'une seule valeur, on peut utiliser .Take()
var personneLaPlusJeune = mesPersonnes.OrderBy(x => x.Age).Take(1);

// Dans le cadre d'un paging, on a souvent recourt à l'utilisation de .Take() précédé de .Skip() en se basant sur une taille de page et un numéro de page. Ceci dans le but d'éviter d'envoyer à l'utilisateur toutes les valeurs d'un coup et de surcharger la base de données en cas de requêtage
int nbPage = 0;
var personnesALaPageX = mesPersonnes.Skip(50 * (nbPage - 1)).Take(50).ToHashSet();

// Pour extraire une valeur d'une série, on peut utiliser plusieurs fonctions de base similaires à celles disponibles dans le SQL
var ageTotalDesPersonnes = mesPersonnes.Sum(x => x.Age);
var personneLaPlusVieille = mesPersonnes.Max(x => x.Age);
var personneLaPlusJeuneBis = mesPersonnes.Min(x => x.Age);
var moyenneDesAges = mesPersonnes.Average(x => x.Age);

// Ou définir nous même notre code via la fonction .Aggregate()
var chaineDesInitiales = mesPersonnes.Aggregate("Liste des initiales : ", (concat, element) =>
{
    if (mesPersonnes.Last() != element) return concat + element.Nom.Substring(0, 1).ToUpper() + ", ";
    return concat + element.Nom.Substring(0, 1).ToUpper();
});

Console.WriteLine(chaineDesInitiales);


var personnesAvecAgePair = mesPersonnes.Where(x => x.Age % 2 == 0);

// Une autre syntaxe est disponible avec Linq, qui se rapproche du SQL. Celle-ci ne possède cependant pas toutes les features de la syntaxe avec les méthodes
var personnesAvecAgePairBis = from p in mesPersonnes where p.Age % 2 == 0 select p;

var personnesTrieesParNomDeFamille = from p in mesPersonnes orderby p.Nom select p;

// On peut également réaliser des projections de données via la partie select / .Select();
var nomsCompletsDesPersonnes = from p in mesPersonnes
                               select new
                               {
                                   NomComplet = p.Prenom + " " + p.Nom
                               };

var nomsEtAgeAuCarreDesPersonnes = mesPersonnes.Select(x => new { Nom = x.Nom, AgeAuCarre = x.Age * x.Age });
// var nomsEtAgeAuCarreDesPersonnes = mesPersonnes.Select(x => new { x.Nom, AgeAuCarre = x.Age * x.Age });

foreach(var element in nomsEtAgeAuCarreDesPersonnes)
{
    Console.WriteLine($"{element.Nom} a comme âge au carre {element.AgeAuCarre}");
}

// var range = Enumerable.Range(0, 20);


// Pour obtenir rapidement une série d'éléments aléatoires, on peut utiliser un énumérable temporaire non couteux et s'en servir pour brancher Linq dessus (Linq ne marche que sur les IEnumerable car c'est ce qu'il étend). Via la projection, on peut générer X valeurs et si l'on veut les récupérer par la suite dans un élément de type HashSet<T>
var listePersonnesRandom = Enumerable.Range(1, 5).Select((x) =>
{
    return new Personne()
    {
        Nom = "Nom de la personne " + x,
        Prenom = "Titi",
        Age = x * 10,
        Email = "temp.mail@email.com",
        Phone = "+33 123 456 78" + x
    };
}).ToHashSet();

foreach(Personne p in listePersonnesRandom)
{
    Console.WriteLine(p.Prenom + " " + p.Nom);
}