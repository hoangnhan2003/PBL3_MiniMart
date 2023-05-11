using ManageMiniMart.BLL;
using ManageMiniMart.Custom;
using ManageMiniMart.DAL;
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
    public partial class ChangePasswordForm : Form
    {
        private string userId;
        private AccountService accountService;
        public ChangePasswordForm()
        {
            InitializeComponent();
            accountService= new AccountService();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        public void setUserID(string userId)
        {
            this.userId = userId;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewpassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if(confirmPassword != newPassword)
            {
                MyMessageBox myMessage = new MyMessageBox();
                myMessage.show("Confirm password wrong!!");
                return;
            }
            Account account = accountService.getByUserID(userId);
            if(account.password == oldPassword)
            {
                account.password = newPassword;
                accountService.saveUser(account);
                MyMessageBox myMessage = new MyMessageBox();
                myMessage.show("Change password successful. ");
            }
            else
            {
                MyMessageBox myMessage = new MyMessageBox();
                myMessage.show("password wrong, try again !");
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
