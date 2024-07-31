Console.WriteLine("*** Trouver le nombre mystère ***\n");
Random rnd = new Random();
int nbmystere = rnd.Next(1, 51);
int nbchoix = 0;
int coup = 0;

while (nbchoix != nbmystere)
{
    Console.Write("Veuillez saisir un nombre entre 1 et 50: ");
    while (!int.TryParse(Console.ReadLine(), out nbchoix) || nbchoix < 1 || nbchoix > 50)
        Console.WriteLine("Saisie invalide ! Réésayer :");
    coup++;

    Console.ForegroundColor = ConsoleColor.Red;
    if (nbchoix > nbmystere)
        Console.WriteLine("\tLe nombre mystère est plus petit");
    else if (nbchoix < nbmystere)
        Console.WriteLine("\tLe nombre mystère est plus grand");
    Console.ResetColor();
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Bravo !!! Vous avez trouvé le nombre mystère !");
Console.WriteLine($"Vous avez trouvé en {coup} coups.");
Console.ResetColor();
