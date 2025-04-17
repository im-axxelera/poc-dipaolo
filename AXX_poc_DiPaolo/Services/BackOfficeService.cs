using AXX_poc_DiPaolo.Models;
using AXX_poc_DiPaolo.Models.Enums;
using AXX_poc_DiPaolo.Repositories.Interfaces;

namespace AXX_poc_DiPaolo.Services
{
    public class BackOfficeService
    {
        private readonly IBackOfficeRequestRepository _requestRepository;

        public BackOfficeService(IBackOfficeRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public IEnumerable<Request?> CollectAllRequests()
        {
            return _requestRepository.FindAllRequests();
        }

        public IEnumerable<Request?> CollectCompletedRequests()
        {
            return _requestRepository.FindCompletedRequests();
        }

        public IEnumerable<Request?> CollectAvailableRequests()
        {
            return _requestRepository.FindAvailableRequests();
        }

        public IEnumerable<Request?> CollectInProgressRequests()
        {
            return _requestRepository.FindInProgressRequests();
        }

        public Request? CollectRequestById(Guid id)
        {
            return _requestRepository.FindRequestById(id);
        }

        public bool ValidateRequest(Guid id, int quantity)
        {
            var request = CollectRequestById(id);
            //richiesta validabile solo se:
            //notificata la consegna da Transporter
            //Data attuale >= Data consegna

            if (!IsRequestValuable(request))
                return false;
            //comunicazione UI attraverso classe ValidateRequestResult(bool success, string errorMessage)

            request.Weight = TakeRequestWeight(request.Quantity);
            request.Status = RequestStatus.Completed;

            return _requestRepository.SaveChanges();
        }

        private bool IsRequestValuable(Request? request)
        {
            return
                (request != null || request?.Status == RequestStatus.InProgress);
        }

        private int TakeRequestWeight(int quantity)
        {
            //simulazione misurazione peso
            return quantity * 65;
        }
    }
}
