using ManageMiniMart.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

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
        public List<Shift_work> getByShiftId(int shiftId)
        {
            return db.Shift_work.Where(s => s.shift_id == shiftId).ToList();
        }
        public void deleteByShiftId(int shiftId)
        {
            List<Shift_work> shift_Works = db.Shift_work.Where(s => s.shift_id == shiftId).ToList();
            db.Shift_work.RemoveRange(shift_Works);
            db.SaveChanges();
        }
        public void deleteByShiftWorkId(int shiftWorkId)
        {
            List<Shift_work> works = db.Shift_work.Where(s => s.shift_id == shiftWorkId).ToList();
            if(works.Count > 0)
            {
                db.Shift_work.RemoveRange(works);
                db.SaveChanges();
            }
            
        }
        public List<string> getAllPersonByShiftDetailId(int shiftId)
        {
            List<string> personIds = db.Shift_work.Where( s => s.shift_id==shiftId).Select( p => p.person_id).ToList();
            return personIds;
        }
    }
}
