using ManageMiniMart.DAL;
using ManageMiniMart.DTO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.BLL
{
    internal class CustomerService
    {
        private Manage_MinimartEntities db;
        public CustomerService()
        {
            db = new Manage_MinimartEntities();
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
        
        public void save(Customer customer)
        {
            db.Customers.AddOrUpdate(customer);
            db.SaveChanges();
        }
        public void delete(Customer customer)
        {
            db.Customers.Remove(customer);
            db.SaveChanges();
        }
        public Customer findById(string id)
        {
            return db.Customers.Find(id);
        }
        public List<CustomerView> findByName(string name)
        {
            var p = db.Customers.Where( c => c.customer_name.Contains(name)).ToList();
            List<CustomerView> customerViews= convertToCustomerView(p);
            return customerViews;
        }
        public List<int> getAllYear()
        {
            List<int> years = new List<int>();
            var yearsInCustomer = db.Customers.OrderBy(C => C.created_time).Select(c => new { c.created_time.Year }).ToList().Distinct();
            foreach(var year in yearsInCustomer)
            {
                years.Add(year.Year);
            }
            return years;
        }
        public int getAmountInMonthAndYear(int month ,int year)
        {
            int result = 0;
            result = db.Customers.Count(s => s.created_time.Month == month && s.created_time.Year == year);
            return result;
        }
        public int getAmountCustomerInSystem()
        {
            return db.Customers.Count();
        }
    }
}
