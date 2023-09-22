using System;
using CreateAndAccessDatabase.AppendixB.Repositories;
using CreateAndAccessDatabase.AppendixB.Models;

namespace CreateAndAccessDatabase.AppendixB.Repositories.Customers
{
	internal interface ICustomerRepository : ICrudRepository<Customer, int>
    {
        Dictionary<string, int> GetCustomersByCountry();
        List<Customer> GetHighestSpenders();
        List<string> GetMostPopularGenres(int customerId);
    }
}