using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocationVoiture.Controllers
{
    [Authorize(Roles = "Tenant")]
    public class TenantDashboardController : BaseController
    {
        // GET: Tenant
        public ActionResult Index()
        {
            return View();
        }
    }
}