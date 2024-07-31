using Exercice08Pile.Classes;

Pile<string> mesStrings = new();

mesStrings.Empile("John");
mesStrings.Empile("Chloée");
mesStrings.Empile("Clara");

var retire = mesStrings.Depile();

Console.WriteLine(retire);

Pile<decimal> mesSous = new();

mesSous.Empile(12.14m);
mesSous.Empile(3499.89m);
mesSous.Empile(150_000_000.00m);

Pile<Personne> mesPersonnes = new();

mesPersonnes.Empile(new() { Prenom = "John", Nom = "DUPONT", Age = 21 });
mesPersonnes.Empile(new() { Prenom = "Martha", Nom = "DUPONT", Age = 19 });
mesPersonnes.Empile(new() { Prenom = "Léo", Nom = "DUPONT", Age = 3 });

Console.WriteLine(mesPersonnes[1].Prenom + " " + mesPersonnes[1].Nom);