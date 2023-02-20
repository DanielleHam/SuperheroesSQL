using Chinook.Models;
using Chinook.Repositories;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace Chinook.Concrete_Repositories
{
    public class CustomerRepositor : ICustomerRepository
    {
        public string ConnectionString { get; set; } = string.Empty;


        public IEnumerable<Customer> GetAll()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            using var command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new Customer(
                    reader.GetInt32(0),
                    (!reader.IsDBNull(1) ? reader.GetString(1) : "No first name"),
                    (!reader.IsDBNull(2) ? reader.GetString(2) : "No last name"),
                    (!reader.IsDBNull(3) ? reader.GetString(3) : "No country"),
                    (!reader.IsDBNull(4) ? reader.GetString(4) : "No postal code"),
                    (!reader.IsDBNull(5) ? reader.GetString(5) : "No phone number"),
                    (!reader.IsDBNull(6) ? reader.GetString(6) : "No email")
                    );
            }

        }

        public Customer GetById(int id)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId = @id";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            using SqlDataReader reader = command.ExecuteReader();

            var result = new Customer();
            while (reader.Read())
            {
                result = new Customer(
                    reader.GetInt32(0),
                    (!reader.IsDBNull(1) ? reader.GetString(1) : "No first name"),
                    (!reader.IsDBNull(2) ? reader.GetString(2) : "No last name"),
                    (!reader.IsDBNull(3) ? reader.GetString(3) : "No country"),
                    (!reader.IsDBNull(4) ? reader.GetString(4) : "No postal code"),
                    (!reader.IsDBNull(5) ? reader.GetString(5) : "No phone number"),
                    (!reader.IsDBNull(6) ? reader.GetString(6) : "No email")
                    );
            }

            return result;

        }

        public IEnumerable<Customer> GetByName(string name)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE FirstName LIKE @name OR LastName LIKE @name";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@name", $"%{name}%");
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new Customer(
                    reader.GetInt32(0),
                    (!reader.IsDBNull(1) ? reader.GetString(1) : "No first name"),
                    (!reader.IsDBNull(2) ? reader.GetString(2) : "No last name"),
                    (!reader.IsDBNull(3) ? reader.GetString(3) : "No country"),
                    (!reader.IsDBNull(4) ? reader.GetString(4) : "No postal code"),
                    (!reader.IsDBNull(5) ? reader.GetString(5) : "No phone number"),
                    (!reader.IsDBNull(6) ? reader.GetString(6) : "No email")
                    );
            }


        }

        public IEnumerable<Customer> GetPage(int limit, int offset)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT TOP (@limit) CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId > @offset";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@limit", limit);
            command.Parameters.AddWithValue("@offset", offset);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new Customer(
                    reader.GetInt32(0),
                    (!reader.IsDBNull(1) ? reader.GetString(1) : "No first name"),
                    (!reader.IsDBNull(2) ? reader.GetString(2) : "No last name"),
                    (!reader.IsDBNull(3) ? reader.GetString(3) : "No country"),
                    (!reader.IsDBNull(4) ? reader.GetString(4) : "No postal code"),
                    (!reader.IsDBNull(5) ? reader.GetString(5) : "No phone number"),
                    (!reader.IsDBNull(6) ? reader.GetString(6) : "No email")
                    );
            }
        }
        public void Add(Customer customer)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "INSERT INTO Customer(FirstName, LastName, Country, PostalCode, Phone, Email) VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName", customer.firstName);
            command.Parameters.AddWithValue("@LastName", customer.lastName);
            command.Parameters.AddWithValue("@Country", customer.country);
            command.Parameters.AddWithValue("@PostalCode", customer.postalCode);
            command.Parameters.AddWithValue("@Phone", customer.phoneNumber);
            command.Parameters.AddWithValue("@Email", customer.email);

            command.ExecuteNonQuery();

        }

        public void Update(int id, Customer updateCostumer)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Country = @Country, PostalCode = @PostalCode, Phone = @Phone, Email = @Email WHERE CustomerId = @Id";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FirstName", updateCostumer.firstName);
            command.Parameters.AddWithValue("@LastName", updateCostumer.lastName);
            command.Parameters.AddWithValue("@Country", updateCostumer.country);
            command.Parameters.AddWithValue("@PostalCode", updateCostumer.postalCode);
            command.Parameters.AddWithValue("@Phone", updateCostumer.phoneNumber);
            command.Parameters.AddWithValue("@Email", updateCostumer.email);
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }

        public IEnumerable<CustomerCountry> SortByCountry()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT Country,COUNT (CustomerId) FROM Customer GROUP BY Country ORDER BY COUNT (CustomerId) DESC";
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new CustomerCountry(
                reader.GetString(0),
                reader.GetInt32(1)
                
                    );
            }
        }

        public IEnumerable<CustomerSpender> SortBySpendings()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT c.CustomerId, c.FirstName, c.LastName, SUM(i.Total) FROM Invoice AS i INNER JOIN Customer AS c ON  i.CustomerId = c.CustomerId GROUP BY c.FirstName, c.LastName,  c.CustomerId ORDER BY SUM(i.Total) DESC";
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new CustomerSpender(
                reader.GetString(1),
                reader.GetString(2),
                reader.GetDecimal(3)

                    );
            }
        }

        public IEnumerable<CustomerGenre> GetFavoriteGenre(int customerId)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var sql = "SELECT TOP 1 WITH TIES c.FirstName, c.LastName, g.Name, COUNT(*) " +
               "FROM Customer AS c " +
               "INNER JOIN Invoice as i ON i.CustomerId = c.CustomerId " +
               "INNER JOIN InvoiceLine as il ON il.InvoiceId = i.InvoiceId " +
               "INNER JOIN Track as t ON t.TrackId = il.TrackId " +
               "INNER JOIN Genre as g ON g.GenreId = t.GenreId " +
               "WHERE c.CustomerId = @CustomerId " +
               "GROUP BY c.FirstName, c.LastName, g.Name " +
               "ORDER BY 4 DESC";
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CustomerId", customerId);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return new CustomerGenre(
                reader.GetString(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetInt32(3)
                );
            }
        }
    }
}
