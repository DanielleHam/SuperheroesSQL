using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Models
{
    /// <summary>
    /// Creates an object that contains customer information.
    /// </summary>
    /// <param name="customerId">Customer's Id</param>
    /// <param name="firstName">Customer's first name</param>
    /// <param name="lastName">Customer's last name</param>
    /// <param name="country">Customer's country</param>
    /// <param name="postalCode">Customer's postal code</param>
    /// <param name="phoneNumber">Customer's phone number</param>
    /// <param name="email">Customer's email</param>
    public readonly record struct Customer(int customerId, string firstName, 
        string lastName, string country, string postalCode, 
        string phoneNumber, string email);
}
