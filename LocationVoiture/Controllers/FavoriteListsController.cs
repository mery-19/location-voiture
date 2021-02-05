using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LocationVoiture.Models;

namespace LocationVoiture.Controllers
{
    public class FavoriteListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FavoriteLists
        public ActionResult Index()
        {
            var favoriteLists = db.FavoriteLists.Include(f => f.ApplicationUser);
            return View(favoriteLists.ToList());
        }

        // GET: FavoriteLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavoriteList favoriteList = db.FavoriteLists.Find(id);
            if (favoriteList == null)
            {
                return HttpNotFound();
            }
            return View(favoriteList);
        }

        // GET: FavoriteLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FavoriteLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavoriteList favoriteList = new FavoriteList();
            favoriteList.UserId = id.ToString();
            db.FavoriteLists.Add(favoriteList);
            db.SaveChanges();
            return View("~/Views/ApplicationUsers/Index.cshtml");
        }

        // GET: FavoriteLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavoriteList favoriteList = db.FavoriteLists.Find(id);
            if (favoriteList == null)
            {
                return HttpNotFound();
            }
            return View(favoriteList);
        }

        // POST: FavoriteLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_favorite,UserId")] FavoriteList favoriteList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favoriteList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(favoriteList);
        }

        // GET: FavoriteLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavoriteList favoriteList = db.FavoriteLists.Find(id);
            if (favoriteList == null)
            {
                return HttpNotFound();
            }
            return View(favoriteList);
        }

        // POST: FavoriteLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FavoriteList favoriteList = db.FavoriteLists.Find(id);
            db.FavoriteLists.Remove(favoriteList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
