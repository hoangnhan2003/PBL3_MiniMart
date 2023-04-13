using ManageMiniMart.DAL;
using ManageMiniMart.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.BLL
{
    internal class DiscountService
    {
        private Manage_MinimartEntities db;
        public DiscountService()
        {
            db = new Manage_MinimartEntities();
        }
        public List<CBBItem> GetAllDiscounts() {
            List<CBBItem> list = new List<CBBItem>();
            var p = db.Discounts.Select(o => new { o.discount_id, o.discount_name }).ToList();
            list.Add(new CBBItem
            {
                Value = 0,
                Text = "None"
            });
            foreach (var item in p)
            {
                list.Add(new CBBItem { 
                    Text = item.discount_name, Value = item.discount_id
                });
            }
            return list;
        }
        public Discount getById(int id)
        {
            var s1 = db.Discounts.Where(o => o.discount_id == id).FirstOrDefault();
            return s1;
        }
    }
}
