using ManageMiniMart.BLL;
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
    public delegate void EmployeeDelegate (string personId);
    public partial class AddShiftWork : Form
    {
        private EmployeeService employeeService;
        private ShiftDetailService shiftDetailService;
        private List<Person> employeeList= new List<Person> ();
        public AddShiftWork()
        {
            InitializeComponent();
            employeeService = new EmployeeService();
            shiftDetailService= new ShiftDetailService();
            setCbbShift();
        }
        public void setCbbShift()
        {
            cbbShiftwork.Items.Add("Shift 1");
            cbbShiftwork.Items.Add("Shift 2");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
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
        public bool checkEmployeeExist(string personId)
        {
            bool check = false;
            foreach(Person person in employeeList)
            {
                if (person.person_id.Equals(personId))
                {
                    check = true;
                }
            }
            return check;
        }
        public void addEmployee(string personId)
        {
            Person person = employeeService.GetPersonById(personId);
            if (person != null && !checkEmployeeExist(personId)) {
                employeeList.Add(person);
            }
            else
            {

            }
        }
        public void reloadDgvEmployee()
        {
            dgvEmloyee.DataSource = null;
            dgvEmloyee.DataSource = employeeList;
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            string employeeName = txtEmployeeName.Text;
            SelectEmployeeForm selectEmployeeForm = new SelectEmployeeForm(addEmployee);
            selectEmployeeForm.setEmployeeByName(employeeName);
            selectEmployeeForm.ShowDialog();
            reloadDgvEmployee();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string date = dtpWorkDate.Value.ToString("yyyy/MM/dd");
            string startTime = "06:00:00";
            string endTime = "13:59:59";
            if(cbbShiftwork.SelectedItem.ToString() == "Shift 2")
            {
                startTime = "14:00:00";
                endTime = "21:59:59";
            }
            DateTime startTimeShift = DateTime.Parse(date +" "+ startTime);
            DateTime endTimeShift = DateTime.Parse((date + " " + endTime));
            Shift_detail shift_Detail = new Shift_detail
            {
                shift_name = "Shift in date "+ date,
                start_time= startTimeShift,
                end_time= endTimeShift
            };
            shiftDetailService.save(shift_Detail);
            int shiftId = shiftDetailService.shiftIdAdded;
            foreach(Person person in employeeList)
            {
                string personId = person.person_id;
            }
            MessageBox.Show("Start time = " + startTimeShift + "\n endTime = " + endTimeShift);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
