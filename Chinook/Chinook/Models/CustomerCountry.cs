using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Models
{
    /// <summary>
    /// Creates an object that contains the country and how many customers are from there. 
    /// </summary>
    /// <param name="Country">Country</param>
    /// <param name="Count">How many users there are from the country</param>
    public readonly record struct CustomerCountry(string Country, int Count);
}
