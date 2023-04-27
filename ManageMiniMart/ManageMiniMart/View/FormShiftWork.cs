﻿using ManageMiniMart.BLL;
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
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int shift_id = Convert.ToInt32(dgvShift.SelectedRows[0].Cells[0].Value.ToString());
            AddShiftWork shiftWork= new AddShiftWork();
            shiftWork.setFormAddShift(shift_id);
            shiftWork.ShowDialog();
        }
    }
}
