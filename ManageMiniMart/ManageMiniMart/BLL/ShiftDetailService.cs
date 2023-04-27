﻿using ManageMiniMart.DAL;
using ManageMiniMart.DTO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.BLL
{
    public class ShiftDetailService
    {
        public Int32 shiftIdAdded;
        private Manage_MinimartEntities db;
        public ShiftDetailService()
        {
            db = new Manage_MinimartEntities();
        }
        public List<ShiftDetailView> convertToShiftView(List<Shift_detail> shift_Details)
        {
            List<ShiftDetailView> shiftDetailViews= new List<ShiftDetailView>();
            foreach(var shift in shift_Details)
            {
                string employees = "";
                foreach(var employee in shift.Shift_work)
                {
                    employees += employee.Account.Person.person_name + ", ";
                }
                shiftDetailViews.Add(new ShiftDetailView
                {
                    ShiftId = shift.shift_id,
                    StartTime= shift.start_time,
                    EndTime= shift.end_time,
                    Employees= employees
                });
            }
            return shiftDetailViews;
        }
        public Shift_detail getById(int shiftId)
        {
            return db.Shift_detail.Find(shiftId);
        }
        public List<ShiftDetailView> getAllShiftDetailsView()
        {
            return convertToShiftView(db.Shift_detail.ToList());
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
