using ManageMiniMart.BLL;
using ManageMiniMart.View;
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
    public partial class FormBill : Form
    {
        private BillService billService;
        public FormBill()
        {
            InitializeComponent();
            billService= new BillService();
            loadAllBill();
        }
        public void loadAllBill()
        {
            dgvBill.DataSource = null;
            dgvBill.DataSource = billService.GetAllBillView();
        }
        private void rjButton4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string customerName = txtSearch.Text;
            dgvBill.DataSource = billService.getAllBillViewByCustomerName(customerName);
        }

        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBill.Columns[e.ColumnIndex].Name == "detailBill")
            {
                //FormDetailBill formDetailBill = new FormDetailBill();
                DetailBillForm detailBillForm = new DetailBillForm();
                int billId = Convert.ToInt16(dgvBill.SelectedRows[0].Cells[0].Value.ToString());
                //formDetailBill.setDatagridView(billId);
                //formDetailBill.Show();
                detailBillForm.setDatagridView(billId);
                detailBillForm.Show();
            }
        }
    }
}
