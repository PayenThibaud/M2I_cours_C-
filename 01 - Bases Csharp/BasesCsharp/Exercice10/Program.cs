Console.WriteLine("--- La lettre est-elle une voyelle ? ---".ToUpper());
Console.Write("Entrez une lettre : ");
string letter = Console.ReadLine()!.ToUpper();
//char premiereLettre = letter[0];

//if (letter == "A" 
//    || letter == "E" 
//    || letter == "I" 
//    || letter == "O" 
//    || letter == "U" 
//    || letter == "Y")

if (letter.Length != 1)
    Console.WriteLine("Saisie Incorrecte !");
else if ("AEIOUY".Contains(letter))
    Console.WriteLine("Cette lettre est une voyelle");
else
    Console.WriteLine("Cette lettre n'est pas une voyelle");

