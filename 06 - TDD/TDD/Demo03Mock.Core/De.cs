namespace Demo03Mock.Core
{
    /// <summary>
    /// Classe représentant un dé à 20 faces
    /// </summary>
    public class De20 : IDe
    {
        private Random _random = new();

        public int Lancer()
        {
            return _random.Next(1, 21);
        }
    }
}
