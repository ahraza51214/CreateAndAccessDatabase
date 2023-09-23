using CreateAndAccessDatabase.AppendixB.Models;
using CreateAndAccessDatabase.AppendixB.Repositories;
using CreateAndAccessDatabase.AppendixB.Repositories.Customers;

namespace CreateAndAccessDatabase.AppendixB;

class Program
{
    static void Main(String[] args)
    {
        ICustomerRepository repository = new CustomerRepository();

        // This is only used in Excerise 5 and 6.
        Customer customer = new Customer { CustomerId = 57, FirstName = "Ali", LastName = "Raza", Country = "Denmark", Email = "Ali@Ali.dk", Phone = "1234578", PostalCode = "2670" };


        // Excerise 1: Print all the customer in the database
        var allCustomers = repository.GetAll();
        Console.WriteLine("Exercise 1: Print all the customer in the database:");
        PrintCustomers(allCustomers);

        // Excerise 2: Read a specific customer from the database by the Id
        Console.WriteLine("\nExercise 2: Read a specific customer from the database (by Id=8):");
        var specificCustomerById = repository.GetById(8);
        PrintCustomer(specificCustomerById);

        // Excerise 3: Read a specific customer by FirstName
        Console.WriteLine("\nExercise 3: Read a specific customer by FirstName (for example FirstName='Heather'):");
        var specificCustomerByFirstName = repository.GetCustomerByName("Heather");
        PrintCustomers(specificCustomerByFirstName);

        // Excerise 4: Return a page of customers from the database. 
        Console.WriteLine("\nExcerise 4: Return a page of customers from the database (for example Offset=5 and Limit=3):");
        var customersByPage = repository.GetCustomersByPage(5, 3);
        PrintCustomers(customersByPage);

        //Excerise 5: Add a new customer to the database.
        //You also need to add only the fields listed above (our customer object)
        Console.WriteLine("\nExcerise 5: Add a new customer to the database:");
        var wasAdded = repository.Add(customer);
        WasAddedDisplay(customer, wasAdded);

        //Excerise 6: Update an existing customer
        Console.WriteLine("\nExcerise 6: Update an existing customer:");
        var wasUpdated = repository.Update(customer);
        WasUpdatedDisplay(customer, wasUpdated);

        //Excerise 7: Return the number of customers in each country, ordered descending (high to low). 
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

    // This display method are only sued by Excerise 9
    static void PrintCustomersGenre(List<Customer> customers)
    {
        foreach (Customer customer in customers)
        {
            PrintCustomerGenre(customer);
        }
    }

    // This display method are only sued by Excerise 9
    public static void PrintCustomerGenre(Customer customer)
    {
        var genres = string.Join(", ", customer.PopularGenres);
        Console.WriteLine($"--- {customer.CustomerId} {customer.FirstName} {customer.LastName} {customer.Country} {customer.PostalCode} {customer.Phone} {customer.Email} - Genres: {genres} ---");
    }

    // This display method are only sued by Excerise 5
    public static void WasAddedDisplay(Customer customer, Boolean wasAdded)
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

    // This display method are only sued by Excerise 6
    public static void WasUpdatedDisplay(Customer customer, Boolean wasUpdated)
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

    // This display method are only sued by Excerise 7
    static void PrintCustomerCountry(List<CustomerCountry> customerCountries)
    {
        foreach (CustomerCountry customerCountry in customerCountries)
        {
            Console.WriteLine($"Country: {customerCountry.Country}, Count: {customerCountry.CustomersCount}");
        }
    }

    // This display method are only sued by Excerise 8
    static void PrintHighestSpender(List<CustomerSpender> highestSpenders)
    {
        foreach (CustomerSpender spender in highestSpenders)
        {
            Console.WriteLine($"Customer ID: {spender.CustomerId}, Customer Name: {spender.CustomerName}, Total Spent: {spender.TotalSpent}");
        }
    }



}