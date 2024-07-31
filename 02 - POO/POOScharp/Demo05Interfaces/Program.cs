using Demo05Interfaces.Classes;
using Demo05Interfaces.Interfaces;
using System.Runtime.CompilerServices;

Oiseau monOiseau = new("Coco");
Chien monChien = new("Rex");
Avion monAvion = new();

Animal monAnimal;

monAnimal = new Chien("Bernie");

Animal FaireNaissance()
{
    return new Oiseau("Coco");
}

Oiseau coco = (Oiseau) FaireNaissance();

// Il est possible de regrouper des éléments dans une série ou un type de variable via l'utilisation des classes parents (abstraites ou non)

List<Animal> mesAnimaux = new()
{
    monChien,
    monOiseau
};

// Il est possible de regrouper des éléments dans une série ou un type de variable via l'utilisation des interfaces également

List<IVolant> mesVolants = new()
{
    monOiseau,
    monAvion
};

/* 
 * Il serait possible de regrouper tout type d'élément dans une liste, peu importe son type car tout type hérite d'object
 * 
 * Cependant, en faisant cela, on va perdre toute information de ce que l'élément est capable de faire et on va devoir faire un casting pour obtenir de nouveau ces infos
 */


//List<object> mesObjects = new()
//{
//    monAvion,
//    monChien,
//    monOiseau
//};

//foreach(object obj in mesObjects)
//{
//    if (obj is Oiseau) ((Oiseau)obj).MakeSound();
//}

monAvion.Senvoler();

//Chat unChat = new();
//unChat.Age = -22;


// On peut créer des objets avec la syntaxe suivante, en utilisant les propriétés qui doivent avoir la possibilité de set les valeurs des champs internes de la classe

ContactDTO monContact = new() 
{
    Prenom = "Albert",
    Age = 21
};

monContact = new() 
{
    Nom = "MARTEZ"
};


// Si l'on se sert d'un record, il est par défaut impossible de changer la valeur des champs de notre record. Ils sont en lecture seule
ContactRecord unAutreContact = new("DUPONT", "John", 24);
Console.WriteLine(unAutreContact.nom);
//unAutreContact.nom = "Albert"; // Ceci est impossible car champs en lecture seule
unAutreContact = new("MARTEZ", "John", 12);

Console.WriteLine("\n=== Classes ===");
ContactDTO dtoA = new() { Prenom = "John", Nom = "DUPONT", Age = 21 };
Console.WriteLine($"dtoA: {dtoA.Prenom} {dtoA.Nom}");
ContactDTO dtoB = new() { Prenom = "John", Nom = "DUPONT", Age = 21 };
Console.WriteLine($"dtoB: {dtoB.Prenom} {dtoB.Nom}");
Console.WriteLine($"Les deux contacts sont les mêmes ? {(dtoA== dtoB? "OUI" : "NON")}");

// Les records sont pratiques également pour vérifier les égalités en se basant sur des valeurs de leurs champs et non la case mémoire allouée
Console.WriteLine("\n=== Records ===");
ContactRecord contactA = new("DUPONT", "John", 18);
Console.WriteLine($"contactA: {contactA.prenom} {contactA.nom}");
ContactRecord contactB = new("DUPONT", "John", 18);
Console.WriteLine($"contactB: {contactB.prenom} {contactB.nom}");
Console.WriteLine($"Les deux contacts sont les mêmes ? {(contactA == contactB ? "OUI" : "NON")}");