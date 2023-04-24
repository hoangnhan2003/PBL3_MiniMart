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
    public partial class FormShiftWork : Form
    {
        public FormShiftWork()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddShiftWork addShiftWork = new AddShiftWork();
            addShiftWork.ShowDialog();
        }
    }
}
