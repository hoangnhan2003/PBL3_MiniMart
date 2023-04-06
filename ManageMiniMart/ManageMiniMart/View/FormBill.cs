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
        public FormBill()
        {
            InitializeComponent();
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            DataTable db = new DataTable();
            db.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("InvoiceCode",typeof(string)),
                new DataColumn("CustomerCode",typeof(string)),
                new DataColumn("CashierCode",typeof(string)),
                new DataColumn("CreatedDate",typeof(string)),
                
            });
            db.Rows.Add(new object[] {
                "InvoiceCode1","012431421","032512123",DateTime.Now.ToString()
            });
            db.Rows.Add(new object[] {
                "InvoiceCode2","012431421","032512123",DateTime.Now.ToString()
            });
            db.Rows.Add(new object[] {
                "InvoiceCode3","012431421","032512123",DateTime.Now.ToString()
            });
            db.Rows.Add(new object[] {
                "InvoiceCode4","012431421","032512123",DateTime.Now.ToString()
            });
            dgvBill.DataSource = db;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
