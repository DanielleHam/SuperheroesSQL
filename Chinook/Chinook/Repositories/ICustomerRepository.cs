using Chinook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Repositories
{
    public interface ICustomerRepository : ICrudRepository<Customer>
    {
        /// <summary>
        /// Fetches countries and how many customers in that country, in descending order
        /// </summary>
        /// <returns>IEnumberable of type CustomerCountry</returns>
        public IEnumerable<CustomerCountry> SortCountriesBasedOnAmountOfCustomers();

        /// <summary>
        /// Fetches customers and how much they've spent on invoices, ordered in descending order.
        /// </summary>
        /// <returns>IEnumerable of type CustomerSpender</returns>
        public IEnumerable<CustomerSpender> SortBySpendings();

        /// <summary>
        /// Fetches a customers favourite genre, based on how many tracks they have bought in that genre. In case of ties, returns all favourite genres. 
        /// </summary>
        /// <param name="customerId">Customer to fetch</param>
        /// <returns>IEnumerable of type CustomerGenre</returns>
        public IEnumerable<CustomerGenre> GetCustomerFavoriteGenres(int customerId);
    }
}
