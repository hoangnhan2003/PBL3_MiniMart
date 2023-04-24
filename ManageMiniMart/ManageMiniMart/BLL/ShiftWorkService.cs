using ManageMiniMart.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.BLL
{
    internal class ShiftWorkService
    {
        private Manage_MinimartEntities db;
        public ShiftWorkService()
        {
            db = new Manage_MinimartEntities();
        }
        public void save(Shift_work shift_Work)
        {
            db.Shift_work.Add(shift_Work);
            db.SaveChanges();
        }
    }
}
