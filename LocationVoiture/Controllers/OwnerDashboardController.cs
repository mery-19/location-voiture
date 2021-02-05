using LocationVoiture.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocationVoiture.Controllers
{
    [Authorize(Roles = "Owner")]
    public class OwnerDashboardController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Owner
        public ActionResult Index()
        {
            var user = db.Users.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault();
            var reservations = db.Reservations.Where(x => x.Voiture.ApplicationUser.Id == user.Id).Include(r => r.ApplicationUser).Include(r => r.Paiement).Include(r => r.Voiture);
            return View(reservations.ToList());
        }
    }
}