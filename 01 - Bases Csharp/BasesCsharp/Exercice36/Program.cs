Console.WriteLine("***** Tableaux de notes *****");

int nbNotes;
bool saisieCorrecte;

Console.WriteLine("Combien de notes comportera le tableau : ");
do
{
    saisieCorrecte = int.TryParse(Console.ReadLine(), out nbNotes);

    if (!saisieCorrecte)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("\tErreur de saisie, merci de saisir un chiffre/nombre : ");
        Console.ResetColor();
    }
} while (!saisieCorrecte);

double[] notes = new double[nbNotes];

Console.WriteLine($"\nMerci de saisir les {nbNotes} notes ");

for (int i = 0; i < nbNotes; i++)
{
    Console.Write($"\t-Note {i + 1} : ");
    do
    {
        saisieCorrecte = double.TryParse(Console.ReadLine(), out notes[i]) && notes[i] >= 0 && notes[i] <= 20;

        if (!saisieCorrecte)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\tErreur de saisie, merci de saisir un chiffre/nombre pour la note {i + 1}: ");
            Console.ResetColor();
        }
    } while (!saisieCorrecte);
}

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("\n--- Liste des notes ---");
    Console.ResetColor();
    for (int i = 0; i < nbNotes; i++)
    {
    Console.WriteLine($"La note {i + 1} est de : {notes[i]}/20");
    }

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"\n--- La note max est : {notes.Max()}/20 ");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"--- La note min est : {notes.Min()}/20");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"--- La moyenne est de : {Math.Round(notes.Average(), 2)}/20");
Console.ResetColor();

