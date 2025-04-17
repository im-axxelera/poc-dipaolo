using AXX_poc_DiPaolo.Models.Enums;

namespace AXX_poc_DiPaolo.Models.Interfaces
{
    public interface IRequest
    {
        Guid Id { get; set; }
        string TyreDealerCompany { get; }
        DateTime RequestDate { get; }

        int Quantity { get; }
        int? Weight { get; set; }

        RequestStatus Status { get; set; }
        string? TransporterCompany { get; set; }
        DateTime? PickupDate { get; set; }
    }
}
