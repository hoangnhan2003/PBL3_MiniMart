using ManageMiniMart.BLL;
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
    public partial class FormDiscount : Form
    {
        private DiscountService discountService;
        public FormDiscount()
        {
            InitializeComponent();
            discountService= new DiscountService();
            dgvDiscount.DataSource= discountService.GetDiscountsView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddDiscount addDiscount = new FormAddDiscount();
            addDiscount.ShowDialog();
            dgvDiscount.DataSource = discountService.GetDiscountsView();
        }
    }
}
