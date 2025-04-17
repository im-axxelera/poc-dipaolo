using AXX_poc_DiPaolo.Models.Enums;
using AXX_poc_DiPaolo.Models.Interfaces;

namespace AXX_poc_DiPaolo.Models
{
    public class Request : IRequest
    {
        public Guid Id { get; set; }
        public string TyreDealerCompany { get; set; }
        public string Location { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        
        public int Quantity { get; set; }
        public int? Weight { get; set; }
        
        public RequestStatus Status { get; set; } = RequestStatus.Received;

        public string? TransporterCompany { get; set; }
        public DateTime? PickupDate { get; set; }
    }
}