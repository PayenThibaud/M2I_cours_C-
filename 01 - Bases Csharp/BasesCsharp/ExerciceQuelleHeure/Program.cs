//void QuelleHeure (string heure = "12h00")
//{
//    Console.WriteLine($"Il est {heure}");
//}

//QuelleHeure();
//QuelleHeure("14h00");

void BonjourQuelleHeure( string nom, string heure = "12h00", params string[] chaines)
    // ATTENTION A L'ORDRE: +obligatoire > +facultatifs > params
{
    Console.WriteLine($"Bonjour {nom}, il est {heure}");
    foreach(string chaine in chaines)
    {
        Console.WriteLine(chaine);
    }
}

BonjourQuelleHeure("Benoit");
BonjourQuelleHeure("Benoit", "14h00", "chaine1", "chaine2", "chaine3");

// Possible de préciser les noms des paramètres
BonjourQuelleHeure(nom: "Guillaume", heure: "16h00", chaines: new string[] { "a", "b" });
BonjourQuelleHeure("Guillaume", chaines: new string[] { "a", "b" });
BonjourQuelleHeure(nom: "Guillaume", chaines: new string[] { "a", "b" });

