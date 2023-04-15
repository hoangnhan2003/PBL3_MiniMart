using ManageMiniMart.BLL;
using ManageMiniMart.Custom;
using ManageMiniMart.DAL;
using ManageMiniMart.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageMiniMart
{
    public partial class Addproduct : Form
    {
        public ReloadFormProduct formProduct;
        private CategoryService categoryService;
        private DiscountService discountService;
        private ProductService productService;
        private ProductDiscountService productDiscountService;
        private int discountBefore;
        public Addproduct(ReloadFormProduct formProduct)
        {
            InitializeComponent();
            categoryService = new CategoryService();
            discountService = new DiscountService();
            productService = new ProductService();
            cbbCategory.DataSource = categoryService.getAllCatogory();
            cbbDiscount.DataSource = discountService.GetAllDiscounts();
            productDiscountService = new ProductDiscountService();
            this.formProduct = formProduct;
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
            txtPrice.Text = product.price.ToString();
            string discountName = "";
            foreach(var discount in product.Product_Discount)
            {
                discountName += discount.Discount.discount_name;
            }
            cbbDiscount.Text = discountName;
            discountBefore = ((CBBItem)cbbDiscount.SelectedItem).Value;
            
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string productId = txtProductId.Text;
            int discount_id = ((CBBItem)cbbDiscount.SelectedItem).Value;
            if (discount_id > 0 && productId=="")
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
                productService.Save(product1);
                Product_Discount product_Discount = new Product_Discount
                {
                    product_id = product1.product_id,
                    discount_id = discount_id,
                };
                
                int idDiscount = discount.discount_id;
                
                productDiscountService.save(product_Discount);
                
                
            }
            else if(discount_id > 0 && productId != "")
            {
                Product product2 = new Product
                {
                    product_id = Convert.ToInt32(productId),
                    product_name = txtProductName.Text,
                    price = Convert.ToDouble(txtPrice.Text),
                    brand = txtBrand.Text,
                    quantity = Convert.ToInt16(txtQuantity.Text),
                    category_id = ((CBBItem)cbbCategory.SelectedItem).Value,

                };
                productService.Save(product2);
                Product_Discount product_Discount1 = productDiscountService.findByProductIdAndDiscountId(product2.product_id, discountBefore);
                productDiscountService.remove(product_Discount1);
                Product_Discount product_Discount = new Product_Discount
                {
                    product_id = product2.product_id,
                    discount_id = discount_id,
                };
                productDiscountService.save(product_Discount);
            }
            else if(discount_id == 0 && productId != "")
            {
                Product product = new Product
                {
                    product_id = Convert.ToInt32(productId),
                    product_name = txtProductName.Text,
                    price = Convert.ToDouble(txtPrice.Text),
                    brand = txtBrand.Text,
                    quantity = Convert.ToInt16(txtQuantity.Text),
                    category_id = ((CBBItem)cbbCategory.SelectedItem).Value,

                };
                productService.Save(product);
                Product_Discount product_Discount1 = productDiscountService.findByProductIdAndDiscountId(product.product_id, discountBefore);
                productDiscountService.remove(product_Discount1);
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
            MyMessageBox messageBox = new MyMessageBox();
            messageBox.show("Add successful");
            this.formProduct();
            Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Drag from
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int Param);
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
         );
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
