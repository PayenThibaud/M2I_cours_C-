Console.WriteLine("--- Où est passé mon numéro ? ---");
Console.WriteLine("Affectation des valeurs...");

Random rnd = new Random();
int[] valeurs = new int[10];

for (int i = 0; i < valeurs.Length; i++)
{
    int num = rnd.Next(1, 51);
    valeurs[i] = num;
}

Console.WriteLine("Affichage avant triage : ");

// Affichage du tableau
const string tabulation = "  ";
string tabulations = tabulation;

foreach (int val in valeurs)
{
    Console.WriteLine(tabulations + val);
    tabulations += tabulation;
}

int premiereValeur = valeurs[0];

Console.WriteLine("Après : ");

// Triage du tableau et récupération de valeur

Array.Sort(valeurs);

tabulations = tabulation;
foreach (int val in valeurs)
{
    Console.WriteLine(tabulations + val);
    tabulations += tabulation;
}

int premiereValeurApresTriage = Array.IndexOf(valeurs, premiereValeur) + 1;

Console.WriteLine($"Le nombre {premiereValeur} se trouvait en 1ere position");
Console.WriteLine($"Il se retrouve à la position {premiereValeurApresTriage} après triage.");

