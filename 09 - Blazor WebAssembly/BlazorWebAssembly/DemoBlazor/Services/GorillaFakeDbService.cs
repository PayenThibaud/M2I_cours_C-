using DemoBlazor.Models;

namespace DemoBlazor.Services
{
    public class GorillaFakeDbService : IGorillaService
    {
        private int _lastId = 0;
        private List<Gorilla> _gorillaz = new List<Gorilla>();

        public async Task<bool> Delete(int id)
        {
            var nbRemoved = _gorillaz.RemoveAll(m => m.Id == id);
            Console.WriteLine(_gorillaz.Count);
            return nbRemoved == 1;
        }

        public async Task<bool> Post(Gorilla gorilla)
        {
            gorilla.Id = ++_lastId;
            _gorillaz.Add(gorilla);
            Console.WriteLine(_gorillaz.Count);
            return true;
        }
    }
}
