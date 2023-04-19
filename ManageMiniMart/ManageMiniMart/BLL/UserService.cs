using ManageMiniMart.DAL;
using ManageMiniMart.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.BLL
{

    public class UserService
    {
        private Manage_MinimartEntities db;
        public UserService() {
            db = new Manage_MinimartEntities();
        }
        public bool checkUserExits(string employeeId)
        {

            bool check = false;
            var account = db.Accounts.Where(p => p.person_id == employeeId).FirstOrDefault();
            if (account != null) {
                check= true;
            }
            return check;
        }
        public void SaveAccount(Account account)
        {
            db.Accounts.AddOrUpdate(account);
            db.SaveChanges();
        }
        public Account checkUser(string username, string password)
        {
            return db.Accounts.Where(user => user.person_id.Equals(username) && user.password.Equals(password)).FirstOrDefault();
        }
        public int getRole(Account account)
        {
            return account.Role.role_id;
        }
        public Account getAccountByPersonId(string personId)
        {
            return db.Accounts.Where(p => p.person_id == personId).FirstOrDefault();
        }
        
    }
}
