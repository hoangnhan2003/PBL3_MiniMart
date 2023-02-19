using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageMiniMart
{
    public partial class FormProduct : Form
    {
        private Form currentChildForm;
        public FormProduct()
        {
            InitializeComponent();
        }
        public void OpenChildForm(Form form) { 
            if(currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm= form;
            form.FormBorderStyle= FormBorderStyle.None;
            form.TopLevel = false;
            panelChildFormProduct.Controls.Add(form);
            panelChildFormProduct.Tag= form;
            form.BringToFront();
            form.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Addproduct());
        }
    }
}
