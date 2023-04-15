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
    public partial class FormCustomerView : Form
    {
        private CustomerService customerService;
        public FormCustomerView()
        {
            InitializeComponent();
            customerService = new CustomerService();
            loadALlCusstomer();
        }
        public void loadALlCusstomer()
        {
            dgvCustomer.DataSource = null;
            dgvCustomer.DataSource = customerService.GetCustomers();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            addCustomerForm.ShowDialog();
            loadALlCusstomer();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string personId = dgvCustomer.SelectedRows[0].Cells[0].Value.ToString();
            AddCustomerForm addCustomerForm = new AddCustomerForm();
            addCustomerForm.setEditForm(personId);
            addCustomerForm.ShowDialog();
            loadALlCusstomer();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string customerName = txtSearch.Text;
            dgvCustomer.DataSource = customerService.findByName(customerName);
        }
    }
}
