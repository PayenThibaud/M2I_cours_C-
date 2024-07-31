using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo05Interfaces.Classes
{
    // Une autre façon de créer des objets complexes permettant le regroupement de X spécificités dans une variable unique est l'utilisation d'un enregistrement (record). 

    // Un record va permettre la création facilité d'un objet dont ses champs sont en lecture seule, ce via une syntaxe allegée.
    // L'autre avantage d'un record est la capacité à vérifier l'égalité des éléments non par par référence mémoire, mais pas valeur de leurs champs

    /* En se servant d'un record, on va donc: 
     * 
     * - Eviter d'avoir à définir des propriétés { get; init; }
     * - Eviter d'avoir à redéfinir la méthode Equals()
     */

    internal record ContactRecord(string nom, string prenom, int age);

    // Une variable de type record classique PEUT référencer deux fois le même ensemble de données, car après tout il s'agit d'un type référence


    // Il est possible, de nous servir d'une variable de type valeur par l'ajout du mot-clé structure qui va ainsi fusionner les avantages d'un record et d'une structure
    internal record struct ContactRecordStruct(string nom, string prenom, int age);

    // Une variable de type record struct ne peut pas référencer deux fois les mêmes valeurs, il y aura création et affectation d'une case mémoire à chaque fois
}
