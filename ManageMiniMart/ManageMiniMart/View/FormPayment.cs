using ManageMiniMart.BLL;
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
    public partial class FormPayment : Form
    {
        private ProductService productService;
        private CustomerService customerService;
        private BillService billService;
        private List<ProductDTO> listProduct;
        public FormPayment()
        {
            InitializeComponent();
            productService = new ProductService();
            customerService = new CustomerService();
            billService = new BillService();
            cbbPayment.DataSource = getCBBMethodPay();
            cbbCustomer.DataSource = customerService.getAllCBB();
            cbbProduct.DataSource = productService.getAllCBB();
            
        }
        public List<string> getCBBMethodPay()
        {
            List<string> strings = new List<string>();
            strings.Add("Cash");
            strings.Add("Bank account");
            return strings;
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

        private void txtAmountProduct_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
