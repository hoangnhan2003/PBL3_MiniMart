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

namespace ManageMiniMart.View
{
    public delegate void SendData(int productId,int amount);
    public partial class FormPayment : Form
    {
        private ProductService productService;
        private CustomerService customerService;
        private BillService billService;
        private List<ProductInBill> listProduct;
        public FormPayment()
        {
            InitializeComponent();
            productService = new ProductService();
            customerService = new CustomerService();
            billService = new BillService();
            listProduct = new List<ProductInBill>();
            cbbPayment.DataSource = getCBBMethodPay();

        }
        public List<string> getCBBMethodPay()
        {
            List<string> strings = new List<string>();
            strings.Add("Cash");
            strings.Add("Bank account");
            return strings;
        }
        private bool checkProduct(int productId)
        {
            bool check = false;
            foreach(var product in listProduct)
            {
                if(product.ProductId == productId)
                {
                    check = true; break;
                }
            }
            return check;
        }
        private void updateProduct(ProductInBill product)
        {
            for(int i = 0; i < listProduct.Count; i++)
            {
               
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            //if(txtInvoiceCode.Text.Trim() == "" || txtCustomerCode.Text.Trim() == "" 
            //    || txtAmountProduct.Text.Trim() == "")
            //{
            //    Form_Alert alert= new Form_Alert();
            //    alert.showAlert("Field is not blank!", Form_Alert.enmType.warning);
            //}
        }
        public void loadProductInBill()
        {
            dgvProduct.DataSource = null;
            dgvProduct.DataSource = this.listProduct;
            dgvProduct.Refresh();
        }
        private void txtAmountProduct_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddProductInBill(object sender, EventArgs e)
        {

        }
        private void AddProductInBill(int productId,int amount)
        {
            Product product = productService.findById(productId);
            string sale = "";
            foreach (var discount in product.Product_Discount)
            {
                sale += discount.Discount.discount_name;
            }
            listProduct.Add(new ProductInBill
            {
                ProductId = productId,
                Name = product.product_name,
                Brand = product.brand,
                Price = product.price,
                Quantity = product.quantity,
                Amount = amount,
                Category_name = product.Category.category_name,
                Sale = sale

            });
            loadProductInBill();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string productName = txtProductId.Text;
            SelectProductForm selectProductForm = new SelectProductForm(AddProductInBill);
            selectProductForm.loadAllProducts(productName);
            selectProductForm.ShowDialog();
        }
    }
}
