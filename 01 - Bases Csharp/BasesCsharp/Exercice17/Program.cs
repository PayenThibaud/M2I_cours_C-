Console.WriteLine("--- Quelle boisson souhaitez-vous? ---\n");
Console.WriteLine("Liste des boisons disponibles :");
Console.WriteLine("\t1)Eau plate");
Console.WriteLine("\t2)Eau gazeuse");
Console.WriteLine("\t3)Coca-Cola");
Console.WriteLine("\t4)Fanta");
Console.WriteLine("\t5)Sprite");
Console.WriteLine("\t6)Orangina");
Console.WriteLine("\t7)7up");
Console.Write("Faites votre choix (1 à 7) :");

//Console.WriteLine(@"--- Quelle boisson souhaitez-vous? ---
//Liste des boisoons disponibles :
//    1)Eau plate
//    2)Eau gazeuse
//    3)Coca-Cola
//    4)Fanta
//    5)Sprite
//    6)Orangina
//    7)7up
//Faites votre choix (1 à 7) :");


string choix = Console.ReadLine()!;
string boisson = "";
bool estMauvaisChoix = false;

switch (choix)
{
	case "1":
        boisson = "Eau plate";
        break;
    case "2":
        boisson = "Eau gazeuse";
        break;
    case "3":
        boisson = "Coca-Cola";
        break;
    case "4":
        boisson = "Fanta";
        break;
    case "5":
        boisson = "Sprite";
        break;
    case "6":
        boisson = "Orangina";
        break;
    case "7":
        boisson = "7up";
        break;
    default:
        Console.WriteLine("Mauvais choix!");
        estMauvaisChoix = true;
        break;
}

//if (!estMauvaisChoix)
//if (boisson == "")
if (!string.IsNullOrEmpty(boisson))
        Console.WriteLine($"\nVotre {boisson} est servi(e)...");