using ManageMiniMart.BLL;
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

namespace ManageMiniMart.View
{
    public partial class DetailBillForm : Form
    {
        private Bill_ProductService bill_ProductService;
        private BillService billService;
        public DetailBillForm()
        {
            InitializeComponent();
            bill_ProductService = new Bill_ProductService();
            billService = new BillService();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();

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

        //private void dgvDetailBill_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    string serial = (e.RowIndex + 1).ToString();
        //    DataGridViewCell serialCell = dgvDetailBill.Rows[e.RowIndex].Cells["no"];
        //    serialCell.Value = serial;
        //}
        //public void setDatagridView(int billId)
        //{
        //    Bill bill = billService.getById(billId);
        //    lblStaff.Text = bill.Person.person_name;
        //    lblBillDate.Text = bill.created_time.ToString();
        //    if (bill.Customer != null)
        //    {
        //        lblCustomer.Text = bill.Customer.customer_name;
        //    }

        //    List<Bill_Product> getAllProductInBill = bill_ProductService.GetBill_ProductByBillId(billId);
        //    List<BillDetails> billDetails = new List<BillDetails>();

        //    foreach (Bill_Product bill_Product in getAllProductInBill)
        //    {

        //        BillDetails details = new BillDetails
        //        {
        //            ProductName = bill_Product.Product.product_name,
        //            Quantity = bill_Product.quantity,
        //            Price = bill_Product.price,
        //            TotalPrice = bill_Product.price * bill_Product.quantity

        //        };
        //        billDetails.Add(details);

        //    }
        //    BillDetails total = new BillDetails
        //    {
        //        ProductName = "Total",
        //        TotalPrice = billService.getTotalByBill(billId)

        //    };
        //    billDetails.Add(total);
        //    dgvDetailBill.DataSource = billDetails;
        //}
        public void setDatagridView(int billId)
        {
            Bill bill = billService.getById(billId);
            lblStaff.Text = bill.Person.person_name;
            lblBillDate.Text = bill.created_time.ToString();
            if (bill.Customer != null)
            {
                lblCustomer.Text = bill.Customer.customer_name;
            }

            List<Bill_Product> getAllProductInBill = bill_ProductService.GetBill_ProductByBillId(billId);
            List<BillDetails> billDetails = new List<BillDetails>();

            foreach (Bill_Product bill_Product in getAllProductInBill)
            {

                BillDetails details = new BillDetails
                {
                    ProductName = bill_Product.Product.product_name,
                    Quantity = bill_Product.quantity,
                    Price = bill_Product.price,
                    TotalPrice = bill_Product.price * bill_Product.quantity

                };
                billDetails.Add(details);

            }
            
            String content = "";
            content += "Product name".PadRight(50);
            content += "Price".PadLeft(15);
            content += "SL".PadLeft(4);
            content += "Money".PadLeft(20) + "\n";
            foreach(BillDetails details in billDetails)
            {
                string productName = details.ProductName.PadRight(50);
                content += productName;
                string price = details.Price.ToString().PadLeft(15);
                content += price;
                string quantity = ("x "+details.Quantity.ToString()).PadLeft(4);
                content+= quantity;
                string totalMoney = details.TotalPrice.ToString().PadLeft(20);
                content += totalMoney+"\n";
            }
            string totalLine = "ToTal".PadLeft(63);
            content+="\n" + totalLine;
            string TotalMoneyInBill = billService.getTotalByBill(billId).ToString().PadLeft(20);
            content += TotalMoneyInBill;
            lblContent.Text = content;
        }


    }
}
