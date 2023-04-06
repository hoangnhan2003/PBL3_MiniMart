using ManageMiniMart.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.BLL
{
    
    internal class ProductService
    {
        private MinimartDatabase db;
        public ProductService() { 
            db = new MinimartDatabase();
        }
        public List<ProductDTO> getAllProduct()
        {
            List<ProductDTO> products = new List<ProductDTO>();
            var disocuntList = db.Discounts.Select(p => p);
            var l = db.Products.Select(p => new {
                p.product_id,p.product_name,p.price,p.quantity,p.Category.category_name,p.brand,p.Discounts
            }).ToList();
            foreach (var product in l)
            {
                string sale = "";
                foreach(Discount d in product.Discounts)
                {
                    sale += Convert.ToString(d.sale) + " , ";
                }
                products.Add(new ProductDTO
                {
                    ProductId = product.product_id,
                    Name = product.product_name,
                    Price = product.price,
                    Quantity = product.quantity,
                    Category_name = product.category_name,
                    Brand = product.brand,
                    Sale = sale
                }
            );
            }
            return products;
        }
        

        public List<ProductDTO> convertListDTO(List<Product> productList) {
            List<ProductDTO> products = new List<ProductDTO>();
            foreach (var product in productList)
            {
                products.Add(new ProductDTO {
                    ProductId = product.product_id,
                    Name= product.product_name,
                    Price= product.price,
                    Quantity= product.quantity,
                    Category_name = product.Category.category_name,
                });
            }
            return products;
        }
        
    }
}
