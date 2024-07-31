//float cote= float.Parse(Console.ReadLine());
//float perimetre = cote * 4;
////float aire = cote * cote;
//double aire = Math.Pow(cote,2);


Console.Write("Entrez la longueur d'un côté du carré (en cm) : ");
float cote = Convert.ToSingle(Console.ReadLine()); //float cote = float.Parse(Console.ReadLine());

Console.WriteLine("Périmètre :" + cote * 4);
Console.WriteLine("Aire :" + cote * cote);
Console.WriteLine("Aire :" + Math.Pow(cote, 2));


Console.Write("Entrez la longueur d'un rectangle (en cm) : ");
decimal longueur = Convert.ToDecimal(Console.ReadLine());
Console.Write("Entrez la largeur d'un rectangle (en cm) : ");
decimal largeur = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Périmètre :" + (longueur + largeur) * 2);
Console.WriteLine("Aire :" + longueur * largeur);
