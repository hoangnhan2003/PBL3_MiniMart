using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.DTO
{
    public class ShiftDetailView
    {
        private int _ShiftId;
        private DateTime _StartTime;
        private DateTime _EndTime;
        private string _Employees;

        public int ShiftId { get => _ShiftId; set => _ShiftId = value; }
        public DateTime StartTime { get => _StartTime; set => _StartTime = value; }
        public DateTime EndTime { get => _EndTime; set => _EndTime = value; }
        public string Employees { get => _Employees; set => _Employees = value; }
    }
}
