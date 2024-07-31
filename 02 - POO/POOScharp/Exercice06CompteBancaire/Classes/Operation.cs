namespace Exercice06CompteBancaire.Classes
{
    internal class Operation
    {
        // Champ statique pour permettre un ID unique sur les opérations
        private static int _count = 0;

        // Champs d'instance pour chaque opération
        private int _num;
        private decimal _montant;
        private TypeOperation _type;

        // Propriétés pour permettre l'accès à l'extérieur des informations de chaque opération
        public int Num { get => _num; }
        public decimal Montant { get => _montant; }
        public TypeOperation Type { get => _type; }

        // Constructeur d'opération pour créer des opération en dehors de cette classe
        public Operation(decimal montant, TypeOperation type)
        {
            _num = ++_count;
            _montant = montant;
            _type = type;
        }

        public override string ToString()
        {
            return $"{_num}. [{Enum.GetName(_type)}] - {_montant}€";
            // 1. [RETRAIT] 120.00€
        }
    }
}