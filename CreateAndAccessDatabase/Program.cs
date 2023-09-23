using CreateAndAccessDatabase.AppendixB.Models;
using CreateAndAccessDatabase.AppendixB.Repositories;
using CreateAndAccessDatabase.AppendixB.Repositories.Customers;

namespace CreateAndAccessDatabase;

class Program
{
    static void Main(String[] args)
    {
        ICustomerRepository repository = new CustomerRepository();
        Customer customer = new Customer { CustomerId = 57, FirstName = "Ali", LastName = "Raza", Country = "Denmark", Email = "Ali@Ali.dk", Phone = "1234578", PostalCode = "2670" };

        // 1. PrintCustomers(repository.GetAll());
        // 2. PrintCustomer(repository.GetById(5));
        // 3. PrintCustomers(repository.GetCustomerByName("roberto"));
        // 4. PrintCustomers(repository.GetCustomersByPage(10, 5));
        // 5. repository.Add(customer);
        // 6. repository.Update(customer);
        // 7. PrintCustomerCountry(repository.GetCustomersByCountry());
        // 8. PrintHighestSpender(repository.GetHighestSpenders());

    }


    static void PrintCustomers(List<Customer> customers)
    {
        foreach (Customer customer in customers)
        {
            PrintCustomer(customer);
        }
    }


    static void PrintCustomer(Customer customer)
    {
        Console.WriteLine($"--- {customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} {customer.Phone} {customer.Email} ---");
    }


    static void PrintCustomerCountry(List<CustomerCountry> customerCountries)
    {
        foreach (CustomerCountry customerCountry in customerCountries)
        {
            Console.WriteLine($"Country: {customerCountry.Country}, Count: {customerCountry.CustomersCount}");
        }
    }


    static void PrintHighestSpender(List<CustomerSpender> highestSpenders)
    {
        foreach (CustomerSpender spender in highestSpenders)
        {
            Console.WriteLine($"Customer ID: {spender.CustomerId}, Customer Name: {spender.CustomerName}, Total Spent: {spender.TotalSpent}");
        }
    }



}