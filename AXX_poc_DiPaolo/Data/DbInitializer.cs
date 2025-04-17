using AXX_poc_DiPaolo.Models;
using AXX_poc_DiPaolo.Models.Enums;
using System.Globalization;

namespace AXX_poc_DiPaolo.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PocDbContext context)
        {
            context.Database.EnsureCreated();

            var tyreDealers = new TyreDealer[]
            {
                new TyreDealer{Username="Tyre01",Password="d1",CompanyName="LosTyres1",Address="60869, Via del Campo 17"},
                new TyreDealer{Username="Tyre02",Password="d2",CompanyName="T&R2",Address="10869, Via del Campo 17"},
                new TyreDealer{Username="Tyre03",Password="d3",CompanyName="TUI&R3",Address="10179, Via del Campo 17"},
                new TyreDealer{Username="Tyre04",Password="d4",CompanyName="TUI&R3",Address="10179, Via del Campo 17"}
            };
            foreach (TyreDealer t in tyreDealers)
            {
                context.TyreDealerList.Add(t);
            }
            context.SaveChanges();
            
            var transporters = new Transporter[]
            {
                new Transporter{Username="Trans01",Password="t1",CompanyName="U-TRANS1",Address="60879, Via del Campo 17"},
                new Transporter{Username="Trans02",Password="t2",CompanyName="JHG2",Address="90869, Via del Campo 17"},
                new Transporter{Username="Trans03",Password="t3",CompanyName="LOK3",Address="90345, Via del Campo 17"}
            };
            foreach (Transporter t in transporters)
            {
                context.TransportersList.Add(t);
            }
            context.SaveChanges();

            var requests = new Request[]
            {
                new Request{Id=Guid.NewGuid(),TyreDealerCompany="LosTyres1",Location="60869, Via del Campo 17",RequestDate=DateTime.ParseExact("14/04/2025 19:42","dd/MM/yyyy mm:ss",CultureInfo.InvariantCulture),Quantity=3450,Status=RequestStatus.Received},
                new Request{Id=Guid.NewGuid(),TyreDealerCompany="T&R2",Location="10869, Via del Campo 17",RequestDate=DateTime.ParseExact("14/04/2025 13:45","dd/MM/yyyy mm:ss",CultureInfo.InvariantCulture),Quantity=6500,Status=RequestStatus.Received},
                new Request{Id=Guid.NewGuid(),TyreDealerCompany="TUI&R3",Location="10179, Via del Campo 17",RequestDate=DateTime.ParseExact("13/04/2025 13:30","dd/MM/yyyy mm:ss",CultureInfo.InvariantCulture),Quantity=1500,Status=RequestStatus.InProgress,TransporterCompany="U-TRANS1",PickupDate=DateTime.ParseExact("22/04/2025 13:30","dd/MM/yyyy mm:ss",CultureInfo.InvariantCulture)},
                new Request{Id=Guid.NewGuid(),TyreDealerCompany="LosTyres1",Location="60869, Via del Campo 17",RequestDate=DateTime.ParseExact("12/04/2025 10:30","dd/MM/yyyy mm:ss",CultureInfo.InvariantCulture),Quantity=3000,Status=RequestStatus.InProgress,TransporterCompany="U-TRANS1",PickupDate=DateTime.ParseExact("23/04/2025 17:30","dd/MM/yyyy mm:ss",CultureInfo.InvariantCulture)},
                new Request{Id=Guid.NewGuid(),TyreDealerCompany="LosTyres1",Location="60869, Via del Campo 17",RequestDate=DateTime.ParseExact("10/04/2025 10:30","dd/MM/yyyy mm:ss",CultureInfo.InvariantCulture),Quantity=2000,Status=RequestStatus.InProgress,TransporterCompany="U-TRANS1",PickupDate=DateTime.ParseExact("21/04/2025 17:00","dd/MM/yyyy mm:ss",CultureInfo.InvariantCulture)},
            };
            foreach (Request r in requests)
            {
                context.RequestsList.Add(r);
            }
            context.SaveChanges();
        }
    }
}
