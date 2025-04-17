using AXX_poc_DiPaolo.Models;
using AXX_poc_DiPaolo.Models.Interfaces;

namespace AXX_poc_DiPaolo.Repositories.Interfaces
{
    public interface IBackOfficeRequestRepository
    {
        IEnumerable<Request?> FindAllRequests();
        IEnumerable<Request?> FindCompletedRequests();
        IEnumerable<Request?> FindAvailableRequests();
        IEnumerable<Request?> FindInProgressRequests();
        Request? FindRequestById(Guid id);
        bool SaveChanges();

    }
}
