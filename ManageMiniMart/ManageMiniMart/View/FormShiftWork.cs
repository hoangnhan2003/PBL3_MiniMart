using ManageMiniMart.BLL;
using ManageMiniMart.Custom;
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
        
        private ShiftDetailService shiftDetailService;
        public FormShiftWork()
        {
            InitializeComponent();
            shiftDetailService = new ShiftDetailService();
            showAllShift();
        }
        public void showAllShift()
        {
            dgvShift.DataSource= null;
            dgvShift.DataSource = shiftDetailService.getAllShiftDetailsView();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddShiftWork addShiftWork = new AddShiftWork();
            addShiftWork.ShowDialog();
            showAllShift();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int shift_id = Convert.ToInt32(dgvShift.SelectedRows[0].Cells[0].Value.ToString());
            AddShiftWork shiftWork= new AddShiftWork(1);
            shiftWork.setFormAddShift(shift_id);
            shiftWork.ShowDialog();
            showAllShift();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MyMessageBox myMessage = new MyMessageBox();
            DialogResult rs = myMessage.show("Are you sure about that", "Confirm delete", MyMessageBox.TypeMessage.YESNO, MyMessageBox.TypeIcon.WARNING);
            if (rs == DialogResult.Yes)
            {
                foreach (DataGridViewRow o in dgvShift.SelectedRows)
                {
                    int shiftid = Convert.ToInt32(o.Cells[0].Value.ToString());
                    shiftDetailService.remove(shiftid);
                }
            }
            showAllShift();   
        }
    }
}
