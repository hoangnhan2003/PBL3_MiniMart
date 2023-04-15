﻿using ManageMiniMart.BLL;
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
    public partial class FormAddDiscount : Form
    {
        private DiscountService discountService;
        public FormAddDiscount()
        {
            InitializeComponent();
            discountService= new DiscountService();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string discountName = txtDiscountName.Text;
            DateTime startTime = dtpStartTime.Value.ToUniversalTime();
            DateTime endTime = dtpEndTime.Value.ToUniversalTime();
            int sale = Convert.ToInt32(txtSale.Text);
            Discount discount= new Discount { 
                discount_name= discountName,
                start_time= startTime,
                end_time= endTime,
                sale= sale
            };
            discountService.save(discount);
            MyMessageBox messageBox = new MyMessageBox();
            messageBox.show("Add discount successful!!");
            Dispose();


        }
    }
}