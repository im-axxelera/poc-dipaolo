using AXX_poc_DiPaolo.Models.Enums;
using AXX_poc_DiPaolo.Models.Interfaces;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;

namespace AXX_poc_DiPaolo.Models
{
    public class TyreDealer : ICompanyUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; } = UserRole.TyreDealer;

        public string CompanyName { get; set; }
        public string Address { get; set; }
    }
}
