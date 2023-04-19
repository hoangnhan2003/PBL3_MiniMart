using ManageMiniMart.DAL;
using ManageMiniMart.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ManageMiniMart.BLL
{
    
    internal class ProductService
    {
        private Manage_MinimartEntities db;
        public ProductService() { 
            db = new Manage_MinimartEntities();
        }
        public List<ProductDTO> getAllProduct()
        {
            List<ProductDTO> products = new List<ProductDTO>();
            var l = db.Products.ToList();
            products = convertListDTO(l);
            return products;
        }
        

        public List<ProductDTO> convertListDTO(List<Product> productList) {
            List<ProductDTO> products = new List<ProductDTO>();
            foreach (var product in productList)
            {
                string sale = "";
                foreach(var discount in product.Product_Discount)
                {
                    sale += discount.Discount.discount_name + " ";
                }

                products.Add(new ProductDTO
                {
                    ProductId = product.product_id,
                    Name = product.product_name,
                    Price = product.price,
                    Quantity = product.quantity,
                    Category_name = product.Category.category_name,
                    Brand = product.brand,
                    Sale = sale
                }) ;
            }
            return products;
        }
        public List<CBBItem> getAllCBB()
        {
            List<CBBItem> products = new List<CBBItem>();
            var c = db.Products.ToList();
            foreach(Product product in c)
            {
                products.Add(new CBBItem
                {
                    Value = product.product_id,
                    Text = product.product_name,
                });
            }
            return products;
        }
        public void insertProduct(Product product)
        {
            using (Manage_MinimartEntities d = db)
            {
                d.Products.Add(product);
                d.SaveChanges();
            }
        }
        public void deleteProduct(int id)
        {
            var productDiscount = db.Product_Discount.Where(p => p.product_id == id).ToList();
            db.Product_Discount.RemoveRange(productDiscount);
            var product = db.Products.Where(p => p.product_id.Equals(id)).ToList();
            db.Products.RemoveRange(product);
            db.SaveChanges();
        }
        public void deleteProductById(int productId)
        {
            
        }
        public void Save(Product product) {
            db.Products.AddOrUpdate(product);
            db.SaveChanges();
        }
        public List<ProductDTO> findByCategoryId(int categoryId)
        {
            List<ProductDTO> products = new List<ProductDTO>();
            var s = db.Products.Where(p => p.category_id == categoryId).ToList();
            products = convertListDTO(s);
            return products;
        }
        public List<ProductDTO> findByName(string name ) {
            List<ProductDTO> products = new List<ProductDTO>();
            var s = db.Products.Where(p => p.product_name.Contains(name)).ToList();
            products = convertListDTO(s);
            return products;
        }
        public List<ProductDTO> findByProductNameAndCategory(int category_id , string productName)
        {
            List<ProductDTO> products = new List<ProductDTO>();
            var s = db.Products.Where(p => p.product_name.Contains(productName) && p.category_id == category_id).ToList();
            products = convertListDTO(s);
            return products;
        }
        public ProductDTO convertProductDTO(Product product)
        {
            string sale = "";
            foreach(var discount in product.Product_Discount)
            {
                sale += discount.Discount.discount_name + " ";
            }
            return new ProductDTO
            {
                ProductId = product.product_id,
                Name = product.product_name,
                Price = product.price,
                Quantity = product.quantity,
                Category_name = product.Category.category_name,
                Brand = product.brand,
                Sale = sale
            };
        }
        public Product findById(int id)
        {
            Product product = db.Products.Where(p => p.product_id == id).FirstOrDefault();
            return product;
        }
        public Product findByName(string name,string brand,double price)
        {
            return db.Products.Where(p => p.product_name.Equals(name) && p.brand.Equals(brand) && p.price == price).FirstOrDefault();
        }
         
    }
}
