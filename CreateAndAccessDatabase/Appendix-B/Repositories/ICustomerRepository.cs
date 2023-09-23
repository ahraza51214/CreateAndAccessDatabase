using CreateAndAccessDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAndAccessDatabase.Appendix_B.Repositories
{
    public interface ICustomerRepository
    {
        // Excerise 1:
        public List<Customer> GetAllCustomers();
        // Excerise 2:
        public Customer GetCustomerById(int id);
        // Excerise 3:
        public Customer GetCustomerByFirstName(string FirstName);

        public bool AddNewCustomer(Customer customer);
        public bool UpdateCustomer(Customer customer);
        public bool DeleteCustomer(string id);
    }
}
