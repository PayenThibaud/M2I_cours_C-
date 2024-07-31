using Azure.Core;
using Microsoft.Data.SqlClient;
using System.Data;

// connectionString
string connectionString = "Data Source=(localdb)\\demo01ado; Integrated Security=True; Database=contactDB";

//// Création d'un objet SQLConnection présent dans la librairie ADO.NET
//SqlConnection connection = new SqlConnection(connectionString);

//connection.Open();

//if(connection.State == ConnectionState.Open)
//{
//    Console.WriteLine("La connexion est ouverte!");
//} else
//{
//    Console.WriteLine("La connexion n'est pas ouverte :(");
//}

//// Requête
//string prenom = Console.ReadLine() ?? "";
//string nom = Console.ReadLine() ?? "";
//string email = Console.ReadLine() ?? "";

//string req = $"INSERT INTO personne (prenom, nom, email) VALUES ('{prenom}', '{nom}', '{email}')";

//// On instancie un objet de commande qui contiendra la requête, la connexion ainsi qu'une transaction si besoin
//SqlCommand command = new SqlCommand(req, connection);

//// ExecuteNonQuery exécute la requête et renvoie le nombre d'éléments affectés
//int rowsAffected = command.ExecuteNonQuery();

//Console.WriteLine(rowsAffected);

//// Libère la commande SQL
//command.Dispose();

//// Ferme la connexion au serveur
//connection.Close();

// utilisation des paramètres nommés avec binding pour éviter les injections SQL

// Permet de fermer la connexion sans avoir à appeler la méthode manuellement
// https://learn.microsoft.com/fr-fr/dotnet/csharp/language-reference/statements/using
//using (SqlConnection conn = new SqlConnection(connectionString))
//{
//    string request = "INSERT INTO personne (prenom, nom, email) VALUES (@prenom, @nom, @email)";

//    SqlCommand command = new SqlCommand(request, conn);

//    // Syntaxe simplifiée
//    command.Parameters.AddWithValue("@prenom", "Lea");

//    // Syntaxe avec la précision du type
//    command.Parameters.Add("@nom", SqlDbType.VarChar);
//    command.Parameters["@nom"].Value = "dupont";

//    // Utilsiation d'une instance de SqlParameter
//    command.Parameters.Add(new SqlParameter("@email", "lea@dupont.fr"));

//    try
//    {
//        conn.Open();
//        int rowsAffected = command.ExecuteNonQuery();
//        Console.WriteLine($"{rowsAffected} lignes affectées");
//    } catch(Exception e)
//    {
//        Console.WriteLine(e.Message);
//    }

//}

// Lire des enregistrements
using (SqlConnection conn = new SqlConnection(connectionString))
{
    string req = "SELECT id, prenom, nom, email FROM personne;";

    SqlCommand command = new SqlCommand(req, conn);

    try
    {
        conn.Open();

        // Lorsque l'on souhaite lire des enregistrements, on instancie un reader
        SqlDataReader reader = command.ExecuteReader();

        // La méthode Read renvoie vraie tant qu'il y a des enregistrements
        while(reader.Read())
        {
            // On récupère la valeur d'un enregistrement grâce à son index
            Console.WriteLine($"id: {reader.GetInt32(0)}, prenom: {reader.GetString(1)}, nom: {reader.GetString(2)}, email: {reader.GetString(3)}");
        }

    } catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }

}

using (SqlConnection conn = new SqlConnection(connectionString))
{
    string req = "SELECT id, prenom, nom, email FROM personne WHERE id=@id;";

    int id = 450;

    SqlCommand command = new SqlCommand(req, conn);

    command.Parameters.AddWithValue("@id", id);

    try
    {
        conn.Open();

        // Lorsque l'on souhaite lire des enregistrements, on instancie un reader
        SqlDataReader reader = command.ExecuteReader();

        // La méthode Read renvoie vraie tant qu'il y a des enregistrements
        if(reader.Read())
        {
            // On récupère la valeur d'un enregistrement grâce à son index
            Console.WriteLine($"id: {reader.GetInt32(0)}, prenom: {reader.GetString(1)}, nom: {reader.GetString(2)}, email: {reader.GetString(3)}");
        } else
        {
            Console.WriteLine($"Aucune personne trouvé avec l'id {id}");
        }

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

}

using (SqlConnection conn = new SqlConnection(connectionString))
{
    string req = "SELECT AVG(LEN(prenom)) FROM personne;";

    SqlCommand command = new SqlCommand(req, conn);

    try
    {
        conn.Open();

        // Renvoie le résultat de la première colonne de la première ligne
        int averageFirstNameLength = (int) command.ExecuteScalar();

        Console.WriteLine($"La taille moyenne des prénoms de la table personne est de {averageFirstNameLength} caractères");

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

}