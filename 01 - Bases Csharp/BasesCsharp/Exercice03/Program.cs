Console.Write("Veuillez saisir votre nom : ");
string nom = Console.ReadLine();
Console.Write("Veuillez saisir votre prénom : ");
string prenom = Console.ReadLine();
Console.WriteLine("Bonjour " + prenom + " " + nom);

// une chaine interpolée (interpolated string)
// agit comme un "moule" dans lequelle on peut insérer des valeurs
Console.WriteLine($"Bonjour {prenom} {nom}");
