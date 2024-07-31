using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP02Hotel.Classes
{
    internal static class GenerateurHotel
    {
        private static Random rnd = new Random();

        private static string[] _prenoms =
        {
            "John",
            "Albert",
            "Martha",
            "Chloée",
            "Alain",
            "Laurent",
            "Hélène",
            "Laura",
            "Nathalie",
            "Jaina",
            "Thrall",
            "Astarion",
            "Chuck"
        };

        private static string[] _noms =
        {
            "DUPONT",
            "SMITH",
            "SCHWARTZMULLER",
            "ZHENG",
            "BIBOUPOUT",
            "NAKAMURA",
            "TOSCANI"
        };

        public static IEnumerable<Chambre> GenererChambres(int number)
        {

            return Enumerable.Range(1, number).Select(x =>
            {
                int nbBeds = rnd.Next(1, 5);

                return new Chambre()
                {
                    Numero = x / 15 * 100 + x % 15,
                    NbLits = nbBeds,
                    Tarif = decimal.Multiply(nbBeds, 24.50m)
                };
            });
        }

        public static IEnumerable<Client> GenererClients(int number)
        {
            HashSet<Client> result = new();

            for (int i = 0; i < number; i++)
            {
                string prenom = _prenoms[rnd.Next(_prenoms.Length)];
                string nom = _noms[rnd.Next(_noms.Length)];

                if (result.FirstOrDefault(x => x.NomComplet == $"{prenom.ToCapitalized()} {nom.ToUpper()}") is null)
                {
                    result.Add(new Client()
                    {
                        Prenom = prenom,
                        Nom = nom,
                        Telephone = $"+{rnd.Next(45).ToString().PadLeft(2, '0')} {rnd.Next(1000).ToString().PadLeft(3, '0')} {rnd.Next(1000).ToString().PadLeft(3, '0')} {rnd.Next(1000).ToString().PadLeft(3, '0')}"
                    });
                }
                else i--;
            }

            return result;
        }

        public static IEnumerable<Reservation> GenererReservations(int number)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Reservation> GenererReservations(int number, DateTime debut, DateTime fin)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<Reservation> GenererReservations(int number, DateTime debut, DateTime fin, IEnumerable<Client> clients, IEnumerable<Chambre> chambres)
        {
            HashSet<Chambre> chambresDispos = chambres.ToHashSet();
            Client[] clientsAsArray = clients.ToArray();

            HashSet<Reservation> returnValue = new();

            for(int i = 0; i < number; i++)
            {
                if (chambresDispos.Count > 0)
                {
                    var interval = fin - debut;
                    DateTime dbtRes = debut.AddDays(rnd.Next((int)interval.TotalDays));
                    var remainingDays = fin - dbtRes;
                    DateTime finRes = dbtRes.AddDays(rnd.Next((int)remainingDays.TotalDays));

                    var chambresSelectionnees = chambresDispos.Take(2);
                    chambresDispos.ExceptWith(chambresSelectionnees);


                    returnValue.Add(new Reservation()
                    {
                        Debut = dbtRes,
                        Fin = finRes,
                        Client = clientsAsArray[rnd.Next(clientsAsArray.Length)],
                        Chambres = chambresSelectionnees.ToHashSet()
                    });
                }
                else break;
            }

            return returnValue;
        }
    }
}
