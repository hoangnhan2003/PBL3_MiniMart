using ManageMiniMart.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.BLL
{
    public class EmployeeService
    {
        private Manage_MinimartEntities db;
        public EmployeeService() { 
            db = new Manage_MinimartEntities();
        }
        public List<Person> GetAll()
        {
            return db.People.ToList();
        }
        public void SavePeople(Person person)
        {
            db.People.AddOrUpdate(person);
            db.SaveChanges();
        }
        // only remove employee haven't account and Bill yet
        public void DeletePeople(Person person)
        {
            db.People.Remove(person);
            db.SaveChanges();
        }
        public List<Person> GetPeopleByName(string name) {
            return db.People.Where( p => p.person_name.Contains(name)).ToList();
        }
        public Person GetPersonById(string id)
        {
            return db.People.SingleOrDefault(p => p.person_id == id);
        }
    }
}
