using System;
using System.Diagnostics.Metrics;
using System.Reflection.PortableExecutable;
using CreateAndAccessDatabase.AppendixB.Models;
using Microsoft.Data.SqlClient;

namespace CreateAndAccessDatabase.AppendixB.Repositories.Customers
{
	public class CustomerRepository : ICustomerRepository
	{

        // The method GetAll() is related to Excerise 1.
        // It has no parameters and just returns a list of all the customers
        public List<Customer> GetAll()
        {
            List<Customer> customerList = new List<Customer>();

            // This is just a very simpel sql query with a SELECT clause and a FROM clause.
            // The reason of this simplicity is that Excerise 1 only ask for display all the customer,
            // and since all the relerant attributes can be found in just one table called 'Customer',
            // there are no needs of writing complex SQL queries.
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            try
            {
                // Here we instantiate our SqlConnection and named it 'conn' and used it later to open the 
                // connection to the database 'Chinook'
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    // Here we are oppening the connection to the database 'Chinook'
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();

                                // Here we have to take care of that the two attributes 'PostalCode' and 'Phone'
                                // can be null. All ohter attributes are not null for sure.
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                                customer.Phone = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                                customer.Email = reader.GetString(6);
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }
            // If something fails, it will be nice to see the error message.
            // Therefore, we are using a try-catch and printing the error mesage in the console
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return customerList;
        }

        // The method GetById(int customerId) is related to Exercise 2.
        // It takes one parameter which is an integer. That is just the Id of the customer.
        public Customer GetById(int customerId)
        {
            Customer customer = new Customer();

            // This SQL string is very simple. We only use a SELECT clause, FROM clause and a WHERE clause.
            // The WHERE clause 'WHERE CustomerId = @customerId' is used, because in this Excerise,
            // we are reading the specific customer by its Id.
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId = @customerId";
            try
            {
                // Here we instantiate our SqlConnection and named it 'conn' and used it later to open the 
                // connection to the database 'Chinook'
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    // Here we are oppening the connection to the database 'Chinook'
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // The argument 'customerId' is just the '@customerId' in the SQL string
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Here we have to take care of that the two attributes 'PostalCode' and 'Phone'
                                // can be null. All ohter attributes are not null for sure.
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                                customer.Phone = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                                customer.Email = reader.GetString(6);
                            }
                        }
                    }
                }
            }
            // If something fails, it will be nice to see the error message.
            // Therefore, we are using a try-catch and printing the error mesage in the console
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return customer;
        }

        // The method GetCustomerByName(string name) is related to Excerise 3.
        // It returns a list of a specific customer determined by the parameter 'name'.
        // This parameter can both be the firstname or the lastname of the customer,
        // since it is not specified in the assignment what the 'name'is referred to.
        // Therefore, our SQL query has the WHERE clause 'WHERE FirstName LIKE @name OR LastName LIKE @name'.
        public List<Customer> GetCustomerByName(string name)
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE FirstName LIKE @name OR LastName LIKE @name";
            try
            {
                // Here we instantiate our SqlConnection and named it 'conn' and used it later to open the 
                // connection to the database 'Chinook'
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    // Here we are oppening the connection to the database 'Chinook'
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", "%" + name + "%");
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();

                                // Here we have to take care of that the two attributes 'PostalCode' and 'Phone'
                                // can be null. All ohter attributes are not null for sure.
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                                customer.Phone = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                                customer.Email = reader.GetString(6);
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }
            // If something fails, it will be nice to see the error message.
            // Therefore, we are using a try-catch and printing the error mesage in the console
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return customerList;
        }

        // The method GetCustomersByPage(int offset, int limit) is related to Excerise 4.
        // It takes two integer parameters offset and limits. These parameters are used
        // to display a page of customers from the database.
        public List<Customer> GetCustomersByPage(int offset, int limit)
        {
            List<Customer> customerList = new List<Customer>();

            // This SQL query is not a complex query. The only special SQL keywords in this query is 
            // "OFFSET @offset ROWS " and "FETCH NEXT @limit ROWS ONLY". We are using these keywords,
            // because we need to display the customer as a page from the database.
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                            "FROM Customer " +
                            "ORDER BY CustomerId " +
                            "OFFSET @offset ROWS " +
                            "FETCH NEXT @limit ROWS ONLY";
            try
            {
                // Here we instantiate our SqlConnection and named it 'conn' and used it later to open the 
                // connection to the database 'Chinook'
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    // Here we are oppening the connection to the database 'Chinook'
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@offset", offset);
                        cmd.Parameters.AddWithValue("@limit", limit);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();

                                // Here we have to take care of that the two attributes 'PostalCode' and 'Phone'
                                // can be null. All ohter attributes are not null for sure.
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                                customer.Phone = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                                customer.Email = reader.GetString(6);
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }
            // If something fails, it will be nice to see the error message.
            // Therefore, we are using a try-catch and printing the error mesage in the console
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return customerList;
        }

        // The method Add(Customer customer) is related to Excerise 5.
        // It takes only one parameter of type Customer and returns 
        // the boolean indicating wether the new customer was added successfully or not.
        public bool Add(Customer customer)
        {
            // Define and decleare a bool variable and named it 'success' and set it as false at the beginning.
            bool success = false;

            // This SQL string is just simple. Since we are adding a new customer, we used 
            // the SQL keywords 'INSERT INTO' and 'VALUES'.
            string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) " +
                            "VALUES (@firstName, @lastName, @country, @postalCode, @phone, @email)";
            try
            {
                // Here we instantiate our SqlConnection and named it 'conn' and used it later to open the 
                // connection to the database 'Chinook'
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    // Here we are oppening the connection to the database 'Chinook'
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@lastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@country", customer.Country);
                        cmd.Parameters.AddWithValue("@postalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@email", customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            // If something fails, it will be nice to see the error message.
            // Therefore, we are using a try-catch and printing the error mesage in the console
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return success;
        }

        // The method Update(Customer customer) is related to Excerise 6.
        // It takes only one parameter of type Customer and returns 
        // the boolean indicating wether the new customer was updated successfully or not.
        public bool Update(Customer customer)
        {
            // Define and decleare a bool variable and named it 'success' and set it as false at the beginning.
            bool success = false;

            // This SQL string is just simple. Since we are updating a new customer, we used 
            // the SQL keywords 'UPDATE' and 'SET'.
            string sql = "UPDATE Customer " +
                            "SET FirstName = @firstName, LastName = @lastName, Country = @country, PostalCode = @postalCode, Phone = @phone, Email = @email " +
                            "WHERE CustomerId = @customerId";
            try
            {
                // Here we instantiate our SqlConnection and named it 'conn' and used it later to open the 
                // connection to the database 'Chinook'
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    // Here we are oppening the connection to the database 'Chinook'
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@lastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@country", customer.Country);
                        cmd.Parameters.AddWithValue("@postalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@email", customer.Email);
                        cmd.Parameters.AddWithValue("@customerId", customer.CustomerId);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            // If something fails, it will be nice to see the error message.
            // Therefore, we are using a try-catch and printing the error mesage in the console
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return success;
        }


        public bool Delete(int id)
        {
            // Not a requirement to implement for this Assignment.
            throw new NotImplementedException();
        }

        // The method GetCustomersByCountry() is related to Excerise 7.
        // This method does not take any parameter, since as mentioned in the assignment we
        // just need to display all the customers from the database with the requiment
        // that we need to count the number of customers in each country, ordered descending.
        // Therefore, its SQL string is just simple. It only contains 'SELECT', 'FROM', 'GROUP BY' and
        // the 'ORDER BY' clauses. Here, we need the "GROUP BY Country ", because we need to count for
        // each country.
        public List<CustomerCountry> GetCustomersByCountry()
        {
            List<CustomerCountry> customersInCountries = new List<CustomerCountry>();
            string sql = "SELECT Country, COUNT(*) as Count " +
                         "FROM Customer " +
                         "GROUP BY Country " +
                         "ORDER BY Count DESC";
            try
            {
                // Here we instantiate our SqlConnection and named it 'conn' and used it later to open the 
                // connection to the database 'Chinook'
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    // Here we are oppening the connection to the database 'Chinook'
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerCountry customerCountry = new CustomerCountry();
                                customerCountry.Country = !reader.IsDBNull(0) ? reader.GetString(0) : string.Empty;
                                customerCountry.CustomersCount = reader.GetInt32(1);
                                customersInCountries.Add(customerCountry);
                            }
                        }
                    }
                }
            }
            // If something fails, it will be nice to see the error message.
            // Therefore, we are using a try-catch and printing the error mesage in the console
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return customersInCountries;
        }

        // The method GetHighestSpenders() is related to Excerise 8.
        // This method does not take any parameter, since the goal of this method is just to read 
        // Customers who are the highest spenders (total in invoice table is the largest), ordered descending.
        // Therefore, the SQL string inside this method contains the SQL aggregated function 'SUM' and at the
        // same time we use 'GROUP BY' because we need to display the list for each customer.
        public List<CustomerSpender> GetHighestSpenders()
        {
            List<CustomerSpender> highestSpenders = new List<CustomerSpender>();
            string sql = @"SELECT Customer.CustomerId, 
                                  Customer.FirstName + ' ' + Customer.LastName as CustomerName, 
                                  SUM(Invoice.Total) as TotalSpent
                         FROM Customer
                         INNER JOIN Invoice ON Customer.CustomerId = Invoice.CustomerId
                         GROUP BY Customer.CustomerId, Customer.FirstName, Customer.LastName
                         ORDER BY TotalSpent DESC";
            try
            {
                // Here we instantiate our SqlConnection and named it 'conn' and used it later to open the 
                // connection to the database 'Chinook'
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    // Here we are oppening the connection to the database 'Chinook'
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSpender spender = new CustomerSpender
                                {
                                    CustomerId = reader.GetInt32(0),
                                    CustomerName = reader.GetString(1),
                                    TotalSpent = reader.GetDecimal(2)
                                };
                                highestSpenders.Add(spender);
                            }
                        }
                    }
                }
            }
            // If something fails, it will be nice to see the error message.
            // Therefore, we are using a try-catch and printing the error mesage in the console
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return highestSpenders;
        }


        // The method GetMostPopularGenres() is related to Excerise 9.
        // It does not take any parameters and returns for a given customer,
        // their most popular genre (in the case of a tie, display both). Most popular in this 
        // context means the genre that corresponds to the most tracks from invoices associated
        // to that customer.
        public List<CustomerGenre> GetMostPopularGenres()
        {
            List<CustomerGenre> customerList = new List<CustomerGenre>();

            /* Related to the string sql:
            We join the necessary tables to associate customers with their purchased tracks and genres.
            We group by customer and genre, counting the tracks purchased for each genre.
            For each customer and genre, we checks if the count of tracks for that genre is equal to 
            the highest count of tracks for any genre for that customer.
            */
            string sql =
                "SELECT a.CustomerId, " +
                    "a.FirstName + ' ' + a.LastName AS CustomerName, " + 
                    "e.NAME AS Genre, " +
                    "COUNT(e.NAME) AS TracksBought " +
                "FROM Customer a " +
                    "INNER JOIN Invoice b ON b.CustomerId = a.CustomerId " +
                    "INNER JOIN InvoiceLine c ON c.InvoiceId = b.InvoiceId " +
                    "INNER JOIN Track d ON d.TrackId = c.TrackId " +
                    "INNER JOIN Genre e ON e.GenreId = d.GenreId " +
                
                /*
                The main query aggregates the tracks purchased by each customer for each genre:
                */
                "GROUP BY " +
                    "a.CustomerId, " +
                    "a.FirstName + ' ' + a.LastName, " +
                    "e.NAME " +
                
                /*
                For each customer-genre grouping, we want to see if the count of tracks purchased 
                for that genre matches the highest count for that customer across all genres. 
                This is accomplished with the HAVING clause:
                */
                "HAVING " +
                    /* 
                    For each grouping, we finds the maximum number of tracks purchased 
                    from any genre for the associated customer. 
                    If there is a tie (e.g., a customer has purchased 10 rock tracks and 10 pop tracks), 
                    then both the counts match the maximum count found by the subquery, 
                    so both genres are included in the result.
                    */
                    "COUNT(e.NAME) = ( " +
                    "SELECT TOP 1 COUNT(e1.NAME) " +
                    "FROM Invoice b1 " +
                    "INNER JOIN InvoiceLine c1 ON c1.InvoiceId = b1.InvoiceId " +
                    "INNER JOIN Track d1 ON d1.TrackId = c1.TrackId " +
                    "INNER JOIN Genre e1 ON e1.GenreId = d1.GenreId " +
                    "WHERE b1.CustomerId = a.CustomerId " +
                    "GROUP BY e1.NAME " +
                    "ORDER BY COUNT(e1.NAME) DESC " +
                    ") " +
                "ORDER BY " +
                "a.CustomerId, " +
                "TracksBought DESC; ";
            try
            {
                // Here we instantiate our SqlConnection and named it 'conn' and used it later to open the 
                // connection to the database 'Chinook'
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionString()))
                {
                    // Here we are oppening the connection to the database 'Chinook'
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerGenre customer = new CustomerGenre();
                                customer.CustomerId = reader.GetInt32(0);
                                customer.CustomerName = reader.GetString(1);
                                
                                // Here we just want to take care
                                string genreName = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
                                customer.PopularGenres.Add(genreName);
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }
            // If something fails, it will be nice to see the error message.
            // Therefore, we are using a try-catch and printing the error mesage in the console
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return customerList;
        }


    }
}