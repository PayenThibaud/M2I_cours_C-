Console.WriteLine("--- Dans quelle catégorie mon enfant est il ...? ---");
Console.Write("Entrez l'age de l'enfant : ");
//int age = Convert.ToInt32();

if (!int.TryParse(Console.ReadLine(), out int age) || age < 0 || age > 125)
{
    Console.WriteLine("Saisie invalide");
    //return;
}
else
    switch (age)
    {
        case < 3:
            Console.WriteLine("Vous êtes trop jeune");
            break;
        case <= 6:
            Console.WriteLine("Baby");
            break;
        case <= 8:
            Console.WriteLine("Poussin");
            break;
        case <= 10:
            Console.WriteLine("Pupille");
            break;
        case <= 12:
            Console.WriteLine("Minime");
            break;
        case <= 17:
            Console.WriteLine("Cadet");
            break;
        default:
            Console.WriteLine("Vous êtes trop vieux");
            break;
    }