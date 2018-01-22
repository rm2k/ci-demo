using demoapi.Models;

namespace demoapi.Services
{
    public interface IRingProvider
    {
        Ring GetNextAvailableRing();
    }
}
