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

            // Retrieve all customers from the database and print them
            //var allCustomers = repository.GetAllCustomers();
            //PrintCustomers(allCustomers);


            var allCustomers = repository.GetAllCustomers();
            Console.WriteLine("Exercise 1: Print all the customer in the database: ");
            PrintCustomers(allCustomers);

            Console.WriteLine("Exercise 2: Read a specific customer from the database (by Id): ");
            var specificCustomerById = repository.GetCustomerById(8);
            PrintCustomer(specificCustomerById);

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
