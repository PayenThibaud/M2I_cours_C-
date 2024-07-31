using Exercice07Figure.Classes;

Figure triangle = new Triangle(new Point(-2.0, 1.5), 4.0, 8.0);
Figure carre = new Carre(new Point(1.0, 1.0), 1.25);
Figure rectangle = new Rectangle(new Point(0.0, 0.0), 4.0, 2.0);

Console.WriteLine(triangle);
Console.WriteLine(carre);
Console.WriteLine(rectangle);

Console.WriteLine("\nDéplacement du carré...\n");

carre.Deplacement(-2.0, 5.0);

Console.WriteLine(carre);

Console.WriteLine("\nDéformation du carré...\n");

Figure figureInconnue = ((Carre)carre).Deformer(2.0, 1.0);

Console.WriteLine(figureInconnue);