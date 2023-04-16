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
    public partial class AddEmployeeForm : Form
    {
        private EmployeeService employeeService;
        public AddEmployeeForm()
        {
            InitializeComponent();
            employeeService= new EmployeeService();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string employeeId = txtEmployeeId.Text;
            string employeeName = txtEmployeeName.Text;
            DateTime dateTimeConverter = dtpBirthdate.Value;
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            string phoneNumber = txtPhoneNumber.Text;
            double salary = Convert.ToDouble(txtSalary.Text);
            Person person = new Person
            {
                person_id = employeeId,
                person_name = employeeName,
                phone_number = phoneNumber,
                birthdate = dateTimeConverter,
                email = email,
                salary = salary,
                address = address
            };
            employeeService.SavePeople(person);
            MyMessageBox myMessage = new MyMessageBox();
            myMessage.show("Add employee successful!");
        }
    }
}
