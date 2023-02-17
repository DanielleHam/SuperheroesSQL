using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Models
{
    /// <summary>
    /// Creates an object that contains customerId and how much they spent on this invoice. 
    /// </summary>
    /// <param name="customerId">Customer Id</param>
    /// <param name="total">Money spent on invoice</param>
    public readonly record struct CustomerSpender(int customerId, int total);
}
