using ManageMiniMart.DAL;
using ManageMiniMart.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageMiniMart.BLL
{
    internal class StatisticalService
    {
        private Manage_MinimartEntities db;
        public StatisticalService() {
            db = new Manage_MinimartEntities();
        }

        public List<int> getAllYear()
        {
            List<int> result = new List<int>();
            var p = db.Bills.Select( b => b.created_time.Year).Distinct().ToList();
            foreach(var b in p)
            {
                result.Add(b);
            }
            return result;
        }
        
        public Revenue getAllRevenue(int year,int month)
        {
            List<Revenue> revenues= new List<Revenue>();
            // Total money bill in month,year
            double total = 0;
            var bills = db.Bills.Where(b => b.created_time.Year == year && b.created_time.Month == month).ToList();
            foreach(var b in bills)
            {
                double totalMoneyInBill = 0;
                var productsInBill = db.Bill_Product.Where(b1 => b1.bill_id == b.bill_id).ToList();
                foreach(var bill in productsInBill)
                {
                    totalMoneyInBill += bill.price;
                }
                total += totalMoneyInBill;
            }

            return new Revenue { 
                Month= month,
                Year= year,
                Value = total
            };
        }
    }
}
