List<string> coupeur = new List<string>
        {
            "Antoine","Kevin", "Fatma", "Pierre", "Yusuf", "Anthony",
            "Guillaume", "Massima", "E Ebenga", "Florent", "Thibaud",
            "Alexandre", "Remi", "Hagit", "Ilyas", "Raphaël"
        };

Random random = new Random();


Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("\n\n ▄▄▄              █████   █    ██  ██▓       ██▓    ▓█████    \r\n▒████▄          ▒██▓  ██▒ ██  ▓██▒▓██▒      ▓██▒    ▓█   ▀    \r\n▒██  ▀█▄        ▒██▒  ██░▓██  ▒██░▒██▒      ▒██░    ▒███      \r\n░██▄▄▄▄██       ░██  █▀ ░▓▓█  ░██░░██░      ▒██░    ▒▓█  ▄    \r\n ▓█   ▓██▒      ░▒███▒█▄ ▒▒█████▓ ░██░      ░██████▒░▒████▒   \r\n ▒▒   ▓▒█░      ░░ ▒▒░ ▒ ░▒▓▒ ▒ ▒ ░▓        ░ ▒░▓  ░░░ ▒░ ░   \r\n  ▒   ▒▒ ░       ░ ▒░  ░ ░░▒░ ░ ░  ▒ ░      ░ ░ ▒  ░ ░ ░  ░   \r\n  ░   ▒            ░   ░  ░░░ ░ ░  ▒ ░        ░ ░      ░      \r\n      ░  ░          ░       ░      ░            ░  ░   ░  ░   \r\n ▄████▄   ▒█████   █    ██ ▄▄▄█████▓▓█████ ▄▄▄       █    ██  \r\n▒██▀ ▀█  ▒██▒  ██▒ ██  ▓██▒▓  ██▒ ▓▒▓█   ▀▒████▄     ██  ▓██▒ \r\n▒▓█    ▄ ▒██░  ██▒▓██  ▒██░▒ ▓██░ ▒░▒███  ▒██  ▀█▄  ▓██  ▒██░ \r\n▒▓▓▄ ▄██▒▒██   ██░▓▓█  ░██░░ ▓██▓ ░ ▒▓█  ▄░██▄▄▄▄██ ▓▓█  ░██░ \r\n▒ ▓███▀ ░░ ████▓▒░▒▒█████▓   ▒██▒ ░ ░▒████▒▓█   ▓██▒▒▒█████▓  \r\n░ ░▒ ▒  ░░ ▒░▒░▒░ ░▒▓▒ ▒ ▒   ▒ ░░   ░░ ▒░ ░▒▒   ▓▒█░░▒▓▒ ▒ ▒  \r\n  ░  ▒     ░ ▒ ▒░ ░░▒░ ░ ░     ░     ░ ░  ░ ▒   ▒▒ ░░░▒░ ░ ░  \r\n░        ░ ░ ░ ▒   ░░░ ░ ░   ░         ░    ░   ▒    ░░░ ░ ░  \r\n░ ░          ░ ░     ░                 ░  ░     ░  ░   ░      \r\n░                                                            ");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("\t\n A QUI LE COUTEAU ??...");
Console.ResetColor();
Console.ReadLine();

int index0 = random.Next(0, coupeur.Count);
string prenomCoupeur = coupeur[index0];

Console.Write($" Le choix est fait : ");
Console.ForegroundColor = ConsoleColor.Red;
Console.Write(prenomCoupeur);
Console.ResetColor();
Console.Write(" va trancher !\n");

Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("\t\nAttention, ça va couper !");

Console.WriteLine("\n\n  ___________________________________ ______________________\r\n \\                                  | (_)     (_)    (_)   \\\r\n  `.                                |  __________________   }\r\n    `-..........................____|_(                  )_/");
Console.ResetColor();


Console.ReadLine();
Console.Clear();


Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("  _                                            \r\n | |                                           \r\n | |        __ _                               \r\n | |       / _` |                              \r\n | |____  | (_| |                              \r\n |______|  \\__,_|  _          _     _          \r\n  / ____|         | |        | |   | |         \r\n | |  __    __ _  | |   ___  | |_  | |_    ___ \r\n | | |_ |  / _` | | |  / _ \\ | __| | __|  / _ \\\r\n | |__| | | (_| | | | |  __/ | |_  | |_  |  __/\r\n  \\_____|  \\__,_| |_|  \\___|  \\__|  \\__|  \\___|\r\n     | |                                       \r\n   __| |   ___   ___                           \r\n  / _` |  / _ \\ / __|                          \r\n | (_| | |  __/ \\__ \\                          \r\n  \\__,_|  \\___| |___/                          \r\n  _____            _                     _     \r\n |  __ \\          (_)                   | |    \r\n | |__) |   ___    _   ___              | |    \r\n |  _  /   / _ \\  | | / __|             | |    \r\n | | \\ \\  | (_) | | | \\__ \\             |_|    \r\n |_|  \\_\\  \\___/  |_| |___/             (_)    \r\n                                               \r\n                                              ");
Console.ResetColor();


List<string> prenoms = new List<string>
        {
            "Antoine","Kevin", "Fatma", "Pierre", "Yusuf", "Anthony",
            "Guillaume", "Massima", "E Ebenga", "Florent", "Thibaud",
            "Alexandre", "Remi", "Hagit", "Ilyas", "Raphaël"
        };



while (prenoms.Count > 0)
{
    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine("\t\nAppuyez sur Entrée pour tirer un prenom au hasard...");
    Console.ResetColor();
    Console.ReadLine();

    int index = random.Next(0, prenoms.Count);
    string prenomTire = prenoms[index];

    Console.Write($"Cette part est pour : ");
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.Write(prenomTire);
    Console.ResetColor();
    Console.Write(" !!\n");


    prenoms.RemoveAt(index);
}

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("\t\nLa liste est vide... Alors? Qui a la fève ??");
Console.ResetColor();