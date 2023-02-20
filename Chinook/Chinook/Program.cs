// See https://aka.ms/new-console-template for more information
using Chinook.Concrete_Repositories;
using Chinook.Models;
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");
var customer1 = new Customer(1, "Pelle", "berg", "Sweden", "dsa", "0000", "gmail");

var customerRepositories = new CustomerRepositor { ConnectionString = GetConnectionString() };
var oldCustomer = customerRepositories.GetById(60);
var updatedCostomer = new Customer(oldCustomer.customerId, oldCustomer.firstName, oldCustomer.lastName, oldCustomer.country, oldCustomer.postalCode, "1234789781", oldCustomer.email);
//customerRepositories.Add(customer1);
customerRepositories.Update(60, updatedCostomer);
var allCustomers = customerRepositories.GetAll();
var oneCustomer = customerRepositories.GetById(60);
//foreach (var customer in allCustomers)
//{
//    Console.WriteLine($"{customer.customerId} : {customer.firstName} : {customer.lastName} : {customer.country} : {customer.postalCode} : {customer.phoneNumber} : {customer.email}");
//}

//var pageCustomers = customerRepositories.GetPage(10, 5);
//foreach(var customer in pageCustomers)
//{
//    Console.WriteLine($"{customer.customerId} : {customer.firstName} : {customer.lastName} : {customer.country} : {customer.postalCode} : {customer.phoneNumber} : {customer.email}");
//}



Console.WriteLine(oneCustomer.phoneNumber);

var findByNameCustomer = customerRepositories.GetByName("berg");
foreach (var customer in findByNameCustomer)
{
    Console.WriteLine($"{customer.customerId} : {customer.firstName} : {customer.lastName} : {customer.country} : {customer.postalCode} : {customer.phoneNumber} : {customer.email}");
}

var cc = customerRepositories.SortByCountry();
foreach (var customer in cc)
{
    Console.WriteLine($"{customer.country}: {customer.count}");
}

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
