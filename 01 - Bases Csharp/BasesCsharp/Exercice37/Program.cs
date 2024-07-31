Console.WriteLine("Enumération du tableau avec un foreach :");
string[] moisAnnee =
{
    "Janvier",
    "Février",
    "Mars",
    "Avril",
    "Mai",
    "Juin",
    "Juillet",
    "Août",
    "Septembre",
    "Octobre",
    "Novembre",
    "Décembre"
};

string tabulations = "";

foreach (string mois in moisAnnee)
{
    Console.WriteLine(tabulations + mois);
    tabulations += "\t";
}

