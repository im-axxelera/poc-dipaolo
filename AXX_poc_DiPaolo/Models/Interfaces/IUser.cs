using AXX_poc_DiPaolo.Models.Enums;

namespace AXX_poc_DiPaolo.Models.Interfaces
{
    public interface IUser
    {
        string Username { get; set; }
        string Password { get; set; }
        UserRole Role { get; }
    }
}
