using ManageMiniMart.BLL;
using ManageMiniMart.Custom;
using ManageMiniMart.DAL;
using ManageMiniMart.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageMiniMart.View
{
    public partial class AddEmployeeForm : Form
    {
        private EmployeeService employeeService;
        private UserService userService;
        private RoleService roleService;
        public AddEmployeeForm()
        {
            InitializeComponent();
            employeeService= new EmployeeService();
            userService= new UserService();
            roleService= new RoleService();
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
            Account account = userService.getAccountByPersonId(employeeId);
            if(account != null)
            {
                account.role_id = ((CBBItem)cbbRole.SelectedItem).Value;
                userService.SaveAccount(account);
            }
            
            MyMessageBox myMessage = new MyMessageBox();
            myMessage.show("Add employee successful!");
        }
        public void setEmployee(string employeeId)
        {
            cbbRole.DataSource = roleService.GetRoles();

            Person person = employeeService.GetPersonById(employeeId);
            if (person != null)
            {
                txtEmployeeId.Text = employeeId;
                txtEmployeeName.Text = person.person_name;
                txtPhoneNumber.Text = person.phone_number;
                txtAddress.Text = person.address;
                txtEmail.Text = person.email;
                txtSalary.Text = person.salary.ToString();

            }
            Account account = userService.getAccountByPersonId(employeeId); if (account != null) {
                cbbRole.Text = account.Role.role_name;
            } 
            
        }
        // Drag from
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int Param);
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
         );
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
