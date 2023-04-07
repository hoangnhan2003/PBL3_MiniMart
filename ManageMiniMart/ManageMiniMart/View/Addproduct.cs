﻿using ManageMiniMart.BLL;
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
        public Addproduct()
        {
            InitializeComponent();
            categoryService= new CategoryService();
            discountService= new DiscountService();
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
    }
}
