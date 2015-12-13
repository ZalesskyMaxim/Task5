using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task5MVCProject.Models
{
    public class SaleInfoModel
    {
        public IEnumerable<DAL.Models.Manager> Managers { get; set; }
        public IEnumerable<DAL.Models.Product> Products { get; set; }
    }
}