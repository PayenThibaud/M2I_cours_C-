using Correction02Hotel.Data;
using Correction02Hotel.Models;
using Correction02Hotel.Repositories;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Correction02Hotel
{
    internal class IHM
    {
        // On définit tous les repositories qui vont nous être utile pour l'application
        private readonly IGenericRepository<Client> _clientRepository;
        private readonly IGenericRepository<Reservation> _reservationRepository;
        private readonly IGenericRepository<Chambre> _chambreRepository;
        private readonly IGenericRepository<ReservationChambre> _reservationChambreRepository;

        public IHM()
        {
            // On instancie nos repositories avec l'implémentation GenericRepository
            // Ici on va utiliser ce qu'on appelle de l'injection de dépendance, c'est à dire qu'on va injecter nos dépendance directement dans le constructeur
            ApplicationDbContext context = new ApplicationDbContext();
            _clientRepository = new GenericRepository<Client>(context);
            _reservationRepository = new GenericRepository<Reservation>(context);
            _chambreRepository = new GenericRepository<Chambre>(context);
            _reservationChambreRepository = new GenericRepository<ReservationChambre>(context);
        }

        private void AfficherMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Menu Principal =====\n");
            Console.WriteLine("1. Afficher la liste des clients");
            Console.WriteLine("2. Ajouter un client");
            Console.WriteLine("3. Liste des réservations d'un client");
            Console.WriteLine("4. Afficher les chambres disponibles");
            Console.WriteLine("5. Ajouter une réservation");
            Console.WriteLine("6. Annuler une réservation");
            Console.WriteLine("7. Liste des réservations");

            Console.WriteLine("0. Quitter\n");

            Console.Write("Votre choix : ");
        }

        public void AfficherClients()
        {
            Console.Clear();
            Console.WriteLine("===== Liste des clients (A-Z) =====\n");

            // On Récupère les clients, puis on les trie par rapport à leur nom
            List<Client> clients = _clientRepository.GetAll().OrderBy(c => c.Nom).ToList();

            clients.ForEach(c => Console.WriteLine($"{c.Identifiant} - {c.Nom.ToUpper()} {c.Prenom}"));

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        private void AjouterClient()
        {
            Console.Clear();
            Console.WriteLine("===== Ajouter un client =====\n");
            Console.Write("Nom : ");
            string nom = Console.ReadLine()!;
            Console.Write("Prénom : ");
            string prenom = Console.ReadLine()!;
            Console.Write("Téléphone : ");
            string telephone = Console.ReadLine()!;

            Client client = new Client() { Nom = nom, Prenom = prenom, Telephone = telephone };

            _clientRepository.Add(client);

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        private void ListerReservationsClient()
        {
            Console.Clear();
            Console.WriteLine("===== Liste des réservations d'un client =====\n");
            Console.Write("Id du client : ");
            int.TryParse(Console.ReadLine(), out int id);

            Client? client = _clientRepository.GetOneById(id);

            if (client is null)
            {
                Console.WriteLine("Client introuvable");
                Console.ReadKey();
                return;
            }

            // On récupère les réservations où l'id du client est présent à l'aide d'une expression LinQ
            List<Reservation> reservations = _reservationRepository.GetAll(r => r.ClientIdentifiant == client.Identifiant);

            // Si le client n'a aucune réservation, on affiche un message
            if (reservations.Count < 1)
            {
                Console.WriteLine("Ce client n'a aucune réservation");
                Console.ReadKey();
                return;
            }

            // Affichage du statut des réservation du client
            reservations.ForEach(r => Console.WriteLine($"id: {r.Id}, statut: {r.Statut}"));

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        private void AfficherChambresDisponibles()
        {
            Console.Clear();
            Console.WriteLine("===== Liste des chambres disponibles =====\n");
            List<Chambre> chambres = _chambreRepository.GetAll(c => c.Statut == StatutChambre.Libre);

            chambres.ForEach(c => Console.WriteLine(c.ToJson()));

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        public void AjouterReservation()
        {
            Console.Clear();
            Console.WriteLine("===== Ajouter une réservation =====\n");

            // On cherche le client par son ID
            Console.Write("Id du client : ");
            int.TryParse(Console.ReadLine(), out int idClient);

            Client? client = _clientRepository.GetOneById(idClient);
            
            // On quitte si le client n'existe pas
            if(client is null)
            {
                Console.WriteLine("Aucun client trouvé avec cet id");
                Console.ReadKey();
                return;
            }

            // On parcourt les chambres disponible pour les ajouter à notre réservation
            Console.WriteLine("Saisir les chambres à ajouter aux réservation (-1 pour quitter): ");

            List<Chambre> chambresReservees = new();

            while (true)
            {

                Console.Write("Saisir le n°: ");

                // On quitte la boucle si l'utilisateur saisi -1
                int.TryParse(Console.ReadLine(), out int numeroChambre);
                if(numeroChambre == -1)
                {
                    break;
                }

                var chambre = _chambreRepository.GetOneById(numeroChambre);

                // Vérification de l'existance de la chambre
                if(chambre is null)
                {
                    Console.WriteLine("Chambre introuvable");
                    continue;
                }

                // Vérification du statut de la chambre : NEVER TRUST USER INPUT
                if(chambre.Statut != StatutChambre.Libre)
                {
                    Console.WriteLine("La chambre n'est pas disponible");
                    continue;
                }

                chambresReservees.Add(chambre);
            }

            // Création d'un réservation avec l'id du client
            Reservation reservation = new Reservation() { ClientIdentifiant = client.Identifiant, Statut = StatutReservation.EnCours };

            _reservationRepository.Add(reservation);

            // On créé des ReservationChambre avec la liste de chambre ainsi que la réservation précédemment créée
            chambresReservees.ForEach(chambre =>
            {
                ReservationChambre reservationChambre = new ReservationChambre() { ReservationId = reservation.Id, ChambreNumero = chambre.Numero };
                _reservationChambreRepository.Add(reservationChambre);
            });

            // On met à jour le statut des chambres pour les rendre indisponibles
            chambresReservees.ForEach(chambre =>
            {
                chambre.Statut = StatutChambre.Occupe;
                _chambreRepository.Update(chambre);
            });

            // On modifie le statut de la réservation pour indiquer qu'elle est validée
            reservation.Statut = StatutReservation.Fini;

            _reservationRepository.Update(reservation);
            Console.WriteLine($"Réservation n°{reservation.Id} enregistrée");
            Console.ReadKey();
        }

        private void AnnulerReservation()
        {
            // On récupère la réservation
            Console.Clear();
            Console.WriteLine("===== Annuler une réservation =====\n");
            Console.Write("Id de la réservation : ");
            int.TryParse(Console.ReadLine(), out int idReservation);

            Reservation? reservation = _reservationRepository.GetOneById(idReservation);

            if (reservation is null)
            {
                Console.WriteLine("Aucune réservation avec cet id");
                Console.ReadKey();
                return;
            }

            // Récupération des chambre reservées
            List<ReservationChambre> chambres = _reservationChambreRepository.GetAll(rc => rc.ReservationId == idReservation);

            chambres.ForEach(c =>
            {
                // On met à jour le statut des chambres pour les rendre à nouveau dispo
                var chambre = _chambreRepository.GetOneById(c.ChambreNumero);
                if (chambre is not null)
                {
                    chambre.Statut = StatutChambre.Libre;
                    _chambreRepository.Update(chambre);
                }

            });

            // Changement du statut de la réservation
            reservation.Statut = StatutReservation.Annule;
            _reservationRepository.Update(reservation);

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        private void AfficherReservations()
        {
            Console.WriteLine("===== Liste des réservations =====\n");
            List<Reservation> reservations = _reservationRepository.GetAll();

            reservations.ForEach(c => Console.WriteLine(c.ToJson()));

            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu...");
            Console.ReadKey();
        }

        public void Start()
        {
            while (true)
            {
                AfficherMenu();
                string choix = Console.ReadLine() ?? "";

                switch (choix)
                {
                    case "1":
                        AfficherClients();
                        break;
                    case "2":
                        AjouterClient();
                        break;
                    case "3":
                        ListerReservationsClient();
                        break;
                    case "4":
                        AfficherChambresDisponibles();
                        break;
                    case "5":
                        AjouterReservation();
                        break;
                    case "6":
                        AnnulerReservation();
                        break;
                    case "7":
                        AfficherReservations();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Erreur de saisie");
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
