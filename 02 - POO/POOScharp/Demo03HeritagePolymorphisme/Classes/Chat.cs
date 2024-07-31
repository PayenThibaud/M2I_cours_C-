using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo03HeritagePolymorphisme.Classes
{
    // Pour indiquer que l'on hérite d'une classe, on va utiliser la notation suivante: 

    // Ici Chat hérite de Mammal
    internal class Chat : Mammal
    {
        private bool _drinksMilk;

        // Pour faire appel au constructeur de la classe héritée, la syntaxe est:

        // public NomClasseEnfant(params) : base(params pour parent) { code métier... }
        public Chat(string name, int age, bool drinksMilk) : base(name, age)
        {
            _drinksMilk = drinksMilk;
        }

        public void NomMethode()
        {
            // De par l'héritage, on a accès aux champs protégés de notre parent
            Console.WriteLine(this._name);

            // Cela ne change pas le fait que l'on a accès à nos champs privés également
            Console.WriteLine(this._drinksMilk);

            // On a également accès aux propriétés, qui sont héritées ici car publiques
            Console.WriteLine(this.Name);
        }

        public override void MakeSound()
        {
            Console.WriteLine("Miaou!");
        }
    }
}
