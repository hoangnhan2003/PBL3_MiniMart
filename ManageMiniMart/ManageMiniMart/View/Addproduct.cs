using ManageMiniMart.BLL;
using ManageMiniMart.DAL;
using ManageMiniMart.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageMiniMart
{
    public partial class Addproduct : Form
    {
        private CategoryService categoryService;
        private DiscountService discountService;
        private ProductService productService;
        public Addproduct()
        {
            InitializeComponent();
            categoryService= new CategoryService();
            discountService= new DiscountService();
            productService= new ProductService();
            cbbCategory.DataSource= categoryService.getAllCatogory();
            cbbDiscount.DataSource= discountService.GetAllDiscounts();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void editProduct(Product product)
        {
            txtProductId.Text = product.product_id.ToString();
            txtProductName.Text = product.product_name.ToString();
            txtBrand.Text = product.brand.ToString();
            txtQuantity.Text = product.quantity.ToString();
            cbbCategory.Text = product.Category.category_name;
            
        }

        private void btnMaximun_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            int discount_id = ((CBBItem)cbbDiscount.SelectedItem).Value;
            if (discount_id > 0)
            {
                Discount discount = discountService.getById(discount_id);
                List<Discount> discounts = new List<Discount>();
                discounts.Add(discount);
                Product product1 = new Product
                {
                    product_name = txtProductName.Text,
                    price = Convert.ToDouble(txtPrice.Text),
                    brand = txtBrand.Text,
                    quantity = Convert.ToInt16(txtQuantity.Text),
                    category_id = ((CBBItem)cbbCategory.SelectedItem).Value,
                };
                product1.Discounts.Add(discount);
                int idDiscount = discount.discount_id;
                productService.Save(product1);
            }
            else
            {
                Product product = new Product
                {
                    product_name = txtProductName.Text,
                    price = Convert.ToDouble(txtPrice.Text),
                    brand = txtBrand.Text,
                    quantity = Convert.ToInt16(txtQuantity.Text),
                    category_id = ((CBBItem)cbbCategory.SelectedItem).Value
                };

                productService.Save(product);
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
