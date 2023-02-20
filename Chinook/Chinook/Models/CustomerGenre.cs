using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Models
{
    /// <summary>
    /// Creates an object that contains the customer first name, last name and their most common genre
    /// </summary>
    /// <param name="CustomerFirstName">Customer first name</param>
    /// <param name="CustomerLastName">Customer last name</param>
    /// <param name="Genre">Customer's most common genre</param>
    public readonly record struct CustomerGenre(string CustomerFirstName, string CustomerLastName, string Genre);
}
