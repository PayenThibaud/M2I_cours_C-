//for (int table = 1; table <= 10; table++)
//{
//    Console.WriteLine("Table de " + table);
//    for (int multi = 1; multi <= 10; multi++)
//        Console.WriteLine($"\t {table} x {multi} = {table * multi}");
//}


// Bonus version tableau

//for (int multi = 1; multi <= 10; multi++)
//    Console.Write($"{multi}\t");
//Console.WriteLine();
//Console.WriteLine("----------------------------------------------------------------------------");
////Console.WriteLine(string.Concat(Enumerable.Repeat("-", 60)));

//for (int table = 1; table <= 10; table++)
//{
//    for (int multi = 1; multi <= 10; multi++)
//        Console.Write($"{multi*table}\t");
//    Console.WriteLine();
//}



//// Affichage en tableau dynamique

using System.Threading;

int largeurTables = 10;
const int largeurCol = 3;

Console.WriteLine("Combien de tables ?");
int nbTables = Convert.ToInt32(Console.ReadLine());


//for (int i = 1; i <= largeurTables; i++)
//{
//    Console.Write($"{i,largeurCol}");
//}
//Console.WriteLine();


//string sousBarre = string.Concat(Enumerable.Repeat("-", largeurCol));
//string barre = string.Concat(Enumerable.Repeat(sousBarre, largeurTables));

//Console.WriteLine(barre);


//for (int i = 1; i <= nbTables; i++)
//{
//    for (int j = 1; j <= largeurTables; j++)
//        Console.Write($"{i * j,largeurCol}");
//    Console.WriteLine();
//}


// Avec les |, - et +

//string sousBarre = string.Concat(Enumerable.Repeat("-", largeurCol));
//string barre = "+" + string.Concat(Enumerable.Repeat(sousBarre + "+", largeurTables));

//Console.WriteLine(barre);

//Console.Write("|");
//for (int i = 1; i <= largeurTables; i++)
//{
//    Console.Write($"{i,largeurCol}|");
//}
//Console.WriteLine();

//Console.WriteLine(barre);

//for (int i = 1; i <= nbTables; i++)
//{
//    Console.Write("|");
//    for (int j = 1; j <= largeurTables; j++)
//        Console.Write($"{i * j,largeurCol}|");
//    Console.WriteLine();
//    Console.WriteLine(barre);
//}




// En arc en ciel

List<ConsoleColor> colors = new List<ConsoleColor>()
{
    ConsoleColor.Red,
    ConsoleColor.Magenta,
    ConsoleColor.Blue,
    ConsoleColor.Cyan,
    ConsoleColor.Green,
    ConsoleColor.Yellow
};

string sousBarre = string.Concat(Enumerable.Repeat("-", largeurCol));
string barre = "+" + string.Concat(Enumerable.Repeat(sousBarre + "+", largeurTables));

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(barre);

for (int i = 1; i <= nbTables; i++)
{
    Console.ForegroundColor = colors[i % colors.Count];
    Console.Write("|");
    for (int j = 1; j <= largeurTables; j++)
    {
        Console.ForegroundColor = colors[(i + j) % colors.Count];
        Console.Write($"{i * j,largeurCol}|");
    }
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(barre);
}