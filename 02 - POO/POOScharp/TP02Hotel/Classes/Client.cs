using System.Runtime.CompilerServices;

namespace TP02Hotel.Classes
{
    public class Client
    {
        public string Id { get; } = Guid.NewGuid().ToString();
        public string Nom { get; set; } = "";
        public string Prenom { get; set; } = "";
        public string NomComplet { get => Prenom.ToCapitalized() + " " + Nom.ToUpper(); }
        public string Telephone { get; set; } = "";

        public override string ToString()
        {
            return $"{Id}. {Prenom} {Nom} ({Telephone})";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Client)
            {
                return ((Client)obj).Id == Id;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(Id);
        }
    }
}