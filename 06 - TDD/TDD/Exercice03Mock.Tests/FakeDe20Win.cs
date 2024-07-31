using Demo03Mock.Core;

namespace Exercice03Mock.Tests
{
    /// <summary>
    /// Dé pipé pour toujours gagner au Jeu
    /// </summary>
    public class FakeDe20Win : IDe
    {
        public int Lancer()
        {
            return 20;
        }
    }
}
