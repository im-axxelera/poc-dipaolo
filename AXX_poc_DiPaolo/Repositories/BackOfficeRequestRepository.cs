using AXX_poc_DiPaolo.Data;
using AXX_poc_DiPaolo.Models;
using AXX_poc_DiPaolo.Models.Enums;
using AXX_poc_DiPaolo.Repositories.Interfaces;

namespace AXX_poc_DiPaolo.Repositories
{
    public class BackOfficeRequestRepository : IBackOfficeRequestRepository
    {
        private readonly PocDbContext _context;
        public BackOfficeRequestRepository(PocDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Request?> FindAllRequests()
        {
            return _context.RequestsList
                .ToList();
        }

        public IEnumerable<Request?> FindCompletedRequests()
        {
            return _context.RequestsList
                .Where(r => r.Status == RequestStatus.Completed)
                .ToList();
        }

        public IEnumerable<Request?> FindAvailableRequests()
        {
            return _context.RequestsList
                .Where(r => r.Status == RequestStatus.Received)
                .ToList();
        }

        public IEnumerable<Request?> FindInProgressRequests()
        {
            return _context.RequestsList
                .Where(r => r.Status == RequestStatus.InProgress)
                .ToList();
        }

        public Request? FindRequestById(Guid id)
        {
            return _context.RequestsList
                .FirstOrDefault(r => r.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
