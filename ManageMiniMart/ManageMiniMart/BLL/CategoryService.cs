using ManageMiniMart.DAL;
using ManageMiniMart.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.BLL
{
    internal class CategoryService
    {
        private MinimartDatabase db;
        public CategoryService()
        {
            db = new MinimartDatabase();    
        }
        public List<CBBItem> getAllCatogory()
        {
            List<CBBItem> cBBItems= new List<CBBItem>();
            var p = db.Categories.ToList();
            foreach(var a in p)
            {
                cBBItems.Add(new CBBItem
                {
                    Text = a.category_name,
                    Value = a.category_id
                });
            }
            return cBBItems;
        }
    }
}
