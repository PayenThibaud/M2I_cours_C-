using Correction01Personnage.Data;
using Correction01Personnage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction01Personnage.UI
{
    internal class IHM
    {

        private void AfficherTitre()
        {
            Console.WriteLine(@"
  ____                     _   _                  
 |  _ \ ___ _ __ ___  ___ | \ | | __ _  __ _  ___ 
 | |_) / _ \ '__/ __|/ _ \|  \| |/ _` |/ _` |/ _ \
 |  __/  __/ |  \__ \ (_) | |\  | (_| | (_| |  __/
 |_|   \___|_|  |___/\___/|_| \_|\__,_|\__, |\___|
                                       |___/ 
");
        }

        private void AfficherMenu()
        {
            Console.WriteLine("1. Créer un personnage");
            Console.WriteLine("2. Mettre à jour un personnage");
            Console.WriteLine("3. Afficher tous les personnages");
            Console.WriteLine("4. Taper un personnage");
            Console.WriteLine("5. Afficher les personnages ayant des PVs supérieur à la moyenne");
            Console.WriteLine("0. Quitter");
        }

        private void CreerPersonnage()
        {
            Console.Write("Pseudo: ");
            string pseudo = Console.ReadLine() ?? "";

            Console.Write("Saisir vie: ");
            int.TryParse(Console.ReadLine(), out int vie);

            Console.Write("Saisir armure: ");
            int.TryParse(Console.ReadLine(), out int armure);

            Console.Write("Saisir dégât: ");
            int.TryParse(Console.ReadLine(), out int degat);


            using ApplicationDbContext context = new ApplicationDbContext();

            context.Personnages.Add(new Personnage()
            {
                Pseudo = pseudo,
                Vie = vie,
                Armure = armure,
                Degat = degat
            });

            context.SaveChanges();
        }

        private void ModifierPersonnage()
        {
            // Recherche d'un personnage par son ID
            Console.Write("Saisir l'id du personnage: ");
            int.TryParse(Console.ReadLine(), out int id);

            using ApplicationDbContext context = new ApplicationDbContext();

            // Find permet de rechercher par rapport à la Primary Key !
            var personnage = context.Personnages.Find(id);

            // Si le personnage n'existe pas, on quitte la méthode
            if (personnage is null)
            {
                Console.WriteLine($"Impossible de trouver le personnage avec l'id: ${id}");
                return;
            }

            // On modifie les informations si l'utilisateur saisie quelque chose
            Console.Write("Saisir un pseudo: ");
            string pseudo = Console.ReadLine() ?? "";
            // Vérification pour savoir si la chaine n'est ni nulle ni vide
            personnage.Pseudo = string.IsNullOrEmpty(pseudo) ? personnage.Pseudo : pseudo;

            Console.Write("Saisir dégât: ");
            int.TryParse(Console.ReadLine(), out int degat);
            personnage.Degat = degat > 0 ? degat : personnage.Degat;

            context.Update(personnage);
            context.SaveChanges();
        }

        private void AfficherPersonnages()
        {
            using ApplicationDbContext context = new ApplicationDbContext();

            context.Personnages.ToList().ForEach(p => Console.WriteLine(p));
        }

        private void TaperPersonnage()
        {
            using ApplicationDbContext context = new ApplicationDbContext();

            Console.Write("Saisir l'id du personnage: ");
            int.TryParse(Console.ReadLine(), out int id);

            var personnage = context.Personnages.Find(id);

            // Si le personnage n'existe pas, on quitte la méthode
            if (personnage is null)
            {
                Console.WriteLine($"Impossible de trouver le personnage avec l'id: ${id}");
                return;
            }

            Console.Write("Saisir l'id de la victime: ");
            int.TryParse(Console.ReadLine(), out int idVictime);

            var victime = context.Personnages.Find(idVictime);

            if (personnage is null)
            {
                Console.WriteLine($"Impossible de trouver la victime avec l'id: {id}");
                return;
            }

            // On regarde si la victime a encore de l'armure
            if (victime.Armure > 0)
            {

                // On regarde si les dégâts du personnage vont péter l'armure de la victime
                if (personnage.Degat > victime.Armure)
                {
                    victime.Vie -= personnage.Degat - victime.Armure;
                    victime.Armure = 0;

                    // Si la victime n'a plus de PV, on la delete sinon on la met à jour
                    if (victime.Vie <= 0)
                    {
                        personnage.NombrePersonnesTues++;
                        context.Update(personnage);
                        context.Remove(victime);
                    }
                    else
                    {
                        context.Update(victime);
                    }

                }
                else
                {
                    victime.Armure -= personnage.Degat;
                    context.Update(victime);
                }
            }
            else
            {
                victime.Vie -= personnage.Degat;

                if (victime.Vie <= 0)
                {
                    personnage.NombrePersonnesTues++;
                    context.Update(personnage);
                    context.Remove(victime);
                }
                else
                {
                    context.Update(victime);
                }
            }

            context.SaveChanges();
        }

        private void MoyennePv()
        {
            using ApplicationDbContext context = new ApplicationDbContext();

            double moyenne = context.Personnages.Average(p => p.Armure + p.Vie);

            context.Personnages
                .Where(p => p.Armure + p.Vie > moyenne)
                .ToList()
                .ForEach(p => Console.WriteLine(p));
        }

        public void Start()
        {
            AfficherTitre();

            while (true)
            {
                AfficherMenu();
                string choix = Console.ReadLine() ?? "";

                switch (choix)
                {
                    case "1":
                        CreerPersonnage();
                        break;
                    case "2":
                        ModifierPersonnage();
                        break;
                    case "3":
                        AfficherPersonnages();
                        break;
                    case "4":
                        TaperPersonnage();
                        break;
                    case "5":
                        MoyennePv();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
