using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Correction01Etudiant.Classes
{
    internal class Etudiant
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int NumeroClasse { get; set; }
        public DateTime DateDiplome { get; set; }

        private static readonly string connectionString = "Data Source=(localdb)\\demo01ado; Integrated Security = True; Database=Exercice01Etudiant";


        public Etudiant(string prenom, string nom, int numeroClasse, DateTime dateDiplome)
        {
            Prenom = prenom;
            Nom = nom;
            NumeroClasse = numeroClasse;
            DateDiplome = dateDiplome;
        }

        public Etudiant(int id, string prenom, string nom, int numeroClasse, DateTime dateDiplome) : this(prenom, nom, numeroClasse, dateDiplome)
        {
            Id = id;
        }

        public string ToString()
        {
            return $"id:{Id}, prenom:{Prenom}, nom {Nom}, classe:{NumeroClasse}, date diplome {DateDiplome:dd/MM/yyyy}";
        }

        public bool Save()
        {
            using SqlConnection connection = new(Etudiant.connectionString);
            string query = "INSERT INTO etudiant (prenom, nom, numero_classe, date_diplome) VALUES (@prenom, @nom, @numero_classe, @date_diplome) SELECT CAST(SCOPE_IDENTITY() AS INT) ";

            connection.Open();

            using SqlCommand command = new(query, connection);
            command.Parameters.AddWithValue("@prenom", Prenom);
            command.Parameters.AddWithValue("@nom", Nom);
            command.Parameters.AddWithValue("@numero_classe", NumeroClasse);
            command.Parameters.AddWithValue("@date_diplome", DateDiplome);

            try
            {
                int id = (int)command.ExecuteScalar();
                Id = id;
                return id > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public bool Delete()
        {
            using SqlConnection connection = new(Etudiant.connectionString); 
            string query = "DELETE FROM etudiant WHERE id=@id";

            connection.Open();

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", Id);

            try
            {
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected == 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public static Etudiant? GetById(int id)
        {
            using SqlConnection connection = new(Etudiant.connectionString);
            string query = "SELECT id, prenom, nom, numero_classe, date_diplome FROM etudiant WHERE id=@id;";

            connection.Open();

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Etudiant etudiant = new Etudiant(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetDateTime(4));
                return etudiant;
            }

            return null;

        }

        public static List<Etudiant> GetEtudiants(int? numeroClasse = null)
        {
            string query;
            List<Etudiant> etudiants = new();

            using SqlConnection connection = new(Etudiant.connectionString);
            using SqlCommand command = new SqlCommand();

            command.Connection = connection;
            connection.Open();

            if (numeroClasse is null)
            {
                query = "SELECT id, prenom, nom, numero_classe, date_diplome FROM etudiant;";
                command.CommandText = query;
            }
            else
            {
                query = "SELECT id, prenom, nom, numero_classe, date_diplome FROM etudiant WHERE numero_classe=@numero_classe;";
                command.CommandText = query;
                command.Parameters.AddWithValue("@numero_classe", numeroClasse);
            }

            using SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                etudiants.Add(new Etudiant(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetDateTime(4)));
            }

            return etudiants;

        }

        public static bool EditEtudiant(int id, Etudiant etudiant)
        {
            string query = "UPDATE etudiant SET prenom=@prenom, nom=@nom, numero_classe=@numero_classe, date_diplome=@date_diplome WHERE id=@id;";

            using SqlConnection connection = new(Etudiant.connectionString);
            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@prenom", etudiant.Prenom);
            command.Parameters.AddWithValue("@nom", etudiant.Nom);
            command.Parameters.AddWithValue("@numero_classe", etudiant.NumeroClasse);
            command.Parameters.AddWithValue("@date_diplome", etudiant.DateDiplome);
            command.Parameters.AddWithValue("@id", etudiant.Id);

            connection.Open();

            return command.ExecuteNonQuery() == 1;
        }
    }



}
