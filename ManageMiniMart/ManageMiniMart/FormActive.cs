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
    public partial class FormActive : Form
    {
        public FormActive()
        {
            InitializeComponent();
        }
        public void Alert(string msg,Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg,type);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Alert("Successful",Form_Alert.enmType.success);
        }
        private void btnWarning_Click(object sender, EventArgs e)
        {
            this.Alert("Warning!", Form_Alert.enmType.warning);
        }
        private void btnError_Click(object sender, EventArgs e)
        {
            this.Alert("Erorr 404!", Form_Alert.enmType.error);
        }
        private void btnInfo_Click(object sender, EventArgs e)
        {
            this.Alert("Info", Form_Alert.enmType.info);
        }
    }
}
