using ManageMiniMart.BLL;
using ManageMiniMart.Custom;
using ManageMiniMart.DAL;
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormAddDiscount addDiscount = new FormAddDiscount();
            addDiscount.setDiscount(Convert.ToInt32(dgvDiscount.SelectedRows[0].Cells[0].Value.ToString()));
            addDiscount.ShowDialog();
            dgvDiscount.DataSource = discountService.GetDiscountsView();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int discountId = Convert.ToInt32(dgvDiscount.SelectedRows[0].Cells[0].Value.ToString());
            Discount discount = discountService.getById(discountId);
            MyMessageBox myMessage = new MyMessageBox();
            DialogResult rs = myMessage.show("Are you sure delete sale: " + discount.discount_name + " ?", "Confirm"
                ,MyMessageBox.TypeMessage.YESNO,
                MyMessageBox.TypeIcon.WARNING);
            if(rs == DialogResult.Yes)
            {
                discountService.delete(discount);
            }
            dgvDiscount.DataSource = discountService.GetDiscountsView();
        }
    }
}
