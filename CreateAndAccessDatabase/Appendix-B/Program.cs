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
            Console.WriteLine("Hello World!");
            // Simulating Dependency Injection (highly simplified)
            ICustomerRepository repository = new CustomerRepository();

            // Retrieve all customers from the database and print them
            //var allCustomers = repository.GetAllCustomers();
            //PrintCustomers(allCustomers);


            var allCustomers = repository.GetAllCustomers();
            PrintCustomers(allCustomers);
            Console.WriteLine($"{allCustomers.Count()} customers retrieved from the database.");
            //PrintCustomers


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
