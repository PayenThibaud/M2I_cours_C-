using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction01Etudiant.Classes
{
    internal class IHM
    {
        public void AfficherMenu()
        {
            Console.WriteLine("1 - Ajouter étudiant");
            Console.WriteLine("2 - Afficher tous les étudiants");
            Console.WriteLine("3 - Afficher les étudiants d'une classe");
            Console.WriteLine("4 - Supprimer un étudiant");
            Console.WriteLine("5 - Mettre à jour un étudiant");
            Console.WriteLine("0 - Quitter");
        }

        public void AfficherEtudiants()
        {
            Etudiant.GetEtudiants().ForEach(e => Console.WriteLine(e.ToString()));
        }

        public void AfficherEtudiantsClasse()
        {
            Console.Write("Saisir le n° de la classe: ");
            int numeroClasse = Int32.Parse(Console.ReadLine());
            Etudiant.GetEtudiants(numeroClasse).ForEach(e => Console.WriteLine(e.ToString()));
        }

        public void AjouterEtudiant()
        {
            string prenom;
            string nom;
            int numeroClasse;
            DateTime dateDiplome;

            Console.Write("Prénom:");
            prenom = Console.ReadLine();

            Console.Write("Nom:");
            nom = Console.ReadLine();

            Console.Write("Numéro classe:");
            numeroClasse = Int32.Parse(Console.ReadLine());

            Console.Write("Date diplome:");
            dateDiplome = DateTime.Parse(Console.ReadLine());

            if (new Etudiant(prenom, nom, numeroClasse, dateDiplome).Save())
            {
                Console.WriteLine($"{prenom} a bien été enregistré !");
            }
            else
            {
                Console.WriteLine($"Erreur lors de l'enregistrement de {prenom}");
            };
        }

        public void SupprimerEtudiant()
        {
            Console.Write("Saisir l'id de l'étudiant à supprimer: ");
            int.TryParse(Console.ReadLine(), out int id);

            var etudiant = Etudiant.GetById(id);

            if (etudiant is null)
            {
                Console.WriteLine("Etudiant introuvable !");
                return;
            }

            if (etudiant.Delete())
            {
                Console.WriteLine($"{etudiant.Prenom} supprimé avec succès!");
            }
            else
            {
                Console.WriteLine($"Erreur lors de la suppression de {etudiant.Prenom}");
            }
        }

        public void EditEtudiant()
        {
            Console.Write("Saisir l'id de l'étudiant à éditer:");
            int.TryParse(Console.ReadLine(), out int id);

            var etudiant = Etudiant.GetById(id);

            if (etudiant is null)
            {
                Console.WriteLine("Etudiant introuvable !");
                return;
            }

            Console.Write("Saisir le prénom: ");
            string p = Console.ReadLine();
            etudiant.Prenom = String.IsNullOrEmpty(p) ? etudiant.Prenom : p;

            Console.Write("Saisir le nom: ");
            string n = Console.ReadLine();
            etudiant.Nom = String.IsNullOrEmpty(n) ? etudiant.Nom : n;

            Console.Write("Saisir le numéro de classe: ");
            int.TryParse(Console.ReadLine(), out int c);
            etudiant.NumeroClasse = c > 0 ? c : etudiant.NumeroClasse;

            Console.Write("Saisir date: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime dateDiplome);
            etudiant.DateDiplome = dateDiplome;

            if (Etudiant.EditEtudiant(id, etudiant))
            {
                Console.WriteLine($"{etudiant.Prenom} édité avec succès!");
            }
            else
            {
                Console.WriteLine($"Erreur lors de l'édition de {etudiant.Prenom}");
            };
        }

        public void Start()
        {
            while(true)
            {
                AfficherMenu();
                string choix = Console.ReadLine();

                switch(choix)
                {
                    case "1":
                        AjouterEtudiant();
                        break;
                    case "2":
                        AfficherEtudiants();
                            break;
                    case "3":
                        AfficherEtudiantsClasse();
                        break;
                    case "4":
                        SupprimerEtudiant();
                        break;
                    case "5":
                        EditEtudiant();
                        break;
                    case "0":
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Erreur de saisie");
                        break;
                }
            }
        }
    }
}
