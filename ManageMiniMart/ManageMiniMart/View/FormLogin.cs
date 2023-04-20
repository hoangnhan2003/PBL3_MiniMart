using ManageMiniMart;
using ManageMiniMart.BLL;
using ManageMiniMart.Custom;
using ManageMiniMart.DAL;
using ManageMiniMart.View;
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

namespace Register_Login
{
    public partial class FormLogin : Form
    {
       
        private bool check;
        private UserService userService;
        private EmployeeService employeeService;
        public FormLogin(bool check = false)
        {
            InitializeComponent();
            userService = new UserService();
            this.employeeService = new EmployeeService();
            this.check = check;
            if(check)
            {
                registerForm();
            }
        }
        public void setInfoRegister(string employeeId)
        {
            Person person = employeeService.GetPersonById(employeeId);
            txtUserRegister.Text = employeeId;
            txtEmail.Text = person.email;
            
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLinkRegister_Click(object sender, EventArgs e)
        {
            pnlRegister.Height = pnl.Height;
            pnlRegister.Location = new Point(0, 3);
            pnlLogin.Location = new Point(335, 470);
            pnl.Location = new Point(338, 5);
            
        }
        
        private void registerForm()
        {
            pnlRegister.Height = pnl.Height;
            pnlRegister.Location = new Point(0, 3);
            pnlLogin.Location = new Point(335, 470);
            pnl.Location = new Point(338, 5);
        }
        private void label8_Click(object sender, EventArgs e)
        {
            pnlRegister.Height = 5;
            pnlLogin.Location = new Point(349, 5);
            pnl.Location = new Point(5, 5);
        }
        // Drag from
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int Param);

        private void pnl_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            string personId = txtUserRegister.Text;
            string password = txtSignUpPassword.Text;
            string confirm = txtConfirmPassword.Text;
            // role: 1:Nhân viên; 2:Quản lí
            int role = 1;
            if(confirm.Equals(password) && password.Length > 4)
            {
                Account account = new Account
                {
                    person_id= personId,
                    password= password,
                    role_id= role,
                };
                userService.SaveAccount(account);
                MyMessageBox myMessage = new MyMessageBox();
                myMessage.show("Add account successful");
            }
            else if(!confirm.Equals(password)) {
                //Form_Alert form_Alert = new Form_Alert();
                //form_Alert.showAlert("Confirm password wrong!", Form_Alert.enmType.error);
                MyMessageBox myMessage = new MyMessageBox();
                myMessage.show("Confirm password wrong!");

            }
            else if(password.Length < 4) {
                //Form_Alert form_Alert = new Form_Alert();
                //form_Alert.showAlert("Password should be greater 4 character", Form_Alert.enmType.error);
                MyMessageBox myMessage = new MyMessageBox();
                myMessage.show("Password should be greater 4 character");

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userId = txtUserId.Text;
            string password = txtPassword.Text;
            Account account = userService.checkUser(userId, password);
            if(account != null)
            {
                if(account.role_id == 1)
                {
                    DashboardEmployee employee = new DashboardEmployee(account);
                    employee.Show();
                }
                else
                {
                    Dashboard dashboard = new Dashboard(account);
                    dashboard.Show();
                    
                }
            }
            else
            {
                MyMessageBox messageBox = new MyMessageBox();
                messageBox.show("User id or password wrong! ");
            }
            
        }

        private void txtPassword_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter )
            {
                btnLogin_Click(sender, e);
                txtPassword.Text = "";
                txtPassword.Focus();
            }
            
        }
    }
}
