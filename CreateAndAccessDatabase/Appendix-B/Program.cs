﻿using CreateAndAccessDatabase.AppendixB.Models;
using CreateAndAccessDatabase.AppendixB.Repositories.Customers;

namespace CreateAndAccessDatabase.AppendixB;

class Program
{
    static void Main(String[] args)
    {
        ICustomerRepository repository = new CustomerRepository();

        // Creaeting a new customer object
        Customer customer = new Customer { CustomerId = 57, FirstName = "Ali", LastName = "Raza", Country = "Denmark", Email = "Ali@Ali.dk", Phone = "1234578", PostalCode = "2670" };

        // Excerise 1: Printing all the customer in the database
        var allCustomers = repository.GetAll();
        Console.WriteLine("Exercise 1: Print all the customer in the database:");
        PrintCustomers(allCustomers);

        // Excerise 2: Reading a specific customer from the database by the Id
        Console.WriteLine("\nExercise 2: Read a specific customer from the database (by Id=8):");
        var specificCustomerById = repository.GetById(8);
        PrintCustomer(specificCustomerById);

        // Excerise 3: Reading a specific customer by FirstName
        Console.WriteLine("\nExercise 3: Read a specific customer by name (for example name like 'Heather'):");
        var specificCustomerByFirstName = repository.GetCustomerByName("Heather");
        PrintCustomers(specificCustomerByFirstName);

        // Excerise 4: Returning a page of customers from the database with given offset and limit. 
        Console.WriteLine("\nExcerise 4: Return a page of customers from the database (for example Offset=5 and Limit=3):");
        var customersByPage = repository.GetCustomersByPage(5, 3);
        PrintCustomers(customersByPage);

        //Excerise 5: Adding a new customer to the database.
        //You also need to add only the fields listed above (our customer object)
        Console.WriteLine("\nExcerise 5: Add a new customer to the database:");
        var wasAdded = repository.Add(customer);
        WasAddedDisplay(wasAdded);

        //Excerise 6: Updating an existing customer
        Console.WriteLine("\nExcerise 6: Update an existing customer:");
        var wasUpdated = repository.Update(customer);
        WasUpdatedDisplay(wasUpdated);

        //Excerise 7: Returning the number of customers in each country, ordered descending (high to low). 
        Console.WriteLine("\nExcerise 7: Return the number of customers in each country, ordered descending (high to low):");
        PrintCustomerCountry(repository.GetCustomersByCountry());

        //Excerise 8: Customers who are the highest spenders (total in invoice table is the largest), ordered descending.
        Console.WriteLine("\nExcerise 8: Customers who are the highest spenders (total in invoice table is the largest), ordered descending:");
        PrintHighestSpender(repository.GetHighestSpenders());

        //Excerise 9: 
        /*
        For a given customer, their most popular genre(in the case of a tie, display both). 
        Most popular in this context means the genre that corresponds to the most tracks 
        from invoices associated to thatcustomer.
        */
        Console.WriteLine("\nExcerise 9: Customer and their most popular genre:");
        PrintCustomersGenre(repository.GetMostPopularGenres());
    }

    // This display method are used by Excerice 1, 2, 3 and 4
    static void PrintCustomers(List<Customer> customers)
    {
        foreach (Customer customer in customers)
        {
            PrintCustomer(customer);
        }
    }

    // This display method are used by Excerice 1, 2, 3 and 4
    static void PrintCustomer(Customer customer)
    {
        Console.WriteLine($"--- {customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} {customer.Phone} {customer.Email} ---");
    }

    // This display method are only used by Excerise 5
    public static void WasAddedDisplay(Boolean wasAdded)
    {
        if (wasAdded)
        {
            Console.WriteLine("Customer was successfully added to the database.");
        }
        else
        {
            Console.WriteLine("Failed to add the customer to the database.");
        }
    }

    // This display method are only used by Excerise 6
    public static void WasUpdatedDisplay(Boolean wasUpdated)
    {
        if (wasUpdated)
        {
            Console.WriteLine("Customer was successfully updated to the database.");
        }
        else
        {
            Console.WriteLine("Failed to update the customer to the database.");
        }
    }

    // This display method are only used by Excerise 7
    static void PrintCustomerCountry(List<CustomerCountry> customerCountries)
    {
        foreach (CustomerCountry customerCountry in customerCountries)
        {
            Console.WriteLine($"Country: {customerCountry.Country}, Customers: {customerCountry.CustomersCount}");
        }
    }

    // This display method are only used by Excerise 8
    static void PrintHighestSpender(List<CustomerSpender> highestSpenders)
    {
        foreach (CustomerSpender spender in highestSpenders)
        {
            Console.WriteLine($"Customer ID: {spender.CustomerId}, Customer Name: {spender.CustomerName}, Total Spent: {spender.TotalSpent}");
        }
    }

    // This display method are only used by Excerise 9
    static void PrintCustomersGenre(List<CustomerGenre> customerGenres)
    {
        foreach (CustomerGenre customerGenre in customerGenres)
        {
            var genres = string.Join(", ", customerGenre.PopularGenres);
            Console.WriteLine($"--- {customerGenre.CustomerId} {customerGenre.CustomerName} - Genres: {genres} ---");
        }
    }
}