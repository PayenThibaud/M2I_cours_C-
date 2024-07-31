//// TRIANGLE

//Console.WriteLine("Saisir la hauteur du triangle : ");
//int hauteur = Convert.ToInt32(Console.ReadLine());


//// 1 - avec incrementation et decrementation
//int nbEspaces = hauteur - 1;
//int nbEtoiles = 1;

//for (int ligne = 1; ligne <= hauteur; ligne++)
//{
//    string espaces = string.Concat(Enumerable.Repeat(" ", nbEspaces)); // sert à répèter des string en c#
//    string etoiles = string.Concat(Enumerable.Repeat("*", nbEtoiles));
//    Console.WriteLine(espaces + etoiles);
//    nbEspaces--;
//    nbEtoiles += 2;
//}

//// 2 - avec calcul du nombre de caractères
//for (int ligne = 1; ligne <= hauteur; ligne++)
//{
//    string espaces = string.Concat(Enumerable.Repeat(" ", hauteur - ligne));
//    string etoiles = string.Concat(Enumerable.Repeat("*", 2 * ligne - 1));
//    Console.WriteLine(espaces + etoiles);
//}

//// 3 - avec des boucles imbriquées et Write()
//for (int ligne = 1; ligne <= hauteur; ligne++)
//{
//    for (int espaces = 1; espaces <= hauteur - ligne; espaces++)
//        Console.Write(" ");
//    for (int etoiles = 1; etoiles <= 2 * ligne - 1; etoiles++)
//        Console.Write("*");
//    Console.WriteLine();
//}



// SAPIN

List<ConsoleColor> ballColors = new List<ConsoleColor>()
{
    ConsoleColor.Red,
    ConsoleColor.Magenta,
    ConsoleColor.Blue,
    ConsoleColor.Cyan,
    ConsoleColor.Yellow
};

Random random = new Random();

Console.WriteLine("Saisir la hauteur du sapin : ");
int hauteur = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Saisir la hauteur du tronc : ");
int tronc = Convert.ToInt32(Console.ReadLine());


while (true) // boucle des sapins
{
    for (int ligne = 1; ligne <= hauteur; ligne++) // boucle des lignes du sapin
    {
        for (int espaces = 1; espaces <= hauteur - ligne; espaces++) // boucle des espaces au début des lignes
            Console.Write(" ");

        if (ligne == 1) // pointe du sapin
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("A");
        }
        else
            for (int etoiles = 1; etoiles <= 2 * ligne - 1; etoiles++) // boucle des boules et des étoiles
            {
                string symb;
                //if (random.Next(1, 8) > 3)
                if (random.NextDouble() > 0.33)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    symb = "*";
                }
                else
                {
                    Console.ForegroundColor = ballColors[random.Next(ballColors.Count)];
                    symb = "o";
                }
                Console.Write(symb);
            }
        Console.WriteLine();
    }

    Console.ForegroundColor = ConsoleColor.DarkRed;
    string espacesTronc = string.Concat(Enumerable.Repeat(" ", hauteur - 2));
    for (int i = 0; i < tronc; i++)
    {
        Console.WriteLine(espacesTronc + "| |");
    }

    Thread.Sleep(500);
    Console.Clear();
}
Console.ForegroundColor = ConsoleColor.Gray;