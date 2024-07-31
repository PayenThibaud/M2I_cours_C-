using Demo03HeritagePolymorphisme.Classes;

Chat monChat = new("Berlioz", 2, false);
Chien monChien = new("Rex", 2);
Mammal monMammifere = new();

// On peut stocker dans une variable de type parent tout type enfant également. Cependant, on perd les spécificités de l'enfant en faisant cela. 
Mammal autreAnimal = new Chien("Bernie", 1);
Console.WriteLine(((Chien)autreAnimal).NbBones);

// Gràce à l'héritage, on peut regrouper derrière un type de variable tout type héritant de ce type
// Ici, une liste de mammifère peut regrouper toute instance étant mammifère ou héritant de mammifère
List<Mammal> mesMammiferes = new() { monChat, monChien, monMammifere };

foreach(var m in mesMammiferes)
{
    // Dans une itération d'un type parent, on perd également les informations spécifiques de l'enfant
    Console.WriteLine(m.Name);
}

// De même, le type des paramètres de fonction peut être un type parent de X. Ainsi, on peut avoir une fonction traitant plusieurs types d'instances directement
void MaFonction(Mammal unMammal)
{
    Console.WriteLine(unMammal.Name);
}

MaFonction(monChien);

Console.WriteLine(monMammifere);

Mammal mamA = new();
Mammal mamB = new();

Console.WriteLine($"Les deux mammifères sont-ils les mêmes ? {(mamA.Equals(mamB) ? "OUI" : "NON")}");

foreach(var m in mesMammiferes)
{
    m.MakeSound();
}