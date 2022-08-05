using Microsoft.AspNetCore.Identity;

namespace LeaveManagement.Data
{
    public class Employee : IdentityUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
