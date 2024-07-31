int[] tab = new int[10];

for (int i = 0; i < tab.Length; i++)
{
    Console.WriteLine($"Saisir la valeur n°{i + 1}");
    tab[i] = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine("Affichage des valeurs du tableau :");

string tabulations = "";

for (int i = 0; i < tab.Length; i++)
{
    Console.WriteLine(tabulations + tab[i]);
    tabulations += "\t";
}