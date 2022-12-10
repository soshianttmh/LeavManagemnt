using Microsoft.AspNetCore.Identity;

namespace LeavManagemnt_.NET6.Data
{
    public class Employee : IdentityUser
    {
        // the Question mark is allows to culomn for nullable
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }

    }
}
