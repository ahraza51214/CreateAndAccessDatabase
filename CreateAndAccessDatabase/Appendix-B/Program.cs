using Azure;
using CreateAndAccessDatabase.Appendix_B.Repositories;
using CreateAndAccessDatabase.Model;
using SQLClientCRUDRepo.Repositories;
using System;
using System.Collections.Generic;


namespace SQLClientCRUDRepo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simulating Dependency Injection (highly simplified)
            ICustomerRepository repository = new CustomerRepository();

            // Excerise 1:
            var allCustomers = repository.GetAllCustomers();
            Console.WriteLine("Exercise 1: Print all the customer in the database: ");
            PrintCustomers(allCustomers);

            // Excerise 2:
            Console.WriteLine("\nExercise 2: Read a specific customer from the database (by Id=8): ");
            var specificCustomerById = repository.GetCustomerById(8);
            PrintCustomer(specificCustomerById);

            // Excerise 3:
            Console.WriteLine("\nExercise 3: Read a specific customer by FirstName (for example FirstName='Heather'): ");
            var specificCustomerByFirstName = repository.GetCustomerByFirstName("Heather");
            PrintCustomer(specificCustomerByFirstName);

            // Excerise 4: Return a page of customers from the database. 
            Console.WriteLine("\nExcerise 4: Return a page of customers from the database (for example limit=5 and offset=3):");
            var customersByPage = repository.GetCustomersByPage(5, 3);
            PrintCustomers(customersByPage);

        }

        public static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        public static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"--- {customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} {customer.Phone} {customer.Email} ---");
        }
    }
}
