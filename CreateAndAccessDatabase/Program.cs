using CreateAndAccessDatabase.AppendixB.Models;
using CreateAndAccessDatabase.AppendixB.Repositories.Customers;

namespace CreateAndAccessDatabase;

class Program
{
    static void Main(String[] args)
    {
        Console.WriteLine("Hello");
        ICustomerRepository repository = new CustomerRepository();
        PrintCustomers(repository.GetAll());
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
}