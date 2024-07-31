decimal indemnite = 0;

Console.Write("Veuillez saisir le dernier salaire :");
decimal salaire = Convert.ToDecimal(Console.ReadLine());
Console.Write("Veuillez saisir l'age du salarié : ");
int age = Convert.ToInt32(Console.ReadLine());
Console.Write("Veuillez saisir l'ancienneté :");
int anciennete = Convert.ToInt32(Console.ReadLine());

//➢ La moitié du salaire d’un mois par année d’ancienneté : pour la tranche d’ancienneté entre 1 ans et 10 ans.
if (anciennete >= 1 && anciennete <= 10)
    indemnite += anciennete * salaire / 2;
//➢ Au-delà de 10 ans un mois de salaire par année d’ancienneté.
else if (anciennete > 10)
    indemnite += 10 * salaire / 2 + (anciennete - 10) * salaire;

//➢ Une indemnité supplémentaire serait allouée aux cadres âgés de plus de 45 ans de :
//    − 2 mois de salaire si le cadre est âgé de 46 à 49 ans.
//    − 5 mois si le cadre est âgé de plus de 50 ans.
if (anciennete >= 1 && age > 45)
    indemnite += (age < 50) ? 2 * salaire : 5 * salaire;

Console.WriteLine($"\nVotre indemnité est de : {indemnite} Euros");