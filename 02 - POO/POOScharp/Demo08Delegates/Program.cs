int Add(int a, int b)
{
    return a + b;
}

int Substract(int a, int b)
{
    return a - b;
}

int uneSommeA = Add(4, 2);
int unResteA = Substract(4, 2);

// Pour stocker une fonction dans une variable, on la stocke dans deux types génériques distincts : 

// - Func<> qui permet de stocker des fonctions devant retourner une valeur
// - Action<> qui permet de stocker des procédures (ne retournant rien d'autre que void)

// Lorsque l'on veut créer une fonction anonyme, on peut le faire avec une lambda expression ou via un délégué 
Func<int, int, int> AddBis = delegate (int a, int b)
{
    return a + b;
};

int uneSommeBis = AddBis(4, 2);

// Il est possible de passer en paramètre des fonction à une fonction ou une méthode via les types Func<> et Action<>

// De la sorte, on peut créer une fonction faisant nos instructions mais également qui pourra être étendue via la fonction choisie par l'utilisateur de notre application. Comme ça, on permet à un développeur futur de personnaliser un peu notre code sans lui en donner l'accès direct
void AfficheResultatCalculDeDeuxNombres(int a, int b, Func<int, int, int> leCalcul)
{
    int leResultat = leCalcul(a, b);
    Console.WriteLine($"Le résultat du calcul est : {leResultat}");
}

// ON peut envoyer en paramètre des références de fonctions, des variables du bon type mais également déclarer à la volée le délégué ou l'expression lambda correspondant à la signature demandée
AfficheResultatCalculDeDeuxNombres(4, 2, Add);
AfficheResultatCalculDeDeuxNombres(4, 2, Substract);
AfficheResultatCalculDeDeuxNombres(4, 2, AddBis);
AfficheResultatCalculDeDeuxNombres(4, 2, delegate (int a, int b) { return a * b; });
AfficheResultatCalculDeDeuxNombres(4, 2, (int a, int b) => a + b);

Personne? ChercheDansMesPersonnes(List<Personne> elements, Func<Personne, bool> predicate)
{
    foreach(Personne p in elements)
    {
        if (predicate(p) == true) return p;
    }

    return null;
}

// Si l'on veut stocker des procédures, on fait des variables de type Action<>
Action<int, int> futurCalcul;

futurCalcul = (int a, int b) =>
{
    int leResultat = a + b;
    Console.WriteLine($"Le résultat est {leResultat}");
};

futurCalcul(4, 6);

// Ici, le code ne ferait que l'ajout de la personne en BdD
bool AjouteEnDatabase(Personne input)
{
    // Ajoute en BdD

    return true;
}

// Ici, il ajouterai en Base de données, créerait un message et ce message serait transmit à une fonction choisie par un autre développeur. 
bool AjouteEnDatabaseBis(Personne input, Action<string> faireQqchAvecMessage)
{
    // Ajoute en BdD

    faireQqchAvecMessage($"La personne {input.Prenom} {input.Nom} a été ajoutée en base de données avec succès");

    return true;
}

// Ici l'autre développeur choisi de l'afficher en console, mais il aurait pu vouloir le stocker dans un fichier, envoyer un mail, etc...
AjouteEnDatabaseBis(new Personne() { Prenom = "John", Nom = "DUPONT" }, (string message) =>
{

    Console.WriteLine(message);
});