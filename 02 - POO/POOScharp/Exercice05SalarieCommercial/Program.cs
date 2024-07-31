
using Exercice05SalarieCommercial.Classes;

// On initialise notre liste avec une taille de 20 éléments pour optimiser le stockage des 20 premiers éléments
List<Salarie> mesEmployes = new(20);

// Fonction pour la création et l'ajout d'un Salarie / Commercial à notre listing 
void Creation()
{
    // On pose une à une les questions en commun entre les salariés et les commerciaux
    // de sorte à initialiser des variables qu'un enverra au constructeur de Salarie / Commercial

    Console.Write("Service du salarié : ");
    string service = Console.ReadLine();

    Console.Write("Catégorie du salarié : ");
    string categorie = Console.ReadLine();

    Console.Write("Nom du salarié : ");
    string nom = Console.ReadLine();

    Console.Write("Salaire du salarié : ");
    decimal salaire = decimal.Parse(Console.ReadLine());

    // On demande s'il s'agit d'un commercial

    Console.Write("Ce salarié est-il un commercial ? Y/n");
    string confirmation = Console.ReadLine();


    // Si oui, on poursuit les questions
    if (confirmation.ToUpper()[0] == 'Y')
    {
        Console.Write("Chiffre d'affaire du commercial : ");
        decimal chiffreAffaire = decimal.Parse(Console.ReadLine());

        Console.Write("Commission du salarié : ");
        float commission = float.Parse(Console.ReadLine());

        // et on ajout un commercial
        mesEmployes.Add(new Commercial(service, categorie, nom, salaire, chiffreAffaire, commission));
    }

    // Sinon, on ajout un salarié
    mesEmployes.Add(new Salarie(service, categorie, nom, salaire));
}

// Fonction qui va parcourir les salariés / commerciaux et provoquer leur méthode d'affichage du salaire
void AfficherEmployes()
{
    Console.WriteLine("\n=== Liste des salaires ===");

    foreach(Salarie s in mesEmployes)
    {
        // Grâce à l'override, en fonction de s'il s'agit d'un salarié ou d'un commercial, on aura le code spécifique à la classe et non le code d'un salarié à chaque fois
        s.AfficherSalaire();
    }
}


// Fonction pour trouver un (commenté) / plusieurs salariés ou commerciaux dont le nom commence par une valeur saisie
void RechercherEmploye()
{
    Console.Write("Nom de l'employé: ");
    string nom = Console.ReadLine() ?? "";

    //Salarie? found = mesEmployes.Find(e => e.Nom.StartsWith(nom));

    // On fait une recherche dans notre listing via Linq (méthode .Where()) 
    List<Salarie> found = mesEmployes.Where(e => e.Nom.ToLower().StartsWith(nom.ToLower())).ToList();

    //if (found is not null)
    //{
    //    found.AfficherSalaire();
    //}

    // Si on en a trouvé au moins 1...
    if (found.Count > 0)
    {

        // On parcourt le listing en lecture seule
        foreach(Salarie s in found)
        {
            // On provoque la méthode .AfficherSalaire() qui rapellons le, est overridée chez Commercial
            s.AfficherSalaire();
        }
    }
}