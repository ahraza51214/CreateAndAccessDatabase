using System;
using System.Diagnostics.Metrics;
using System.Reflection.PortableExecutable;
using CreateAndAccessDatabase.AppendixB.Models;
using Microsoft.Data.SqlClient;

namespace CreateAndAccessDatabase.AppendixB.Repositories.Customers
{
	public class CustomerRepository : ICustomerRepository
	{

        //private readonly SqlConnection connection = new SqlConnection(ConnectionStringHelper.GetConnectionstring());
        // Exercise 1: Print all the customer in the database:

        public List<Customer> GetAll()
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            try
            {
                //using (connection)
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();
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
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return customerList;
        }


        public Customer GetById(int customerId)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE CustomerId = @customerId";
            try
            {
                //using (connection)
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
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
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return customer;
        }


        public List<Customer> GetCustomerByName(string name)
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE FirstName LIKE @name OR LastName LIKE @name";
            try
            {
                //using (connection)
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", "%" + name + "%");
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();
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
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return customerList;
        }


        public List<Customer> GetCustomersByPage(int offset, int limit)
        {
            List<Customer> customerList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email " +
                            "FROM Customer " +
                            "ORDER BY CustomerId " +
                            "OFFSET @offset ROWS " +
                            "FETCH NEXT @limit ROWS ONLY";
            try
            {
                //using (connection)
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionstring()))
                {
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
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return customerList;
        }


        public bool Add(Customer customer)
        {
            bool success = false;
            string sql = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email) " +
                            "VALUES (@firstName, @lastName, @country, @postalCode, @phone, @email)";
            try
            {
                //using (connection)
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionstring()))
                {
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
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return success;
        }


        public bool Update(Customer customer)
        {
            bool success = false;
            string sql = "UPDATE Customer " +
                            "SET FirstName = @firstName, LastName = @lastName, Country = @country, PostalCode = @postalCode, Phone = @phone, Email = @email " +
                            "WHERE CustomerId = @customerId";
            try
            {
                //using (connection)
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionstring()))
                {
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
                        //cmd.ExecuteNonQuery();
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
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


        public List<CustomerCountry> GetCustomersByCountry()
        {
            List<CustomerCountry> customersInCountries = new List<CustomerCountry>();
            string sql = "SELECT Country, COUNT(*) as Count " +
                         "FROM Customer " +
                         "GROUP BY Country " +
                         "ORDER BY Count DESC";
            try
            {
                //using (connection)
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionstring()))
                {
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
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return customersInCountries;
        }


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
                //using (connection)
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionstring()))
                {
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
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return highestSpenders;
        }



        public List<Customer> GetMostPopularGenres()
        {
            List<Customer> customerList = new List<Customer>();

            /* Related to the string sql:
            We join the necessary tables to associate customers with their purchased tracks and genres.
            We group by customer and genre, counting the tracks purchased for each genre.
            For each customer and genre, it checks if the count of tracks for that genre is equal to 
            the highest count of tracks for any genre for that customer.
            */
            string sql =
                "SELECT a.CustomerId, " +
                    "a.FirstName, " + 
                    "a.LastName AS CustomerName," +
                    "a.Country, " +
                    "a.PostalCode, " +
                    "a.Phone, " +
                    "a.Email, " +
                    "e.NAME AS Genre,COUNT(e.NAME) AS TracksBought " +
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
                    "a.FirstName, " +
                    "a.LastName, " +
                    "a.Country, " +
                    "a.PostalCode, " +
                    "a.Phone, " +
                    "a.Email, " +
                    "e.NAME " +
                
                /*
                For each customer-genre grouping, we want to see if the count of tracks purchased 
                for that genre matches the highest count for that customer across all genres. 
                This is accomplished with the HAVING clause:
                */
                "HAVING " +
                    /* 
                    For each grouping, it finds the maximum number of tracks purchased 
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
                //using (connection)
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.GetString(3);
                                customer.PostalCode = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                                customer.Phone = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                                customer.Email = reader.GetString(6);

                                string genreName = !reader.IsDBNull(7) ? reader.GetString(7) : string.Empty;
                                customer.PopularGenres.Add(genreName);
                                customerList.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log to console
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            return customerList;
        }


    }
}