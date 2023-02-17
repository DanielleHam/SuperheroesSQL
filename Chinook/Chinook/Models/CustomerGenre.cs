using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Models
{
    /// <summary>
    /// Creates an object that contains the customer id and their most common genre
    /// </summary>
    /// <param name="customerId">Customer ID</param>
    /// <param name="genre">Customer's most common genre</param>
    public readonly record struct CustomerGenre(int customerId, string genre);
}
