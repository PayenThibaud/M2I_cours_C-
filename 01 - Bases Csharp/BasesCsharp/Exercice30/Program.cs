Console.WriteLine("--- Question à choix multiple ---\n");
Console.WriteLine("Quelle est l'instruction qui permet de sortir d'une boucle en c# ?");
Console.WriteLine("\ta) quit");
Console.WriteLine("\tb) continue");
Console.WriteLine("\tc) break");
Console.WriteLine("\td) exit");
string reponse, nouvelEssai;
do
{
    Console.Write("Entrez votre réponse :");
    reponse = Console.ReadLine()!;
    if (reponse != "c")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Incorrecte!");
        Console.ResetColor();
        Console.Write("Un nouvel essai ? Oui / non :");
        nouvelEssai = Console.ReadLine()!.ToLower();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nBravo!!! c'est la bonne réponse\n");
        Console.ResetColor();
        break;
        //Environment.Exit(0);
        //return;
    }

} while (nouvelEssai == "oui");