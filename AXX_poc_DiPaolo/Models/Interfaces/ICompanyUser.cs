namespace AXX_poc_DiPaolo.Models.Interfaces
{
    public interface ICompanyUser : IUser
    {
        string CompanyName { get; set; }
        string Address { get; set; }
    }
}
