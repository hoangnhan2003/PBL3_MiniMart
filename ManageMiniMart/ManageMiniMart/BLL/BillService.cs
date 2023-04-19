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
        private Bill_ProductService bill_ProductService;
        public int IdBillAdded;
        
        public BillService()
        {
            db= new Manage_MinimartEntities();
            bill_ProductService= new Bill_ProductService(); 
        }
        public List<BillView> convertToBillViews(List<Bill> bills)
        {
            List<BillView> result = new List<BillView>();
            List<Bill> billAll = bills;
            foreach(Bill bill in bills)
            {
                var productInBill = db.Bill_Product.Where( b => b.bill_id == bill.bill_id ).ToList();
                double total = 0;
                foreach( var product in productInBill)
                {
                    total += product.price*product.quantity;
                }
                result.Add(new BillView
                {
                    Id= bill.bill_id,
                    CustomerName = bill.Customer != null ? bill.Customer.customer_name :"Unknow",
                    EmployeeName = bill.Person.person_name,
                    CreatedTime = bill.created_time.ToString(),
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
        public void addBill(Bill bill)
        {
            db.Bills.Add(bill);
            db.SaveChanges();
            this.IdBillAdded = bill.bill_id;
        }
        public Bill getById(int id)
        {
            return db.Bills.Find(id);
        }
        public double getTotalByBill(int billId) {
            Bill bill = getById(billId);
            double total = 0;
            foreach (Bill_Product bill_Product in bill_ProductService.GetBill_ProductByBillId(billId))
            {
                total += bill_Product.price * bill_Product.quantity;
            }
            
            return total;
        }
        public List<BillView> getAllBillViewByCustomerName(string customerName)
        {
            var bills = db.Bills.Where(b => b.Customer.customer_name.Contains(customerName)).ToList();
            return convertToBillViews(bills);
        }

    }
}
