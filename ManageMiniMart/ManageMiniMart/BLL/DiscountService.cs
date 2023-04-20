using ManageMiniMart.DAL;
using ManageMiniMart.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        public List<DiscountView> convertToDiscountView(List<Discount> discounts)
        {
            List<DiscountView> list = new List<DiscountView>();
            foreach (var discount in discounts)
            {
                string products = "";
                foreach(var item in discount.Product_Discount)
                {
                    products += item.Product.product_name + " ";
                }
                list.Add(new DiscountView
                {
                    Id = discount.discount_id,
                    Name = discount.discount_name,
                    StartTime = discount.start_time.ToString(),
                    EndTime = discount.end_time.ToString(),
                    PercentSale = (int)discount.sale,
                    Products= products

                });
            }
            return list;
        }
        public List<DiscountView> GetDiscountsView()
        {
            return convertToDiscountView(db.Discounts.ToList());
        }
        public Discount getById(int id)
        {
            var s1 = db.Discounts.Where(o => o.discount_id == id).FirstOrDefault();
            return s1;
        }
        public void save(Discount discount)
        {
            db.Discounts.AddOrUpdate(discount);
            db.SaveChanges();
        }
        public void delete(Discount discount)
        {
            db.Discounts.Remove(discount);
            db.SaveChanges(); 
        }
    }
}
