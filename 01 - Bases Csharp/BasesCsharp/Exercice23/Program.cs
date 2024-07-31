Console.WriteLine("--- Accroissement de la population de Tourcoing ---\n\n");
int year0 = 2015;
double pop = 96806;
double tx = 0.0089;
int popMax = 120000;
int year;

for (year = year0; pop < popMax; year++)
{
    pop = pop + (pop * tx); 
    //pop = Math.Round(pop + (pop * tx)); 
    //selon l'endroit où l'on fait l'arrondi le résultat n'est pas le même
}

Console.WriteLine($"Il faudra {year - year0} ans, nous serons en {year}");
Console.WriteLine($"Il y aura {Math.Round(pop)} habitants en {year}");
Console.WriteLine($"Il y aura {pop:F0} habitants en {year}");