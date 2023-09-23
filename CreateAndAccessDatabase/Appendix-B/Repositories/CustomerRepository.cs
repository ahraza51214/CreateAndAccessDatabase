using CreateAndAccessDatabase.Appendix_B.Repositories;
using CreateAndAccessDatabase.Model;
using Microsoft.Data.SqlClient;

namespace SQLClientCRUDRepo.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomer(int id)
        {
            Customer customer = new Customer();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer" +
                " WHERE CustomerId = @CustomerId";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
                                customer.LastName = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty;
                                customer.Country = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty;
                                customer.PostalCode = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                                customer.Phone = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                                customer.Email = !reader.IsDBNull(6) ? reader.GetString(6) : string.Empty;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log to error
            }
            return customer;

        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> custList = new List<Customer>();
            string sql = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer temp = new Customer();
                                temp.CustomerId = reader.GetInt32(0);
                                temp.FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
                                temp.LastName = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty; 
                                temp.Country = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty;
                                temp.PostalCode = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                                temp.Phone = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                                temp.Email = !reader.IsDBNull(6) ? reader.GetString(6) : string.Empty;
                                custList.Add(temp);
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
            return custList;

        }

        public bool AddNewCustomer(Customer customer)
        {
            bool success = false;
            string sql = "INSERT INTO Customers(CustomerId,FirstName,LastName,Country,PostalCode,Phone,Email) " +
                "VALUES(@CustomerId,@FirstName,@LastName,@Country,@PostalCode,@Phone,@Email)";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log to console
            }
            return success;
        }

        public bool UpdateCustomer(Customer customer)
        {
            bool success = false;
            string sql = "UPDATE Customers " +
                "SET CustomerId = @CustomerId, FirstName = @FirstName, " +
                "LastName = @LastName, Country = @Country, @PostalCode = PostalCode, @Phone = Phone, @Email = Email";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerId);
                        cmd.Parameters.AddWithValue("@CompanyName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@ContactName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log to console
            }
            return success;
        }

        public bool DeleteCustomer(string id)
        {
            bool success = false;
            string sql = "DELETE FROM Customers " +
                "WHERE CustomerId = @CustomerId";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionstring()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", id);
                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log to console
            }
            return success;
        }
    }
}

