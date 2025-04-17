using AXX_poc_DiPaolo.Models;
using AXX_poc_DiPaolo.Models.Enums;
using AXX_poc_DiPaolo.Repositories.Interfaces;

namespace AXX_poc_DiPaolo.Services
{
    public class TransporterService
    {
        private readonly ITransporterRequestRepository _requestRepository;

        public TransporterService(ITransporterRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        private int maxAssignments = 3;

        public IEnumerable<Request?> CollectAvailableRequests()
        {
            return _requestRepository.FindAvailableRequests();
        }

        public IEnumerable<Request?> CollectRequestHistory(string username)
        {
            return _requestRepository.FindRequestHistory(username);
        }

        public IEnumerable<Request?> CollectActiveRequests(string username)
        {
            return _requestRepository.FindActiveRequests(username);
        }

        public bool AssignRequest(Guid id, string username, DateTime pickupDate)
        {
            var request = _requestRepository.FindRequestById(id);

            if (!IsAbleToAdd(username) || !IsRequestValuable(request, pickupDate))
                return false;
            //comunicazione UI attraverso classe AssignResult(bool success, string errorMessage)

            var transporterCompanyName = _requestRepository.FindCompanyName(username);

            request.Status = RequestStatus.InProgress;
            request.TransporterCompany = transporterCompanyName;
            request.PickupDate = pickupDate;

            return _requestRepository.SaveChanges();
        }

        private bool IsAbleToAdd(string username)
        {
            return _requestRepository.FindActiveRequests(username)
                .Count() < maxAssignments;
        }

        private bool IsRequestValuable(Request request, DateTime pickupDate)
        {
            return (request != null
            || request.Status == RequestStatus.Received
            || pickupDate >= DateTime.Now.Date);
                
        }
    }
}
