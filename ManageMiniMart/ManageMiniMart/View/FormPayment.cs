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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageMiniMart.View
{
    public delegate void SendData(int productId,int amount);
    public delegate void CustomerDelegate(string customerId);
    public partial class FormPayment : Form
    {
        private ProductService productService;
        private DiscountService discountService;
        private CustomerService customerService;
        private BillService billService;
        private Bill_ProductService bill_ProductService;
        private List<ProductInBill> listProduct;
        private Account currentAccount;
        public FormPayment(Account account = null)
        {
            InitializeComponent();
            productService = new ProductService();
            customerService = new CustomerService();
            billService = new BillService();
            discountService= new DiscountService();
            listProduct = new List<ProductInBill>();
            bill_ProductService = new Bill_ProductService();
            cbbPayment.DataSource = getCBBMethodPay();
            this.currentAccount = account;
            if(currentAccount != null )
            {
                setEmployeeLbl();
            }
        }
        public void setEmployeeLbl()
        {
            lblEmployeeID.Text = currentAccount.person_id.ToString();
            lblEmployeeName.Text = currentAccount.Person.person_name;
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
                if (listProduct[i].ProductId == product.ProductId)
                {
                    listProduct[i] = product;
                }
            }
        }
        private ProductInBill findProductInBillById(int productId)
        {
            foreach( var product in listProduct)
            {
                if(product.ProductId == productId)
                {
                    return product;
                }
            }
            return null;
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
            int discountId =0;
            foreach (var discount in product.Product_Discount)
            {
                sale += discount.Discount.discount_name;
                discountId = discount.Discount.discount_id;
            }
            if(amount > product.quantity)
            {
                MyMessageBox messageBox = new MyMessageBox();
                messageBox.show("Amount product in stock not enough for buy !","Nofitication");
            }
            else
            {
                if (checkProduct(productId))
                {
                    ProductInBill productInBill = findProductInBillById(productId);
                    productInBill.Amount += amount;
                    if(productInBill.Amount > product.quantity)
                    {
                        //MyMessageBox myMessage = new MyMessageBox();
                        //myMessage.show("Amount product in stock not enough for buy!", "Nofitication");
                        int amountProduct = productInBill.Amount;
                    }
                    else
                    {
                        updateProduct(productInBill);
                    }
                    
                }
                else
                {
                    listProduct.Add(new ProductInBill
                    {
                        ProductId = productId,
                        Name = product.product_name,
                        Brand = product.brand,
                        Price = product.price,
                        Quantity = product.quantity,
                        Amount = amount,
                        Category_name = product.Category.category_name,
                        Sale = sale,
                        DiscountId = discountId
                    });
                }
            }
            
            loadProductInBill();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string productName = txtProductId.Text;
            SelectProductForm selectProductForm = new SelectProductForm(AddProductInBill);
            selectProductForm.loadAllProducts(productName);
            selectProductForm.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MyMessageBox myMessage = new MyMessageBox();
            DialogResult rs = myMessage.show("Are you complete ?", "Confirm", MyMessageBox.TypeMessage.YESNO, MyMessageBox.TypeIcon.INFO);
            if(rs == DialogResult.Yes)
            {
                string customerId = txtCustomerId.Text;
                Customer customer = customerService.findById(customerId);
                if(customer == null)
                {
                    customerId = null;
                }
                string employeeId = lblEmployeeID.Text;
                string methodPayment = cbbPayment.Text;
                DateTime currentTime = DateTime.Now;
                double totalMoney = 0;
                Bill bill = new Bill
                {
                    person_id= employeeId,
                    customer_id= customerId,
                    payment_method= methodPayment,
                    created_time= currentTime,

                };
                billService.addBill(bill);
                int idBill = billService.IdBillAdded;
                foreach(var product in listProduct)
                {
                    Product product1 = productService.findById(product.ProductId);
                    Discount discount = discountService.getById(product.DiscountId);
                    int percentOff =  0;
                    if(discount != null)
                    {
                        percentOff = (int)discount.sale;
                    }
                    totalMoney += (product.Price * (100-percentOff)/100)*product.Amount;
                    Bill_Product bill_Product = new Bill_Product
                    {
                        bill_id = idBill,
                        product_id = product.ProductId,
                        quantity = product.Amount,
                        price = product.Price * (100 - percentOff) / 100
                    };
                    // sau khi thêm sản phẩm vào bill thì giảm số lượng hàng hóa có trong kho
                    product1.quantity = product1.quantity - product.Amount;
                    productService.Save(product1);
                    bill_ProductService.SaveBill_Product(bill_Product);
                    
                }
                if(customer != null)
                {
                    int pointOld = (int)customer.point;
                    int pointAdd = (int)(totalMoney / 20000);
                    customer.point += pointAdd;
                    customerService.save(customer);
                }
                
                MyMessageBox myMessage1 = new MyMessageBox();
                myMessage1.show("Total money = " + totalMoney);
            }
        }
        private void setCustomerId_Input(string customerId)
        {
            txtCustomerId.Text = customerId;
        }
        private void btnSearchCusomer_CLick(object sender, EventArgs e)
        {
            string customerName = txtCustomerId.Text;
            SelectCustomerForm selectCustomerForm = new SelectCustomerForm(setCustomerId_Input);
            selectCustomerForm.setCustomer(customerName);
            selectCustomerForm.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
