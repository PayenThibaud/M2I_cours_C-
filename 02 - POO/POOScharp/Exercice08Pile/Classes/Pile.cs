using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice08Pile.Classes
{
    internal class Pile<Blabla>
    {
        private Blabla[] _elements;
        private int _count;

        // Pour créer une propriété d'indéxation, on peut utiliser la syntaxe <protected | public> <TypeDeRetour> this[<Type de l'indéxeur> <nom de la variable à utiliser dans le code de l'indexeur>]
        //public Blabla this[int index]
        //{
        //    get
        //    {
        //        return _elements[index];
        //    }
        //}

        // Il existe une version plus light si on a pas besoin de vérification particulière
        //public Blabla this[int index]
        //{
        //    get => _elements[index];
        //    set => _elements[index] = value;
        //}

        // Pour une syntaxe encore plus courte, on peut utiliser celle ci-dessous:
        public Blabla this[int index] => _elements[index];

        public Pile()
        {
            _elements = new Blabla[0];
            _count = 0;
        }

        public Pile(int taille) : this()
        {
            _elements = new Blabla[taille];
        }

        public void Empile(Blabla input)
        {
            // Si on a déjà atteind la limite de notre pile (plus de place disponible)
            if (_count >= _elements.Length)
            {
                // On créé un nouveau tableau de taille plus importante
                Blabla[] newArray = new Blabla[_elements.Length + 1];
                // On copie les valeurs de notre tableau actuel dans le nouveau tableau à partir du début
                _elements.CopyTo(newArray, 0);
                // On stocke en dernier élément de notre tableau plus grand la valeur que l'on voulait stocker de base
                newArray[^1] = input;
                // On augmente le compteur pour être au courant de la taille et de l'emplacement actuel du dernier élément de notre pile
                _count++;

                // On re-affecte le tableau plus grand en tant que référence stockée dans le tableau des éléments de la pile
                _elements = newArray;
            } else // Si on avait encore de la place
            {
                // On stocke simplement à la place actuellement disponible l'élément voulu, puis on indique qu'on travaillera par la suite à l'emplacement suivant de notre tableau
                _elements[_count++] = input;
            }
        }

        public Blabla? Depile()
        {
            // Si notre pile est vide, on retourne directement la valeur par défaut de notre futur type (idéalement, on lèverait une exception)
            if (_count == 0) return default(Blabla);
            
            // On récupère le dernier élément ajouté qui a de l'intérêt
            Blabla dernierElementAjoute = _elements[_count - 1];

            // On créé un tableau de taille plus petite pour stocker les autres valeurs
            Blabla[] tableauPlusPetit = new Blabla[_count - 1];

            // Pour obtenir, dans un tableau, une portion de celui-ci, on va utiliser une tranche de tableau. Pour en obtenir une, on peut utiliser les méthodes de Linq...
            _elements.Take(_count - 1).ToArray().CopyTo(tableauPlusPetit, 0);

            // Ou la notation [début..fin] disponible depuis C# 8.0
            _elements[0..(_count - 1)].CopyTo(tableauPlusPetit, 0);

            // On modifie le compteur pour savoir que l'on a retiré un élément intéressant
            _count--;

            // On modifie notre tableau interne pour qu'il pointe vers le tableau plus petit
            _elements = tableauPlusPetit;

            // On retourne l'élément qu'on a retiré
            return dernierElementAjoute;
        }

        public Blabla? Recupere(int index)
        {
            if (_count == 0) return default(Blabla);

            // On l'élément qui nous intéresse
            Blabla elementQuiNousInteresse = _elements[index];

            // On créé un tableau de taille plus petite pour stocker les autres valeurs
            Blabla[] tableauPlusPetit = new Blabla[_count - 1];

            // On obtient tous les éléments avant celui retiré via une tranche allant de 0 à l'index qu'on a retiré (il sera exclu)
            Blabla[] elementsAvantCeluiRetire = _elements[..index];

            // On obtient tous les éléments après celui retiré via une tranche allant de l'index retiré + 1 à la valeur de _count (nombre d'éléments désirables)
            Blabla[] elementsApresCeluiRetire = _elements[(index + 1).._count];
            elementsAvantCeluiRetire.CopyTo(tableauPlusPetit, 0);
            elementsApresCeluiRetire.CopyTo(tableauPlusPetit, elementsAvantCeluiRetire.Length - 1);


            // On modifie le compteur pour savoir que l'on a retiré un élément intéressant
            _count--;

            // On modifie notre tableau interne pour qu'il pointe vers le tableau plus petit
            _elements = tableauPlusPetit;

            // On retourne l'élément qu'on a retiré
            return elementQuiNousInteresse;
        }

    }
}
