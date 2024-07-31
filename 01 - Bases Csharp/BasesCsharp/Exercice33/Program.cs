//char[] alphabet = new char[26];

////for (int i = 0; i < 26; i++)
////    //alphabet[i] = (char)(i + 65);
////    alphabet[i] = (char)(i + 97);

//for (int i = 'A'; i <= 'Z'; i++)
//    alphabet[i - 'A'] = (char)i;

//Console.WriteLine("Affichage des valeurs du alphabetleau :");

//string espaces = "";

//for (int i = 0; i < alphabet.Length; i++)
//{
//    Console.WriteLine(espaces + alphabet[i]);
//    espaces += "  ";
//}


// avec une liste

List<char> alphabet = new List<char>();

for (int i = 'A'; i <= 'Z'; i++)
    alphabet.Add((char)i);

Console.WriteLine("Affichage des valeurs du alphabetleau :");

string espaces = "";

for (int i = 0; i < alphabet.Count; i++)
{
    Console.WriteLine(espaces + alphabet[i]);
    espaces += "  ";
}