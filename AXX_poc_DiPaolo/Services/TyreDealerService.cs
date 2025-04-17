using AXX_poc_DiPaolo.Models;
using AXX_poc_DiPaolo.Repositories.Interfaces;

namespace AXX_poc_DiPaolo.Services
{
    public class TyreDealerService
    {
        private readonly ITyreDealerRequestRepository _requestRepository;

        public TyreDealerService(ITyreDealerRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        private int maxRequests = 1;
        private int minQuantity = 1000;
        private int maxQuantity = 9500;

        public bool PublishRequest(string username, int quantity)
        {
            if (!IsAbleToAdd(username) || !ValidateQUantity(quantity))
                return false;
            //comunicazione UI attraverso classe PublishRequestResult(bool SUccess, string ErrorMessage)

            var companyName = _requestRepository.FindCompanyName(username);
            var address = _requestRepository.FindCompanyAddress(username);

            var request = new Request
            {
                TyreDealerCompany = companyName,
                Location = address,
                Quantity = quantity,
            };

            _requestRepository.AddRequest(request);

            return _requestRepository.SaveChanges();
        }

        public IEnumerable<Request?> CollectActiveRequests(string username)
        {
            return _requestRepository.FindActiveRequests(username);
        }

        public IEnumerable<Request?> CollectRequestHistory(string username)
        {
            return _requestRepository.FindRequestHistory(username);
        }

        private bool IsAbleToAdd(string username)
        {
            return _requestRepository.FindActiveRequests(username)
                .Count() < maxRequests;
        }

        private bool ValidateQUantity(int quantity)
        {
            return quantity >= minQuantity &&
                quantity <= maxQuantity;
        }
    }
}
