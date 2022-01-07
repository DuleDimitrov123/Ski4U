using System;

namespace Ski4U.Api.Models
{
    public class CustomerModels
    {
        public record AddCustomerRequest(string FirstName, string LastName, string Password, string Email, DateTime DateOfBirth, string Number, string Address);

        public record UpdateCustomerRequest(int Id, string FirstName, string LastName, string Password, string Email, DateTime DateOfBirth, string Number, string Address);
    }
}
