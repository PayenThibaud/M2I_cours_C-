Console.WriteLine("--- Gestion des notes ---\n\n");
Console.WriteLine("Veuillez saisir les notes : \n(999 pour calculer)\n");
float max = 0, min = 20, somme = 0, moyenne;
int nbNotes = 1;
int userInput;

do
{
    //bool saisieValide;
    //do
    //{
    //    Console.Write("\t - Merci de saisir la note " + nbNotes + "(sur /20) :");
    //    saisieValide = int.TryParse(Console.ReadLine(), out userInput) // notre saisie est un entier
    //                && (                                            // ET
    //                    userInput == 999                            // notre valeur est égale à 999
    //                    ||                                          // OU
    //                    (userInput >= 0 && userInput <= 20)         // notre valeur est comprise entre 0 et 20
    //                    );
    //    //saisieValide = int.TryParse(Console.ReadLine(), out userInput)&& (userInput == 999 || (userInput >= 0 && userInput <= 20));
    //    if (!saisieValide)
    //    {
    //        Console.ForegroundColor = ConsoleColor.Red;
    //        Console.WriteLine("\t\tErreur de saisie, la note est sur 20 !");
    //        Console.ResetColor();
    //    }
    //} while (!saisieValide);

    // variante du contrôle de saisie
    Console.Write("\t - Merci de saisir la note " + nbNotes + "(sur /20) :");
    while (!(int.TryParse(Console.ReadLine(), out userInput) && (userInput == 999 || (userInput >= 0 && userInput <= 20))))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\t\tErreur de saisie, la note est sur 20 !");
        Console.ResetColor();
        Console.Write("\t - Merci de saisir la note " + nbNotes + "(sur /20) :");
    }

    if (userInput != 999)
    {
        if (userInput > max)
            max = userInput;
        if (userInput < min)
            min = userInput;
        somme += userInput;
        nbNotes++;
    }

} while (userInput != 999);


moyenne = somme / ((float)nbNotes - 1);
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\nla meilleure note est " + max + "/20");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("la moins bonne note est " + min + "/20");
Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine("la moyenne des note est " + moyenne + "/20");
Console.ResetColor();