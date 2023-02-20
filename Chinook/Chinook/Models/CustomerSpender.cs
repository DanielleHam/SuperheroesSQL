using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Models
{
    /// <summary>
    /// Creates an object that contains customer first name, last name and how much they spent on all their invoices. 
    /// </summary>
    /// <param name="CustomerFirstName">Customer first name</param>
    /// <param name="CustomerLastName">Customer last name</param>
    /// <param name="TotalSpent">Total money spent on invoices</param>
    public readonly record struct CustomerSpender(string CustomerFirstName, string CustomerLastName, decimal TotalSpent);
}
