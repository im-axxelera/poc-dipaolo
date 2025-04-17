using AXX_poc_DiPaolo.Data;
using AXX_poc_DiPaolo.Models;
using AXX_poc_DiPaolo.Models.Enums;
using AXX_poc_DiPaolo.Repositories.Interfaces;

namespace AXX_poc_DiPaolo.Repositories
{
    public class TransporterRequestRepository : ITransporterRequestRepository
    {
        private readonly PocDbContext _context;
        public TransporterRequestRepository(PocDbContext context)
        {
            _context = context;
        }

        //public void AssignRequest(Guid id, string username, DateTime pickupDate)
        //{
        //    var request = _context.RequestsList
        //        .FirstOrDefault(r => r.Id == id);

        //    var transporterCompanyName = FindCompanyName(username);

        //    request.Status = RequestStatus.InProgress;
        //    request.TransporterCompany = transporterCompanyName;
        //    request.PickupDate = pickupDate;
        //}

        public IEnumerable<Request?> FindAvailableRequests()
        {
            return _context.RequestsList
                .Where(r => r.Status == RequestStatus.Received)
                .ToList();
        }

        public IEnumerable<Request?> FindActiveRequests(string username)
        {
            var trasporterCompanyName = FindCompanyName(username);

            return _context.RequestsList
                .Where(r => r.Status == RequestStatus.InProgress
                && r.TransporterCompany == trasporterCompanyName)
                .ToList();
        }

        public IEnumerable<Request?> FindRequestHistory(string username)
        {
            var trasporterCompanyName = FindCompanyName(username);

            return _context.RequestsList
                .Where(r => r.Status == RequestStatus.Received
                && r.TransporterCompany == trasporterCompanyName)
                .ToList();
        }

        public Request? FindRequestById(Guid id)
        {
            return _context.RequestsList
                .FirstOrDefault(r => r.Id == id);
        }

        public string FindCompanyName(string username)
        {
            return _context.TransportersList
                .FirstOrDefault(t => t.Username == username)
                .CompanyName;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
