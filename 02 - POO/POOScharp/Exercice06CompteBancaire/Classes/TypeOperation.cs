namespace Exercice06CompteBancaire
{
    // Pour notre énum, il nous suffit de définir les deux valeurs possibles à l'instant de création du programme. L'avantage de l'énum est que si plus tard on étend les valeurs possibles, on a pas besoin de retoucher à notre code métier, juste de le compléter
    internal enum TypeOperation
    {
        DEPOT,
        RETRAIT
    }
}