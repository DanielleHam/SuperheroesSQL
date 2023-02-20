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
    /// <param name="CustomerId">Customer's Id</param>
    /// <param name="FirstName">Customer's first name</param>
    /// <param name="LastName">Customer's last name</param>
    /// <param name="Country">Customer's country</param>
    /// <param name="PostalCode">Customer's postal code</param>
    /// <param name="PhoneNumber">Customer's phone number</param>
    /// <param name="Email">Customer's email</param>
    public readonly record struct Customer(int CustomerId, string FirstName, 
        string LastName, string Country, string PostalCode, 
        string PhoneNumber, string Email);
}
