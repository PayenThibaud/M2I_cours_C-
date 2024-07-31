using Exercice01Chaise;

Console.WriteLine("Création de nouvelles chaises :");

Chaise[] chaises = //new Chaise[3]
{
    new Chaise(),
    new Chaise(2, "Métal", "Noire"),
    new Chaise(6, "Plastique", "Bleue")
};

chaises[0].Afficher();

foreach (Chaise chaise in chaises)
{
    chaise.Afficher();
}


// équivalents :
Console.WriteLine(chaises[0]);
Console.WriteLine(chaises[0].ToString());



object t = new object();
Console.WriteLine(t);
Console.WriteLine(t.ToString());