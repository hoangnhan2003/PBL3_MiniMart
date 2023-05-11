using ManageMiniMart.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.BLL
{
    internal class AccountService
    {
        private Manage_MinimartEntities db;
        public AccountService() {
            db = new Manage_MinimartEntities();
        }
        public Account checkUser(string username,string password) {
            return db.Accounts.Where(user => user.person_id.Equals(username) && user.password.Equals(password)).FirstOrDefault();
        }
        public int getRole(Account account)
        {
            return account.Role.role_id;
        }
        public Account getByUserID(string userId)
        {
            return db.Accounts.Find(userId);
        }
        public void saveUser(Account account)
        {
            db.Accounts.AddOrUpdate(account);
            db.SaveChanges();
        }
    }
}
