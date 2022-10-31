using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Repositories
{
    public interface ICustomerRepository
    {
        public Customer GetCustomer(int id);
        public List<Customer> GetAllCustomers();
        public Customer GetCustomerByName(string name);
        public List<Customer> GetCustomerPage(int limit, int offset);
        public bool AddCustomer (Customer customer);
        public bool UpdateCustomer(int id, Customer customer);
        public List<CustomerCountry> GetAllCustomersCountry();
        public List<CustomerSpender> GetAllCustomersSpenders();
        public CustomerGenre GetCustomerGenre(int customerId);

    }
}
