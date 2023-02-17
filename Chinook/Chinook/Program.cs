// See https://aka.ms/new-console-template for more information
using Chinook.Concrete_Repositories;
using Chinook.Models;
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");

var customerRepositories = new CustomerRepositor { ConnectionString = GetConnectionString() };

var allCustomers = customerRepositories.GetAll();
var oneCustomer = customerRepositories.GetById(1);
foreach(var customer in allCustomers)
{
    Console.WriteLine($"{customer.customerId} : {customer.firstName} : {customer.lastName} : {customer.country} : {customer.postalCode} : {customer.phoneNumber} : {customer.email}");
}

Console.WriteLine(oneCustomer.firstName);

static string GetConnectionString()
{
    var builder = new SqlConnectionStringBuilder
    {
        DataSource = "localhost\\SQLEXPRESS",
        InitialCatalog = "Chinook",
        IntegratedSecurity = true,
        TrustServerCertificate = true
    };

    return builder.ConnectionString;
}
