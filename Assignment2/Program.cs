using Assignment2.Models;
using Assignment2.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

          ICustomerRepository repository = new CustomerRepository();

            // TestSelectAllCustomers(repository);
            // TestGetCustomerById(repository, 3);
            // TestGetCustomerByName(repository, "Lui");
            // TestGetCustomerPage(repository, 10, 10 );
            // CustomerFull customer = new CustomerFull() { FirstName="Roberta", LastName="Ramos", Country="England", PostalCode="1234", Phone="123 123 123", Email="email@email.com"};
            // TestAddCustomer(repository, customer);
            // TestGetCustomerCountry(repository.GetAllCustomersCountry());
            // TestGetCustomerSpenders(repository.GetAllCustomersSpenders());
            // TestGetCustomerGenre(repository, 12);
            // TestUpdateCustomer(repository);

        }

        private static void TestUpdateCustomer(ICustomerRepository repository )
        {
            Customer customer = repository.GetCustomer(1);
            customer.FirstName = "Richard";
            Console.WriteLine(repository.UpdateCustomer(customer.CustomerId, customer));
        }

        static void TestAddCustomer ( ICustomerRepository repository, Customer customer)
        {
            Console.WriteLine(repository.AddCustomer(customer));
        }

        static void TestGetCustomerPage(ICustomerRepository repository, int offset, int limit)
        {
            PrintCustomers(repository.GetCustomerPage(limit, offset));
        }

        static void TestGetCustomerGenre(ICustomerRepository repository, int customerId)
        {
            List<CustomerGenre> genres = repository.GetCustomerGenre(customerId);
          
            foreach (CustomerGenre genre in genres)
            {
                  Console.WriteLine($"{genre.Name} - {genre.Amount}");
            }


        }

       static void TestGetCustomerSpenders(List<CustomerSpender> spenders)
        {
            foreach (CustomerSpender spender in spenders)
            {
                Console.WriteLine($"{spender.CustomerId} - {spender.FirstName} - {spender.LastName} - {spender.Total}");
            }
        }

        static void TestGetCustomerCountry(List<CustomerCountry> countries)

        {
            Console.WriteLine("Country \t Amount");
            foreach (CustomerCountry country in countries)
            {
                Console.WriteLine($"{country.Country} \t {country.Amount}");
            }
        }
        static void TestSelectAllCustomers(ICustomerRepository repository)
        {
            PrintCustomers(repository.GetAllCustomers());
        }

        static void TestGetCustomerById (ICustomerRepository repository, int id)
        {
            PrintCustomer(repository.GetCustomer(id));

        }

        static void TestGetCustomerByName(ICustomerRepository repository, string firstName)
        {
            PrintCustomer(repository.GetCustomerByName(firstName));
        }

        static void PrintCustomers(IEnumerable<Customer> customers)
        {
            foreach (Customer customer in customers)
            {
                PrintCustomer(customer);
            }
        }

        static void PrintCustomer(Customer customer)
        {
            Console.WriteLine($"--- {customer.CustomerId} \t {customer.FirstName}  {customer.LastName}  {customer.Country}  {customer.Email} ---");
        }


    }
}
