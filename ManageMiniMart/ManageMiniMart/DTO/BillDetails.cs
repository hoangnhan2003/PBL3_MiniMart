using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageMiniMart.DTO
{
    internal class BillDetails
    {
        private String _ProductName;
        private Double _Price;
        private Int32 _Quantity;
        private Double _TotalPrice;

        public String ProductName { get => _ProductName; set => _ProductName = value; }
        public Double Price { get => _Price; set => _Price = value; }
        public Int32 Quantity { get => _Quantity; set => _Quantity = value; }
        public Double TotalPrice { get => _TotalPrice; set => _TotalPrice = value; }

        public BillDetails(String productName, Double price , Int32 quantity, Double totalPrice)
        {
            _ProductName = productName;
            _Price = price;
            _Quantity = quantity;
            _TotalPrice = totalPrice;
        }

        public BillDetails()
        {
        }

        
    }
}
