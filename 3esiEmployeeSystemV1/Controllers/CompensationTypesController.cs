﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _3esiEmployeeSystemV1.Models;
using _3esiEmployeeSystemV1.Models.Employee;

namespace _3esiEmployeeSystemV1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompensationTypesController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: CompensationTypes
        public ActionResult Index()
        {
            return View(db.CompensationTypes.ToList());
        }

        // GET: CompensationTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompensationType compensationType = db.CompensationTypes.Find(id);
            if (compensationType == null)
            {
                return HttpNotFound();
            }
            return View(compensationType);
        }

        // GET: CompensationTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompensationTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Abbreviation")] CompensationType compensationType)
        {
            if (ModelState.IsValid)
            {
                db.CompensationTypes.Add(compensationType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compensationType);
        }

        // GET: CompensationTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompensationType compensationType = db.CompensationTypes.Find(id);
            if (compensationType == null)
            {
                return HttpNotFound();
            }
            return View(compensationType);
        }

        // POST: CompensationTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Abbreviation")] CompensationType compensationType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compensationType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compensationType);
        }

        // GET: CompensationTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompensationType compensationType = db.CompensationTypes.Find(id);
            if (compensationType == null)
            {
                return HttpNotFound();
            }
            return View(compensationType);
        }

        // POST: CompensationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompensationType compensationType = db.CompensationTypes.Find(id);
            db.CompensationTypes.Remove(compensationType);
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
