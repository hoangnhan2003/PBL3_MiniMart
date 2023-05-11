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
    public partial class InfomationForm : Form
    {
        private string userId;
        private EmployeeService employeeService;
        public InfomationForm()
        {
            InitializeComponent();
            employeeService= new EmployeeService();
        }
        public void setInfoForm(string personId)
        {
            userId= personId;
            Person person = employeeService.GetPersonById(personId);
            txtEmployeeName.Text = person.person_name;
            txtAddress.Text = person.address;
            txtPhoneNumber.Text = person.phone_number;
            txtEmail.Text = person.email;
            dtpBirthdate.Value = person.birthdate.Value;
            txtSalary.Text = person.salary.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            string personName = txtEmployeeName.Text;
            string address = txtAddress.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string email = txtEmail.Text;
            DateTime birthdate = dtpBirthdate.Value;
            double salary = Convert.ToDouble(txtSalary.Text);
            Person person = new Person
            {
                person_id = userId,
                person_name = personName,
                address = address,
                phone_number = phoneNumber,
                email = email,
                birthdate = birthdate,
                salary = salary
            };
            try
            {
                employeeService.SavePeople(person);
                MyMessageBox myMessage = new MyMessageBox();
                myMessage.show("Update infomation success ^^");
            }
            catch (Exception ex)
            {
                MyMessageBox messageBox= new MyMessageBox();
                messageBox.show("Infomation invalid!");
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePassword = new ChangePasswordForm();
            changePassword.setUserID(userId);
            changePassword.Show();
        }
    }
}
