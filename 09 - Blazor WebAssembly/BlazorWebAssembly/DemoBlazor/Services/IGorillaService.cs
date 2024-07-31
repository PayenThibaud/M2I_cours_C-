using DemoBlazor.Models;

namespace DemoBlazor.Services
{
    public interface IGorillaService
    {
        public Task<bool> Post(Gorilla gorilla);
        public Task<bool> Delete(int id);
    }
}
