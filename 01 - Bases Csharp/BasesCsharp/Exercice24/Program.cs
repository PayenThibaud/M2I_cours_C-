//Console.WriteLine("--- Les suites chaînées de nombres ---\n");
//Console.Write("Merci de saisir un nombre : ");
//int nombreSaisi = int.Parse(Console.ReadLine()!);


//Console.WriteLine("Les chaînes possibles sont :");

//int midNumber = nombreSaisi / 2 + 1;

//for (int debutChaine = 1; debutChaine <= midNumber; debutChaine++)
//{
//    int sommeEntiers = 0;
//    bool chaineValide = false;
//    int finChaine = 0;

//    for (int j = debutChaine; j <= midNumber; j++)
//    {
//        sommeEntiers += j;
//        if (sommeEntiers == nombreSaisi)
//        {
//            chaineValide = true;
//            finChaine = j;
//        }
//        if (sommeEntiers > nombreSaisi)
//            break; // pour optimiser en faisant moins de boucles
//    }

//    if (chaineValide)
//    {
//        Console.Write($"{nombreSaisi} = {debutChaine}");
//        for (int j = debutChaine + 1; j <= finChaine; j++)
//        {
//            Console.Write("+" + j);
//        }
//        Console.WriteLine();
//    }
//}



//// Version alternative
//Console.WriteLine("--- Les suites chaînées de nombres ---\n");
//Console.Write("Merce de saisir un nombre : ");
//int number = int.Parse(Console.ReadLine()!);
//int midNumber = number / 2 + 1;

//Console.WriteLine("Les chaînes possibles sont :");
//for (int debut = 1; debut <= midNumber; debut++)
//{
//    int sum = 0;
//    int next = debut;

//    while (sum < number)
//        sum += next++;

//    if (sum == number)
//    {
//        Console.Write($"{number} = {debut}");
//        for (int j = debut + 1; j <= next; j++)
//        {
//            Console.Write("+" + j);
//        }
//        Console.WriteLine();
//    }
//}



// Version plus optimisée, avec une logique différente et qui prends en compte les nombres négatifs
Console.WriteLine("--- Les suites chaînées de nombres ---\n");
Console.Write("Merce de saisir un nombre : ");
int number = int.Parse(Console.ReadLine()!);

Console.WriteLine("Les chaînes possibles sont :");

for (double diviseur = 2; diviseur <= number; diviseur++)
{
    double mid = number / diviseur;

    if (mid % 0.5 == 0)
    {
        int debut = (int)(mid - diviseur / 2) + 1;
        if (debut <= 1)
            break;

        int fin = (int)(mid + diviseur / 2);
        Console.Write($"{number} = {debut}");
        for (int j = debut + 1; j <= fin; j++)
        {
            Console.Write("+" + j);
        }
        Console.WriteLine();
    }
}