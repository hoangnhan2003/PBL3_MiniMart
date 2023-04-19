﻿using ManageMiniMart.BLL;
using ManageMiniMart.Custom;
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
   
    public partial class SelectCustomerForm : Form
    {
        private CustomerDelegate customerDelegate;
        private CustomerService customerService;
        public SelectCustomerForm(CustomerDelegate customerDelegate)
        {
            InitializeComponent();
            customerService = new CustomerService();
            this.customerDelegate = customerDelegate;   
        }
        public void setCustomer(string customerName)
        {
            dgvCustomer.DataSource = customerService.findByName(customerName);
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomer.Columns[e.ColumnIndex].Name == "ADD")
            {
                CustomFormInput c = new CustomFormInput();
                string personId = dgvCustomer.SelectedRows[0].Cells[0].Value.ToString();
                this.customerDelegate(personId);
            }
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
