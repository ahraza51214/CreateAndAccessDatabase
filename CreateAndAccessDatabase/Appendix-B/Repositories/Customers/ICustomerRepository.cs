using System;
using CreateAndAccessDatabase.AppendixB.Repositories;
using CreateAndAccessDatabase.AppendixB.Models;

namespace CreateAndAccessDatabase.AppendixB.Repositories.Customers
{
    // Specific interface for the Customer repository representing all the specific methods that are related to the customer repository.
    // Also implementing ICrudRepository to implement all the general CRUD methods.
	internal interface ICustomerRepository : ICrudRepository<Customer>
    {
        List<Customer> GetCustomerByName(string name);
        List<Customer> GetCustomersByPage(int offset, int limit);
        List<CustomerCountry> GetCustomersByCountry();
        List<CustomerSpender> GetHighestSpenders();
        List<string> GetMostPopularGenres(int customerId);
    }
}