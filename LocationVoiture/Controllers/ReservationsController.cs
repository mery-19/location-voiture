﻿using System;
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
    public class ReservationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reservations
        public ActionResult Index()
        {
            var user = db.Users.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault();
            var reservations = db.Reservations.Where(x => x.UserId == user.Id).Include(r => r.ApplicationUser).Include(r => r.Paiement).Include(r => r.Voiture);
            return View(reservations.ToList());
        }

        // GET: Reservations for the owner
        [Authorize(Roles = "Owner")]
        public ActionResult Orders()
        {
            var user = db.Users.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault();
            var reservations = db.Reservations.Where(x => x.Voiture.ApplicationUser.Id == user.Id).Include(r => r.ApplicationUser).Include(r => r.Paiement).Include(r => r.Voiture);
            return View(reservations.ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create(int? id)
        {
            if (id != null) {
                var car = db.Voitures.Where(x => x.id_voiture == id).FirstOrDefault();
                ViewBag.voiture = car;
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserType");
            ViewBag.id_paiement = new SelectList(db.Paiements, "id_paiement", "libele");
            ViewBag.id_voiture = new SelectList(db.Voitures, "matricul", "matricul");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(x => x.UserName.Equals(User.Identity.Name)).FirstOrDefault();

                reservation.UserId = user.Id;
                reservation.date_ajout = DateTime.Now;
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "UserType", reservation.UserId);
            ViewBag.id_paiement = new SelectList(db.Paiements, "id_paiement", "libele", reservation.id_paiement);
            ViewBag.id_voiture = new SelectList(db.Voitures, "id_voiture", "matricul", reservation.id_voiture);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserType", reservation.UserId);
            ViewBag.id_paiement = new SelectList(db.Paiements, "id_paiement", "libele", reservation.id_paiement);
            ViewBag.id_voiture = new SelectList(db.Voitures, "id_voiture", "matricul", reservation.id_voiture);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_reservation,UserId,id_voiture,id_paiement,date_prise_en_charge,date_retour,lieu_prise_en_charge,remarque,date_ajout")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserType", reservation.UserId);
            ViewBag.id_paiement = new SelectList(db.Paiements, "id_paiement", "libele", reservation.id_paiement);
            ViewBag.id_voiture = new SelectList(db.Voitures, "id_voiture", "matricul", reservation.id_voiture);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
