using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task5MVCProject.Models
{
    public class SaleRowModel
    {
        public string ManagerName { get; set; }
        public string Date { get; set; }
        public string ClientName { get; set; }
        public string ProductName { get; set; }
        public string ProductCost { get; set; }
    }
}