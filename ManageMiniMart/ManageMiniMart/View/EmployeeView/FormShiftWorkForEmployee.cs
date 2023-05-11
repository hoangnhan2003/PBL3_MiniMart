using ManageMiniMart.BLL;
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
    public partial class FormShiftWorkForEmployee : Form
    {
        private ShiftDetailService shiftDetailService;
        public FormShiftWorkForEmployee()
        {
            InitializeComponent();
            shiftDetailService = new ShiftDetailService();
            showAllShift();
        }
        public void showAllShift()
        {
            dgvShift.DataSource = null;
            dgvShift.DataSource = shiftDetailService.getAllShiftDetailsView();
        }

        
    }
}
