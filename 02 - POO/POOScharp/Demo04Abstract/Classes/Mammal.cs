using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo04Abstract.Classes
{
    // Une classe abstraite est une classe qui est destinée à l'héritage. Il n'est pas possible de créer d'instances d'une classe abstraite, seulement de ses enfants non abstraits
    internal abstract class Mammal
    {
        // Pour rendre disponible des champs dans une classe et également dans les classes enfants qui choisissent d'hériter de notre classe, on utilise le niveau d'accessibilité de 'protected'
        protected string _name;
        protected int _age;

        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }
        public Mammal()
        {
            _name = "Unknown";
            _age = 0;
        }

        public Mammal(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public Mammal(string name) : this()
        {
            _name = name;
        }

        // Une forme de polymorphisme est la capacité d'utiliser le même nom d'une méthode mais avec des paramètres de types / de nombre différent
        void FaireUnSon(string son)
        {
            Console.WriteLine(son);
        }

        void FaireUnSon()
        {
            Console.WriteLine("Hello");
        }

        // Pour préparer une méthode à la redéfinition, il nous faut utiliser le mot-clé 'virtual'

        // Une méthode abstraite sert à définir une signature de méthode 'en attente'. Il faudra, dans une classe enfant, définir le corps de cette méthode pour rendre la classe valide

        // On ne peut avoir de méthodes abstraites que dans une classe abstraite
        public abstract void MakeSound();


        // Gràce au polymorphisme, on peut ainsi créer des méthodes suivant une même logique interne mais pouvant traiter un, deux, X paramètres de un, deux, X types différents

        // Attention: Il faut conserver le type de retour et le nom de la méthode pour cela
        int Addition(int a, int b)
        {
            return a + b;
        }

        int Addition(int a, int b, int c)
        {
            return a + b + c; 
        }

        float Division(int a, int b)
        {
            return a / b;
        }

        float Division(float a, float b)
        {
            return a / b;
        }

        // Dans une classe, on hérite forcément de la super-classe 'object'. De par cet héritage, on a accès à trois méthodes que l'on peut redéfinir (une autre forme de polymorphisme): 
        // - ToString() => Permet l'affichage en texte de notre objet
        // - Equals() => Permet de vérifier l'égalité entre notre objet et un autre
        // - GetHashCode() => Permet d'obtenir la version hashée de notre objet (pour vérifier son unicité)
        public override string ToString()
        {
            return $"Mammal - Name: {this.Name}, Age : {this.Age}";
        }


        // L'autre méthode souvent redéfinie est la méthode permettant de vérifier l'égalité entre deux objets. Celle-ci se nomme Equals() et est également définie de base dans la superclasse 'object'.

        // Pour changer sa logique et l'appliquer à des critères personnalisés, on va devoir également la redéfinir
        public override bool Equals(object? obj)
        {
            // Si l'objet passé en paramètre est un autre mammifère...
            if (obj is Mammal)
            {

                // On transforme cet objet en mammifère via casting pour éviter de caster plein de fois par la suite dans le but d'accéder à ses spécificités
                Mammal objAsMammal = (Mammal) obj;

                // Ici on base notre égalité sur le nom et l'age des deux mammifères
                return this.Name == objAsMammal.Name && this.Age == objAsMammal.Age;
            }

            return false;
        }

        // Une autre façon plus simple d'avoir le même résultat aurait été cette méthode. Cependant, les conventions recommandent de faire cette logique d'égalité avec Equals(), non avec une autre méthode.
        public bool EstLeMeme(Mammal autre)
        {
            return this.Name == autre.Name && this.Age == autre.Age;
        }
    }
}
