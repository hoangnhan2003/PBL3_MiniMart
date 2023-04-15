using ManageMiniMart.DAL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.BLL
{
 
    public class ProductDiscountService
    {
        private Manage_MinimartEntities db;
        public ProductDiscountService()
        {
            db = new Manage_MinimartEntities();
        }
        public void save(Product_Discount product_Discount)
        {
            db.Product_Discount.Add(product_Discount);
            db.SaveChanges();
        }
        public Product_Discount findByProductIdAndDiscountId(int productId, int discountId)
        {
            return db.Product_Discount.Where( p => p.product_id == productId && discountId== p.discount_id).FirstOrDefault();
        }
        public void remove(Product_Discount product_Discount)
        {
            if (product_Discount != null)
            {
                db.Product_Discount.Remove(product_Discount);
                db.SaveChanges();
            }
        }
        public void removeByProductId(int productId)
        {
            var productDiscount = db.Product_Discount.Where(p => p.product_id==productId).ToList();
            db.Product_Discount.RemoveRange(productDiscount);
            var id = db.Products.Where(p => p.product_id.Equals(productId)).ToList();
            db.Products.RemoveRange(id);
            db.SaveChanges();
        }
    }
}
