using ManageMiniMart.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.BLL
{
    public class ShiftDetailService
    {
        public int shiftIdAdded;
        private Manage_MinimartEntities db;
        public ShiftDetailService()
        {
            db = new Manage_MinimartEntities();
        }
        public void save(Shift_detail shift)
        {
            db.Shift_detail.Add(shift);
            db.SaveChanges();
            shiftIdAdded = shift.shift_id;
        }
        public void remove(Shift_detail shift)
        {
            db.Shift_detail.Remove(shift);
            db.SaveChanges();
        }

    }
}
