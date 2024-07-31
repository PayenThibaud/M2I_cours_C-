using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TP02Hotel.Classes
{
    internal class Hotel
    {
        private DateTime _currentDate = DateTime.Now;
        private Dictionary<string, Client> _clients;
        private Dictionary<int, Chambre> _chambres;
        private HashSet<Reservation> _reservations;

        public Hotel()
        {
            _clients = GenerateurHotel.GenererClients(10).ToDictionary(x => x.Prenom + " " + x.Nom);
            _chambres = GenerateurHotel.GenererChambres(10).ToDictionary(x => x.Numero);
            _reservations = GenerateurHotel.GenererReservations(10, DateTime.Now.AddMonths(2), DateTime.Now.AddMonths(3), _clients.Values, _chambres.Values).ToHashSet();
        }

        private void AnnulerReservation()
        {
            Console.Write("Quelle réservation doit être annulée ? ");
            string searchInput = Console.ReadLine() ?? "";

            Reservation? found = _reservations.FirstOrDefault(x => x.Id == searchInput);

            if (found is null)
            {
                Console.WriteLine("Il n'existe aucune réservation avec cet ID !");
                return;
            }

            _reservations.Remove(found);
            Console.WriteLine("Réservation annulée...");

        }

        private void FaireCheckOut()
        {
            Console.Write("Quelle réservation doit être payée ? ");
            string searchInput = Console.ReadLine() ?? "";

            Reservation? found = _reservations.FirstOrDefault(x => x.Id == searchInput);

            if (found is null)
            {
                Console.WriteLine("Il n'existe aucune réservation avec cet ID !");
                return;
            }

            Console.WriteLine($"Le client ({found.Client?.NomComplet}) doit à l'hôtel {Math.Round(found.SommeTotale, 2)}€");
            Console.Write("La somme a-t-elle été payée ? Y/n");
            string? payAnswer = Console.ReadLine();
            if (string.IsNullOrEmpty(payAnswer) || payAnswer.ToUpper() == "Y") _reservations.Remove(found);
            else Console.WriteLine("Annulation du check-out...");
        }

        private void FaireCheckIn()
        {
            Console.Write("Quelle personne va faire une réservation ? ");
            string searchInput = Console.ReadLine() ?? "";

            Client? clientForReservation;
            if(!_clients.TryGetValue(searchInput, out clientForReservation))
            {
                Console.WriteLine("Personne non présente dans le listing ! Création de nouveau client...");

                Console.Write("Prénom de la personne: ");
                string prenom = Console.ReadLine() ?? "";

                Console.Write("Nom de la personne: ");
                string nom = Console.ReadLine() ?? "";

                Console.Write("Téléphone de la personne: ");
                string telephone = Console.ReadLine() ?? "";

                clientForReservation = new()
                {
                    Prenom = prenom,
                    Nom = nom,
                    Telephone = telephone
                };
            } 

            
            Console.Write("Combien de lit souhaite-t-il réserver ? ");
            if (int.TryParse(Console.ReadLine(), out int nbLits))
            {
                Console.WriteLine("Quelle est la date de début de la réservation ? ");
                DateTime.TryParse(Console.ReadLine(), out DateTime debut);
                Console.WriteLine("Quelle est la date de fin de la réservation ? ");
                DateTime.TryParse(Console.ReadLine(), out DateTime fin);

                var reservationsPourCettePeriode = _reservations.Where(x => x.Debut.CompareTo(debut) <= 0 && x.Fin.CompareTo(fin) >= 0);

                var chambresDispos = _chambres.Values.Except(reservationsPourCettePeriode.SelectMany(x => x.Chambres)).ToHashSet();

                if (chambresDispos.Count > 0 && chambresDispos.Aggregate(0, (sum, x) => sum + x.NbLits) >= nbLits)
                {
                    HashSet<Chambre> chambresSelectionnees = new();

                    while (nbLits > 0)
                    {
                        Chambre aAjouter = chambresDispos.First(x => x.NbLits == chambresDispos.Max(x => x.NbLits));
                        chambresSelectionnees.Add(aAjouter);
                        nbLits -= aAjouter.NbLits;
                        chambresDispos.Remove(aAjouter);
                    }

                    _reservations.Add(new()
                    {
                        Chambres = chambresSelectionnees,
                        Client = clientForReservation,
                        Debut = debut,
                        Fin = fin
                    });

                } else
                {
                    Console.WriteLine("Impossible de réaliser cette réservation avec les paramètres demandés ! Abandon...");
                }

            } else
            {
                Console.WriteLine("Valeur incorrecte ! Abandon...");
            }
            
        }

        private void AfficherReservations()
        {
            if (_reservations.Count <= 0)
            {
                Console.WriteLine("Il n'y a aucune réservation dans le listing...");
            } else
            {
                Console.WriteLine("=== Finies ===");
                foreach (var r in _reservations.Where(x => x.Statut == StatutReservation.FINI))
                {
                    Console.WriteLine(r);
                }

                Console.WriteLine("\n=== En cours ===");
                foreach (var r in _reservations.Where(x => x.Statut == StatutReservation.EN_COURS))
                {
                    Console.WriteLine(r);
                }

                Console.WriteLine("\n=== A Venir ===");
                foreach (var r in _reservations.Where(x => x.Statut == StatutReservation.PREVU))
                {
                    Console.WriteLine(r);
                }
            }

        }

        private void AvancerUnJour()
        {
            _currentDate = _currentDate.AddDays(1);
            if (_reservations.Where(x => x.Statut == StatutReservation.FINI).Count() >= 0)
            {
                Console.WriteLine("Attention ! Des réservations sont à payer ! ");
                foreach (var r in _reservations.Where(x => x.Statut == StatutReservation.FINI))
                {
                    Console.WriteLine(r);
                }
            }
        }

        public void Gestion()
        {
            while (true)
            {
                Console.Write("\n=== MENU PRINCIPAL ===" +
                    "\n1. Voir les réservations" +
                    "\n2. Faire une réservation" +
                    "\n3. Faire un check-out" +
                    "\n4. Annuler une réservation" +
                    "\n5. Avancer d'une journée" +
                    "\n0. Quitter le programme" + 
                    "\n\nVotre choix: ");

                if (int.TryParse(Console.ReadLine() ?? "0", out int choix))
                {
                    switch (choix)
                    {
                        case 1:
                            AfficherReservations();
                            break;
                        case 2:
                            FaireCheckIn();
                            break;
                        case 3:
                            FaireCheckOut();
                            break;
                        case 4:
                            AnnulerReservation();
                            break;
                        case 5:
                            AvancerUnJour();
                            break;
                        case 0:
                            Console.WriteLine("Merci d'avoir utilisé le programme !"
                                + "\nAu revoir...");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Votre choix ne fait pas partie des options disponibles");
                            break;
                    }
                } else
                {
                    Console.WriteLine("Merci d'entrer un nombre ;)");
                }

                
            }

        }
    }
}
