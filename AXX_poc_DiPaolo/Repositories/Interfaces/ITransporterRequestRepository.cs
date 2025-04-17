using AXX_poc_DiPaolo.Models;

namespace AXX_poc_DiPaolo.Repositories.Interfaces
{
    public interface ITransporterRequestRepository
    {
        IEnumerable<Request?> FindActiveRequests(string username);
        IEnumerable<Request?> FindAvailableRequests();
        IEnumerable<Request?> FindRequestHistory(string username);
        string FindCompanyName(string username);
        Request? FindRequestById(Guid id);
        bool SaveChanges();
    }
}
