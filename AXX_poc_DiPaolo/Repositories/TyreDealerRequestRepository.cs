using AXX_poc_DiPaolo.Data;
using AXX_poc_DiPaolo.Models;
using AXX_poc_DiPaolo.Models.Enums;
using AXX_poc_DiPaolo.Repositories.Interfaces;

namespace AXX_poc_DiPaolo.Repositories
{
    public class TyreDealerRequestRepository : ITyreDealerRequestRepository
    {
        private readonly PocDbContext _context;

        public TyreDealerRequestRepository(PocDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Request?> FindActiveRequests(string username)
        {
            return _context.RequestsList
                .Where(r => r.Status == RequestStatus.Received
                && r.TyreDealerCompany == FindCompanyName(username))
                .ToList();
        }

        public IEnumerable<Request> FindRequestHistory(string username)
        {
            return _context.RequestsList
                .Where(r => r.TyreDealerCompany == FindCompanyName(username)
                && r.Status != RequestStatus.Received)
                .ToList();
        }

        public string FindCompanyName(string username)
        {
            return _context.TyreDealerList
                .FirstOrDefault(t => t.Username == username)
                .CompanyName;
        }

        public string FindCompanyAddress(string username)
        {
            return _context.TyreDealerList
                .FirstOrDefault(t => t.Username == username)
                .Address;
        }

        public void AddRequest(Request request)
        {
            _context.RequestsList.Add(request);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}

