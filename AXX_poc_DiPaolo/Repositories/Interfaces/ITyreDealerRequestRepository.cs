using AXX_poc_DiPaolo.Models;

namespace AXX_poc_DiPaolo.Repositories.Interfaces
{
    public interface ITyreDealerRequestRepository
    {
        IEnumerable<Request?> FindActiveRequests(string username);
        IEnumerable<Request> FindRequestHistory(string username);
        void AddRequest(Request request);
        public string FindCompanyName(string username);
        public string FindCompanyAddress(string username);
        bool SaveChanges();
    }
}
