using AXX_poc_DiPaolo.Models.Enums;
using AXX_poc_DiPaolo.Models.Interfaces;

namespace AXX_poc_DiPaolo.Models
{
    public class BackOffice : IAdminUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; } = UserRole.BackOffice;
    }
}
