// A l'ancienne, on avait recourt au mécanisme du boxing, unboxing pour permettre la manipulation d'éléments par référence et non par valeur (avant les mot-clés 'ref' et la généricité). Ceci est toujours possible, mais est moins souvent utilisé
using Demo06CollGeneriques;

int maVariable = 24; // On déclare une variable de type valeur

object maVariableObj = (object) maVariable; // On met dans une boite (un objet) la valeur pour la transformer en type référence

// On réalise nos manipulation de variable


int uneValeurInt = (int)maVariableObj; // On sort de la boite (unboxing) notre type référence pour obtenir de nouveau le type valeur

// Les Listes 
List<string> mesStrings = new();

// On peut ajouter des éléments dans une liste
mesStrings.Add("John");

// En supprimer via la valeur
mesStrings.Remove("John");

mesStrings.Add("John");

// Chercher un élément correspondant à un critère donné
var trouve = mesStrings.Find(x => x.StartsWith('J'));

// Accéder aux éléments via leur index
var firstElement = mesStrings[0];

// Supprimer les éléments via l'index
mesStrings.RemoveAt(0);

// Ajouter une autre série de valeurs pour étendre notre liste
mesStrings.AddRange(new List<string>() { "Albert", "John" });

// Trouver l'index d'un élément
int index = mesStrings.IndexOf("Albert");

// Vider la liste
mesStrings.Clear();

// Trier la liste
mesStrings.Sort();


// Pour réaliser des retour multiples ou rassembler des valeurs (jusquà 7 valeurs max), on peut utiliser un type générique qui est déjà disponible et prévu à cet effet: les Tuple<>

// Il existe une ancienne syntaxe pour réaliser cela : 
Tuple<int, int, int, double> Calcul(int a, int b) {
    return new Tuple<int, int, int, double>(a + b, a - b, a * b, a / b);
}

Tuple<int, int, int, double> mesResultats = Calcul(2, 6);
int laSomme = mesResultats.Item1;
int leReste = mesResultats.Item2;


// Et une syntaxe plus moderne:
(int, int, int, double) CalculModerne(int a, int b) {
    return (a + b, a - b, a * b, a / b);
}


// Qui nous permet l'extraction des valeurs via les propriétés .ItemX comme avant
(int, int, int, double) mesResultatsALAncienne = CalculModerne(2, 6);
int laSommeALancienne = mesResultats.Item1;
int leResteALancienne = mesResultats.Item2;

// Ou l'initialisation des variables directement via un unpacking du tuple
var (somme, reste, produit, quotient) = CalculModerne(2, 6);

// Le Dictionnaire est une collection permettant de stocker via un ensemble clé-valeur des données. La clé sera généralement une chaine de caractère et la valeur un type référence, mais ceci est libre. 

Dictionary<string, Contact> mesContacts = new();

// Lorsque l'on veut ajouter un élément à notre dictionnaire, on peut également utiliser la méthode .Add(), mais celle-ci fonctionne différemment pour le dictionnaire. Il nous faudra indiquer la clé en amont de la valeur à ajouter
mesContacts.Add("John DUPONT", new()
{
    Nom = "DUPONT",
    Prenom = "John",
    Telephone = "+33 123 456 789",
    Email = "j.dupont@example.com",
    Age = 21
});

// Pour accéder à la valeur, il est possible dans un dictionnaire de faire appel à l'indexeur (notation crochets), qui fonctionne cette fois-ci via la clé et non l'index numérique (emplacement dans la collection) telle que la liste
Console.WriteLine(mesContacts["John DUPONT"].Telephone);
mesContacts["Martha GOMEZ"] = new Contact() { Prenom = "Martha", Nom = "GOMEZ" };

// Pour vérifier la présence d'une clé dans le dictionnaire
mesContacts.ContainsKey("John DUPONT");

// Pour parcourir les clés de notre dictionnaire, on a la propriété .Keys
foreach(var k in mesContacts.Keys)
{
    Console.WriteLine(mesContacts[k]);
}

// Pour avoir les valeurs directement, on a .Values
foreach(var v in mesContacts.Values)
{
    Console.WriteLine(v);
}


// Pour récupérer des éléments par clé, de façon sécurisée, on peut utiliser à la place de l'indexeur la méthode .TryGetValue()
Contact albertD;
mesContacts.TryGetValue("Albert DUPONT", out albertD);

// Pour supprimer un élément d'un dictionnaire, la suppression se fait via la clé
mesContacts.Remove("John DUPONT");

HashSet<int> nombresA = new()
{
    1, 2, 3, 4
};

HashSet<int> nombresB = new()
{
    4, 5, 6, 7, 8, 9, 10
};

nombresA.Add(5); // On peut ajouter dans un set comme avec une liste
nombresA.Add(5); // Mais on ne peut pas avoir deux fois présence de la même valeur dans le set (pour les primitifs, c'est simple. Pour les références, attention au fait qu'il s'agit d'emplacement mémoire)

// Pour supprimer un élément du set, on a cette méthode, semblable aux listes:
nombresA.Remove(1);

Console.WriteLine("nombreB contient le chiffre 2 ? " + (nombresB.Contains(2) ? "OUI" : "NON"));

Console.WriteLine("Il y a " + nombresB.Count + " éléments dans le set");

// Pour vider un set, on peut utiliser .Clear()
//nombresB.Clear();

// Pour obtenir les éléments présents dans deux ensembles de données
var nombresEnCommun = nombresA.Intersect(nombresB).ToHashSet();

// Si l'on voulait modifier notre set pour obtenir les éléments en commun avec un autre ensemble nombresA.IntersectWith()

// Pour obtenir les éléments d'un ensemble ainsi qu'un autre, on peut les unir
var tousLesNombres = nombresA.Union(nombresB).ToHashSet();

// Pour ajouter les éléments d'un autre set dans un set donné, on peut utiliser .UnionWith()
nombresB.UnionWith(new HashSet<int>() { 11, 12, 13, 14, 15 });

// Lorsque l'on a deux ensembles de données, il peut être intéressant de savoir si un ensemble fait partie d'un autre, ou si un ensemble comprend tous les éléments d'un autre

HashSet<int> petitSet = new() { 1, 2 };
petitSet.IsSubsetOf(nombresA); // Les éléments présents dans le petit set sont tous présents dans l'ensemble nombreA
nombresA.IsSupersetOf(petitSet); // L'ensemble nombreA comprend tous les éléments présents dans l'ensemble petitSet

// Si l'on veut réaliser un groupement de données qui respecte la règle du LiFo (Last In First Out), on va utiliser un type générique prévu à cet effet
Stack<int> maPileDeNombres = new();

// Pour ajouter des éléments à notre empilement, on va utiliser la méthode .Push()
maPileDeNombres.Push(1);
maPileDeNombres.Push(2);
maPileDeNombres.Push(3);
maPileDeNombres.Push(4);

// Pour récupérer le dernier qui a été ajouté au niveau de notre empilement, on va utiliser .Pop()
var nombreEnHautDePile = maPileDeNombres.Pop();

// Pour faire un stockage de données qui respecte la règle du FiFo (First in First out), on va créer une Queue<>
Queue<string> mesMessages = new();

// Pour ajouter des élément à notre file d'éléments, on a .EnQueue()
mesMessages.Enqueue("Contenu du mail 1");
mesMessages.Enqueue("Contenu du mail 2");
mesMessages.Enqueue("Contenu du mail 3");
mesMessages.Enqueue("Contenu du mail 4");

// Pour obtenir l'élément ajouté depuis le plus longtemps, on a .DeQueue()
var mailArriveEnPremier = mesMessages.Dequeue();


// Pour instancier un objet de notre type générique, on va utiliser la notation chevrons
MaListe<int> maListeDeNombres = new(5);

MaListe<Contact> neMarcheraPas = new(5);

maListeDeNombres.Add(24);
maListeDeNombres.Add(2_458);
maListeDeNombres.Add(150_000_000);
maListeDeNombres.AfficheMesElements();

Console.WriteLine("Quelle est la valeur par défaut d'un booléen : " + default(bool));
Console.WriteLine("Quelle est la valeur par défaut de MaListe<int> : " + (default(MaListe<int>) is null ? "null" : "autre"));

