using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocationVoiture.Controllers
{
    [Authorize(Roles = "Owner")]

    public class OwnerDashboardController : BaseController
    {
        // GET: Owner
        public ActionResult Index()
        {
            return View();
        }
    }
}