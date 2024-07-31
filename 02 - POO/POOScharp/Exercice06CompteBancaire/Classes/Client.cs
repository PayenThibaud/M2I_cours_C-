namespace Exercice06CompteBancaire.Classes
{
    internal class Client
    {
        private static int _counter = 0;

        // Champs privés pour protéger nos variables
        private int _id;
        private string _nom;
        private string _prenom;
        private string _numTelephone;
        private List<CompteBancaire> _comptes;


        // Getters de sorte à empêcher la modification à l'extérieur de la classe, juste la lecture
        public int Id { get => _id; }
        public string Nom { get => _nom; }
        public string Prenom { get => _prenom; }
        public string NumTelephone { get => _numTelephone; }
        public List<CompteBancaire> Comptes { get => _comptes; }

        // Constructeur demandant 3 champs à l'utilisateur, mais produisant un ID unique et initialisant une liste de compte vierge pour tous
        public Client(string nom, string prenom, string numTelephone)
        {
            _id = ++_counter;
            _comptes = new();

            _nom = nom;
            _prenom = prenom;
            _numTelephone = numTelephone;
        }
    }
}