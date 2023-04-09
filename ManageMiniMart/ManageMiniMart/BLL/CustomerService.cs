using ManageMiniMart.DAL;
using ManageMiniMart.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.BLL
{
    internal class CustomerService
    {
        private MinimartDatabase db;
        public CustomerService()
        {
            db = new MinimartDatabase();
        }
        public List<CustomerView> convertToCustomerView(List<Customer> customers) {
            List<CustomerView> result = new List<CustomerView>();
            foreach (Customer customer in customers)
            {
                result.Add(new CustomerView
                {
                    Id = customer.customer_id,
                    Name = customer.customer_name,
                    Address = customer.address,
                    Email = customer.email,
                    Point = (int)customer.point,
                    BirthDate = customer.birthdate.ToString()
                });
            }
            return result;
        }
        public List<CBBPerson> convertToCBB(List<Customer> customers)
        {
            List<CBBPerson> result = new List<CBBPerson>();
            foreach (Customer customer in customers)
            {
                result.Add(new CBBPerson
                {
                    Value = customer.customer_id,
                    Text = customer.customer_name,
                });
            }
            return result;
        }
        public List<CustomerView> GetCustomers()
        {
            var c = db.Customers.ToList();
            List<CustomerView> customerViews = convertToCustomerView(c);
            return customerViews;
        }
        public List<CBBPerson> getAllCBB()
        {
            var c = db.Customers.ToList();
            List<CBBPerson> cBBPeople = convertToCBB(c);
            cBBPeople.Add(new CBBPerson
            {
                Text = "None",
                Value = ""
            });
            cBBPeople.Reverse();
            return cBBPeople;

        }
    }
}
