////// VERSION AVEC LISTES

//List<string> listBase = new List<string>
//{
//    "Ilyas",
//    "Aguit",
//    "Massima",
//    "Guillaume",
//    "Florent",
//    "Thibaud",
//    "Youssouf",
//    "Fatma",
//    "Pierre-Julien",
//    "Alexandre",
//    "Raphaël",
//    "Rémi",
//    "Kévin",
//    "E-Ebhenga",
//    "Anthony",
//};

//List<string> listRestante = new List<string>(listBase); // crée une nouvelle instance via le constructeur de recopie

//Random rand = new Random();
//List<string> listTirees = new List<string>();
//bool fin = false;


//while (!fin)
//{
//    Console.WriteLine(" --- Le grand tirage au sort ---" +
//    "\n" +
//    "\n 1---Effectuer un tirage" +
//    "\n 2---Voir la liste des personnes déja tirées" +
//    "\n 3---Voir la liste des personnes restantes" +
//    "\n 0---Quitter");
//    Console.WriteLine();
//    Console.Write("Faites votre choix :");
//    var choice = Console.ReadLine();
//    var tab = "";
//    var longueurListRestante = listRestante.Count;
//    switch (choice)
//    {
//        case "1":
//            if (longueurListRestante > 0)
//            {
//                var randName = listRestante[rand.Next(0, longueurListRestante)];
//                Console.ForegroundColor = ConsoleColor.Green;
//                Console.WriteLine($"* L'heureux gagnant est : {randName} *");
//                Console.ForegroundColor = ConsoleColor.White;
//                listRestante.Remove(randName);
//                listTirees.Add(randName);
//            }
//            else if (longueurListRestante == 0)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Il n'y a plus de candidat, on réinitialise nos listes");
//                Console.ForegroundColor = ConsoleColor.White;
//                listRestante = new List<string>(listBase);
//                listTirees = new List<string>(); // ou clear
//            }
//            break;
//        case "2":
//            foreach (var name in listTirees)
//            {
//                Console.WriteLine(tab + name);
//                tab += " ";
//            }
//            break;
//        case "3":
//            foreach (var name in listRestante)
//            {
//                Console.WriteLine(tab + name);
//                tab += " ";
//            }
//            break;
//        case "0":
//            fin = true;
//            break;
//        default:
//            Console.WriteLine("Erreur de saisie");
//            break;
//    }
//}


//// VERSION AVEC TABLEAU

//string[] players = new string[15]
//{

//        "Ilyas",
//        "Aguit",
//        "Massima",
//        "Guillaume",
//        "Florent",
//        "Thibaud",
//        "Youssouf",
//        "Fatma",
//        "Pierre-Julien",
//        "Alexandre",
//        "Raphaël",
//        "Rémi",
//        "Kévin",
//        "E-Ebhenga",
//        "Anthony",
//};

//string[] winners = new string[15];
//int i = 0;

//while (true)
//{
//    Console.ResetColor();
//    Console.WriteLine("--- Tombola ---\n");
//    Console.WriteLine("1. Effectuer un tirage");
//    Console.WriteLine("2. Afficher la liste des gagnants");
//    Console.WriteLine("3. Afficher la liste des joueurs restants");
//    Console.WriteLine("0. Quitter\n");

//    Console.Write("Faites votre choix : ");
//    string userChoice = Console.ReadLine()!;

//    switch (userChoice)
//    {
//        case "0":
//            Environment.Exit(0);
//            break;

//        case "1":
//            Random randomly = new Random();
//            int randomIndex = randomly.Next(0, players.Length);
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine($"\n*** L'heureux.se gagnant.e est : {players[randomIndex]} !! ***\n");
//            Console.ResetColor();
//            Console.WriteLine();

//            winners[i] = players[randomIndex];
//            i++;
//            players[randomIndex] = players[players.Length - 1];
//            Array.Resize(ref players, players.Length - 1);

//            if (players.Length == 0)
//            {
//                players = (string[])winners.Clone();
//                i = 0;
//                Array.Clear(winners, 0, 15);
//                Console.WriteLine("Il n'y a plus de candidat, on réinitialise nos listes");
//            }
//            break;

//        case "2":
//            Console.ForegroundColor = ConsoleColor.Yellow;
//            Console.WriteLine("\n--- Liste des personnes déjà tirées au sort ---\n");
//            Console.ResetColor();
//            foreach (var winner in winners)
//                if (winner != null)
//                    Console.WriteLine($"\t{winner}");
//            Console.WriteLine("");
//            break;

//        case "3":
//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine("\n--- Liste des personnes en attente ---\n");
//            Console.ResetColor();
//            foreach (var player in players)
//                Console.WriteLine($"\t{player}");
//            Console.WriteLine("");
//            break;

//        default:
//            Console.Clear();
//            break;
//    }
//}


// EN DECOUPANT EN FONCTIONS

void IHM() // IHM == interface Homme-Machine, ici notre affichage de menu
{
    string[] noms =
    {
        "Ilyas",
        "Aguit",
        "Massima",
        "Guillaume",
        "Florent",
        "Thibaud",
        "Youssouf",
        "Fatma",
        "Pierre-Julien",
        "Alexandre",
        "Raphaël",
        "Rémi",
        "Kévin",
        "E-Ebhenga",
        "Anthony",
    };
    string[] nomsTires = new string[noms.Length];
    Console.WriteLine("--- Le grand tirage au sort ---");
    while (true)
    {
        Console.WriteLine("1--- Effectuer un tirage");
        Console.WriteLine("2--- Voir la liste des personnes déjà tirées");
        Console.WriteLine("3--- Voir la liste des personnes restantes");
        Console.WriteLine("4--- Ajouter un prenom");
        Console.WriteLine("0--- Quitter\n");
        Console.Write("Faites votre choix : ");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                EffectuerTirage(noms, nomsTires);
                break;
            case "2":
                AfficherTirees(nomsTires);
                break;
            case "3":
                AfficherRestantes(noms, nomsTires);
                break;
            case "4":
                AjouterNom(ref noms, ref nomsTires);
                break;
            case "0":
                return;
            default:
                WriteInColor("Erreur, réessayez !", ConsoleColor.Red);
                break;
        }
        Console.WriteLine("Appuyez sur une touche pour revenir au menu");
        Console.ReadKey();
        Console.Clear();
    };
}
void WriteInColor(string text, ConsoleColor color) // fonction pour faire un affichage en couleur
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
    Console.ResetColor();
}
void EffectuerTirage(string[] noms, string[] nomsTires)
{
    Random random = new Random();
    string nouveauNomTire;
    do
    {
        nouveauNomTire = noms[random.Next(nomsTires.Length)];   // on selectionne un nom au hasard
    } while (nomsTires.Contains(nouveauNomTire));               // tant que c'est déjà un nom tiré, on en resélectionne un nouveau

    AjouterDansTableau(nouveauNomTire, nomsTires);              // on l'ajoute aux tirés

    WriteInColor($"L'heureux gagnant est {nouveauNomTire}", ConsoleColor.Green);

    if (nomsTires[nomsTires.Length - 1] != null)                // si la dernière case du tableau n'est pas vide, on a tiré tout le monde !
    {
        WriteInColor("Toutes les personnes ont été tirées, on remet tout à 0 !", ConsoleColor.DarkYellow);
        //for (int i = 0; i < nomsTires.Length; i++)              // remise du tableau tires à 0
        //{
        //    nomsTires[i] = null;                                // donc réafectation des cellules à null
        //}
        Array.Clear(nomsTires);
    }
}
void AjouterDansTableau(string chaine, string[] tableau)
{
    for (int i = 0; i < tableau.Length; i++) // on va mettre le nouveau nom tiré dans la listeTires
        if (tableau[i] == null)                // au premier index ou la case du tableau est vide
        {
            tableau[i] = chaine;
            break;
        }
}
void AfficherTirees(string[] nomsTires)
{
    WriteInColor("Personnes Tirées : ", ConsoleColor.Red);
    string tab = "  ";
    string tabs = "";
    foreach (string nom in nomsTires)
        if (nom != null)                    // on affiche que les cases du tableau où un nom est inscrit
        {
            Console.WriteLine(tabs + nom);
            tabs += tab;
        }
}
void AfficherRestantes(string[] noms, string[] nomsTires)
{
    WriteInColor("Personnes pas encore Tirées : ", ConsoleColor.Blue);
    string tab = "  ";
    string tabs = "";
    foreach (string nom in noms)            // on itère sur tout les noms du tableau
        if (!nomsTires.Contains(nom))       // et on affiche uniquement ceux qui ne sont pas déjà tirés (pas dans nomsTires)
        {
            Console.WriteLine(tabs + nom);
            tabs += tab;
        }
}
void AjouterNom(ref string[] noms, ref string[] nomsTires) // saisie d'un nouveau nom
{
    Console.Write("Saisir un nom : ");
    string nouveauNom = Console.ReadLine();
    Array.Resize(ref noms, noms.Length + 1);        // on redimentionne les tableaux pour pouvoir accueillir le nouveau nom
    Array.Resize(ref nomsTires, noms.Length + 1);
    noms[noms.Length - 1] = nouveauNom;             // on le met à la fin du tableau nom (nouvelle case)
}

// appeller la fonction dans la partie principale du programme pour lancer l'IHM
IHM();