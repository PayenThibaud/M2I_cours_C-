Console.WriteLine("Entrez le capital de départ (en euros) :");
float capitalDepart = float.Parse(Console.ReadLine());
Console.WriteLine("Entrez le taux d'intérêts (en %) :");
float txInt = float.Parse(Console.ReadLine()); // / 100;
Console.WriteLine("Entrez la durée de l'épargne (en années) :");
float durree = float.Parse(Console.ReadLine());

double montantInterets = capitalDepart * Math.Pow(1 + txInt / 100, durree) - capitalDepart;
double capitalFinal = capitalDepart + montantInterets;

//Console.WriteLine($"Le montant des intérets sera de {montantInterets} euros après {durree} ans");
//Console.WriteLine($"Le capital final sera de {capitalFinal}");

//Console.WriteLine($"Le montant des intérets sera de {Math.Round(montantInterets,2)} euros après {durree} ans");
//Console.WriteLine($"Le capital final sera de {Math.Round(capitalFinal)}");


Console.WriteLine($"Le montant des intérets sera de {montantInterets:F2} euros après {durree} ans");
Console.WriteLine($"Le capital final sera de {capitalFinal:F2}");