using ManageMiniMart.BLL;
using ManageMiniMart.Custom;
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
    }
    
}
