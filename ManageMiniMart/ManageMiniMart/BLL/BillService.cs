using ManageMiniMart.DAL;
using ManageMiniMart.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.BLL
{
    internal class BillService
    {
        private Manage_MinimartEntities db;
        
        public BillService()
        {
            db= new Manage_MinimartEntities();
        }
        public List<BillView> convertToBillViews(List<Bill> bills)
        {
            List<BillView> result = new List<BillView>();
            foreach(Bill bill in bills)
            {
                var productInBill = db.Bill_Product.Where( b => b.bill_id == bill.bill_id ).ToList();
                double total = 0;
                foreach( var product in productInBill)
                {
                    total += product.price;
                }
                result.Add(new BillView
                {
                    Id= bill.bill_id,
                    CustomerName = bill.Customer.customer_name,
                    EmployeeName = bill.Person.person_name,
                    CreatedTiem = bill.created_time.ToString(),
                    Total= total,
                });
            }
            return result;
        }
        public List<BillView> GetAllBillView() {
            var bills = db.Bills.ToList();
            return convertToBillViews(bills);
        }
        public List<BillView> findByCustomerName(string customerName) {
            var bills = db.Bills.Where(b => b.Customer.customer_name.Contains(customerName)).ToList();
            return convertToBillViews(bills);
        }

    }
}
