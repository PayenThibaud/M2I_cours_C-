Console.WriteLine("*** Le nombre est-il divisible par...? ***\n");
Console.Write("Entrez un chiffre/nombre entier : ");
//int nbEntier = Convert.ToInt32(Console.ReadLine());
int nbEntier;
bool saisieValide = int.TryParse(Console.ReadLine(), out nbEntier);

Console.Write("Entrez un chiffre/nombre diviseur : ");
//int nbDiviseur = Convert.ToInt32(Console.ReadLine());
int nbDiviseur;
saisieValide = saisieValide & int.TryParse(Console.ReadLine(), out nbDiviseur);


if (!saisieValide)
{
    Console.WriteLine("Saisie invalide");
    return;
    // on quitte la méthode Main de la classe Program
    // permet d'arréter notre application
    //Environment.Exit(0); // permet aussi d'arréter notre application
}


Console.WriteLine();

// TERNAIRE
// var variable = <Condition> ? <Valeur si Vrai> : <Valeur si Faux>;
string chiffreOuNombre = (-10 < nbEntier && nbEntier < 10) ? "chiffre" : "nombre";
// équivalent:
//string chiffreOuNombre = "nombre";
//if (-10 < nbEntier && nbEntier < 10)
//    chiffreOuNombre = "chiffre";

if (nbEntier % nbDiviseur == 0)
    Console.WriteLine($"Le {chiffreOuNombre} est divisible par {nbDiviseur}");
else
    Console.WriteLine($"Le {chiffreOuNombre} n'est pas divisible par {nbDiviseur}");

string divisibleOuNon = (nbEntier % nbDiviseur == 0) ? "est" : "n'est pas";

Console.WriteLine($"Le {chiffreOuNombre} {divisibleOuNon} divisible par {nbDiviseur}");
