using demoapi.Models;
using System.Collections.Generic;

namespace demoapi.Services
{
    public interface IRingProvider
    {
        Ring GetNextAvailableRing();
        IEnumerable<Ring> GetAllAvailableRings();
        bool IsRingAvailable(int hallNumber, int ringNumber);
    }
}
