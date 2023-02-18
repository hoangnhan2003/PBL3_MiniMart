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
        public FormLogin()
        {
            InitializeComponent();
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
            pnlLogin.Location = new Point(335, 437);
            pnl.Location = new Point(338, 5);
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            pnlRegister.Height = 5;
            pnlLogin.Location = new Point(350, 5);
            pnl.Location = new Point(0, 0);
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
    }
}
