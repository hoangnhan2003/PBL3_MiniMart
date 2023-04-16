using ManageMiniMart.BLL;
using ManageMiniMart.Custom;
using Register_Login;
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
    public partial class EmployeeForm : Form
    {
        private EmployeeService employeeService;
        private UserService userService;
        public EmployeeForm()
        {
            InitializeComponent();
            employeeService= new EmployeeService();
            userService= new UserService();
            loadAllEmployee();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
            addEmployeeForm.ShowDialog();
            loadAllEmployee();
        }
        public void loadAllEmployee()
        {
            dgvEmloyee.DataSource = null;
            dgvEmloyee.DataSource = employeeService.GetAll();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string personId = dgvEmloyee.SelectedRows[0].Cells[0].Value.ToString();
            if (userService.checkUserExits(personId))
            {
                MyMessageBox myMessage = new MyMessageBox();
                myMessage.show("Employee already have account");
               
            }
            else
            {
                FormLogin formLogin = new FormLogin(true);
                formLogin.setInfoRegister(personId);
               
            }
        }
    }
}
