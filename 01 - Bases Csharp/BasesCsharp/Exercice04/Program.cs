Console.Write("Veuillez saisir votre nom : ");
string nom = Console.ReadLine();
Console.Write("Veuillez saisir votre prénom : ");
string prenom = Console.ReadLine();
Console.Write("Veuillez saisir votre age : ");
string ageChaine = Console.ReadLine();

//int age = Convert.ToInt32(ageChaine);
int age = int.Parse(ageChaine);

Console.WriteLine("Bonjour " + prenom + " " + nom + ", vous avez " + age + " ans");

Console.WriteLine($"Bonjour {prenom} {nom}, vous avez {age} ans");
