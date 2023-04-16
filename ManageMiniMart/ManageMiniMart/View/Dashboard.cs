using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;
using FontAwesome.Sharp;
using ManageMiniMart.View;
using Register_Login;

namespace ManageMiniMart
{
    public partial class Dashboard : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        public Dashboard()
        {

            InitializeComponent();
            //this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 57);
            panelMenu.Controls.Add(leftBorderBtn);
            // Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered= true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;  
        }
        //Structs
        private struct RBGColor
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color yellowCustom = Color.FromArgb(255, 212, 59);
            public static Color greenCustom = Color.FromArgb(91, 166, 65);
        }
        // Method
        private void ActiveButton(object senderBtn, Color color)
        {
            if(senderBtn != null)
            {
                DisableButton();
                // Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign= ContentAlignment.MiddleRight;
                // left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0,currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                // Icon Current ChildForm
                iconCurentChildForm.IconChar= currentBtn.IconChar;
                iconCurentChildForm.IconColor= color;
                lblTitleChildForm.Text = currentBtn.Text;
                lblTitleChildForm.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblTitleChildForm.ForeColor = color;

            }
        }
        private void DisableButton()
        {
            if(currentBtn!= null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            if(currentChildForm!= null) {
                currentChildForm.Dispose();
            }
            currentChildForm= childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle= FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag= childForm;
            childForm.BringToFront();
            childForm.Show();
            //lblTitleChildForm.Text = childForm.Text;
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RBGColor.color1);
            OpenChildForm(new FormPayment());
        }

        private void BtnProduct_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RBGColor.color2);
            OpenChildForm(new FormProduct());
            
            
            
        }

        private void BtnInvoice_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RBGColor.color3);
            OpenChildForm(new FormBill());
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RBGColor.color4);
            OpenChildForm(new FormDiscount());
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RBGColor.color5);
            OpenChildForm(new FormCustomerView());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RBGColor.color6);
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Reset();
            
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurentChildForm.IconChar = IconChar.Home;
            iconCurentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }
        // Drag from
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll",EntryPoint ="SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd,int wMsg, int wParam, int Param);
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
            SendMessage(this.Handle,0x112,0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState= FormWindowState.Minimized;
        }
        private void btnMaximun_Click(object sender,EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if(WindowState == FormWindowState.Maximized)
            {
                WindowState= FormWindowState.Normal;
            }
        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RBGColor.greenCustom);
            OpenChildForm(new EmployeeForm());
        }

        private void btnAnalyst_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RBGColor.yellowCustom);
            OpenChildForm(new FormAnalyst());
        }
    }
}
