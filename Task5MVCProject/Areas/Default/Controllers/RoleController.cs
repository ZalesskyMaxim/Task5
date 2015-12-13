using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Web.Mvc;

namespace Task5MVCProject.Areas.Default.Controllers
{
    public class RoleController : DefaultController
    {
        public ActionResult Index()
        {
            var roles = Repository.Roles.ToList();
            return View(roles);
        }
    }
}
