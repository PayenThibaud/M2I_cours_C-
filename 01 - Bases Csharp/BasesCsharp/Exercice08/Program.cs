//var prixHT = double.Parse(Console.ReadLine());
//var tva = double.Parse(Console.ReadLine());
//var taxe = (prixHT * tva) / 100;
//var prixTotal = prixHT + taxe;


Console.WriteLine("Entrez le prix HT (en euros) :");
float prixHT = float.Parse(Console.ReadLine());
Console.WriteLine("Entrez le taux de TVA (en %) :");
float txTVA = float.Parse(Console.ReadLine()); // / 100;
float montantTVA = prixHT * txTVA / 100;
Console.WriteLine($"Le montant de la TVA est de {montantTVA} euros");
Console.WriteLine($"Le prix TTC est de {prixHT + montantTVA} euros");
