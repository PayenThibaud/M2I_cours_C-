using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo05Interfaces.Classes
{
    // Lorsque l'on créé une classe servant uniquement à faire transiter des données, on ne va pas s'amuser à créer des champs, des propriétés et un constructeur. Cela pour deux raisons: 

    // * On doit écrire beaucoup de ligne de code pour au final une classe ayant un objectif très précis et qui va exister en mémoire durant un laps de temps relativement court
    // * On aimerait se passer de devoir écrire X variations de notre constructeur de façon à rendre l'initialisation de notre classe plus aisée, que l'on veuille remplir tous ses champs, aucun, ou seulement certains
    internal class ContactDTO
    {
        //private string _nom;
        //private string _prenom;
        //private int _age;

        //public string Nom { get => _nom; }
        //public string Prenom { get => _prenom; }
        //public string Age { get => _age; }

        //public ContactDTO()
        //{
        //    _nom = "DOE";
        //    _prenom = "John";
        //    _age = 0;
        //}

        //public ContactDTO(string nom) : this()
        //{
        //    _nom = nom;
        //}

        //public ContactDTO(string nom, string prenom) : this(nom)
        //{
        //    _prenom = prenom;
        //}

        //public ContactDTO(string nom, string prenom, int age) : this(nom, prenom)
        //{
        //    _age = age;
        //}


        public string Nom { get; init; } = "DOE";
        public string Prenom { get; init; } = "John";
        public int Age { get; init; } = 0;


    }
}
