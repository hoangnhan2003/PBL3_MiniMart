﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.DTO
{
    internal class BillView
    {
        private int _Id;
        private string _CustomerName;
        private string _EmployeeName;
        private string _CreatedTiem;
        private double _Total;

        public int Id { get => _Id; set => _Id = value; }
        public string CustomerName { get => _CustomerName; set => _CustomerName = value; }
        public string EmployeeName { get => _EmployeeName; set => _EmployeeName = value; }
        public string CreatedTiem { get => _CreatedTiem; set => _CreatedTiem = value; }
        public double Total { get => _Total; set => _Total = value; }
    }
}
