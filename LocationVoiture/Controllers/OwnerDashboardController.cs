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
            HistoryOwner history = new HistoryOwner();
            var user = db.Users.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault();
            history.reservations = db.Reservations.Where(x => x.Voiture.ApplicationUser.Id == user.Id).Include(r => r.ApplicationUser).Include(r => r.Paiement).Include(r => r.Voiture).ToList<Reservation>();
            history.offresDisponibles = db.Offres.Where(x => x.UserId == user.Id&&x.date_expiration>=DateTime.Now).Include(v => v.ApplicationUser).ToList<Offre>();
            history.offresExpires = db.Offres.Where(x => x.UserId == user.Id && x.date_expiration < DateTime.Now).Include(v => v.ApplicationUser).ToList<Offre>();
            return View(history);
        }
    }
}