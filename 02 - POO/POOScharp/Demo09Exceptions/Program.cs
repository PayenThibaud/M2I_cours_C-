// See https://aka.ms/new-console-template for more information
using Demo09Exceptions;

var p = new Personne();

p.Prenom = "Arthur";
p.Nom = "Dennetière";

try
{
    p.Age = -3;
} catch(Exception e)
{
    if(e is AgeException)
    {
        Console.WriteLine(e.Message);
    } else
    {
        Console.WriteLine(e.Message);
    }
}

