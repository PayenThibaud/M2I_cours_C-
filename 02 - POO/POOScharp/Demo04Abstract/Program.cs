using Demo04Abstract.Classes;

// Impossible de créer une instance de classe abstraite
//Mammal unMammifere = new();

// Mais possible de créer une instance d'un type enfant non abstrait. Cela ne change pas la règle qui fait que l'on peut stocker dans une variable de type parent un type enfant
Mammal unAutre = new Chien(2);
const int maValeur = 25;

Console.WriteLine(maValeur);
Console.WriteLine(25);

Chien rex = new("Rex", 2, RaceChien.DOBERMAN);
Chien rex = new("Rex", 2, 10);