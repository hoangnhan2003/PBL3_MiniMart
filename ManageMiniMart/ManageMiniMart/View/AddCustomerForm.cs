using ManageMiniMart.BLL;
using ManageMiniMart.Custom;
using ManageMiniMart.DAL;
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
    public partial class AddCustomerForm : Form
    {
        private CustomerService customerService;
        public AddCustomerForm()
        {
            InitializeComponent();
            customerService= new CustomerService();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void setEditForm(string personId)
        {
            Customer customer= customerService.findById(personId);
            txtCustomerId.Text = personId;
            txtCustomerName.Text = customer.customer_name;
            txtAddress.Text = customer.address;
            txtEmail.Text = customer.email;
            dtpBirthdate.Value = customer.birthdate;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string customerId = txtCustomerId.Text;
            string customerName = txtCustomerName.Text;
            DateTime birthDate  = dtpBirthdate.Value.ToUniversalTime();
            DateTime createTime = DateTime.Now;
            int point = 0;
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            Customer customerOld = customerService.findById(customerId);
            if (customerOld == null)
            {
                Customer customer = new Customer
                {
                    customer_id = customerId,
                    customer_name = customerName,
                    birthdate = birthDate,
                    created_time = createTime,
                    address = address,
                    point = point,
                    email = email,
                };
                customerService.save(customer);
                
            }
            else
            {
                
                Customer customer = new Customer
                {
                    customer_id = customerId,
                    customer_name = customerName,
                    birthdate = birthDate,
                    created_time = customerOld.created_time,
                    address = address,
                    point = point,
                    email = email,
                };
                customerService.save(customer);
            }
            MyMessageBox myMessage = new MyMessageBox();
            myMessage.show("Add customer successful !", "Nofitication", MyMessageBox.TypeMessage.CONFIRM, MyMessageBox.TypeIcon.INFO);
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
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
