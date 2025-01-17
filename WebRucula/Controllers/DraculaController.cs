﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebRucula.Models;

namespace WebRucula.Controllers
{
    public class DraculaController : Controller
    {
        private draculaBaseEntities db = new draculaBaseEntities();

        // GET: Dracula
        public ActionResult Index()
        {
            return View(db.dracoes.ToList());
        }

        // GET: Dracula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            draco draco = db.dracoes.Find(id);
            if (draco == null)
            {
                return HttpNotFound();
            }
            return View(draco);
        }

        // GET: Dracula/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dracula/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Author,Date,Medium,Recipient")] draco draco)
        {
            if (ModelState.IsValid)
            {
                db.dracoes.Add(draco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(draco);
        }

        // GET: Dracula/Edit/5
        /*public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            draco draco = db.dracoes.Find(id);
            if (draco == null)
            {
                return HttpNotFound();
            }
            return View(draco);
        }

        // POST: Dracula/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Author,Date,Medium,Recipient")] draco draco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(draco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(draco);
        }

        // GET: Dracula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            draco draco = db.dracoes.Find(id);
            if (draco == null)
            {
                return HttpNotFound();
            }
            return View(draco);
        }

        // POST: Dracula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            draco draco = db.dracoes.Find(id);
            db.dracoes.Remove(draco);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */


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
