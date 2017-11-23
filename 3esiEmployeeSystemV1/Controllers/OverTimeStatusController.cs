using System;
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
    public class OverTimeStatusController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: OverTimeStatus
        public ActionResult Index()
        {
            return View(db.OverTimeStatus.ToList());
        }

        // GET: OverTimeStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverTimeStatus overTimeStatus = db.OverTimeStatus.Find(id);
            if (overTimeStatus == null)
            {
                return HttpNotFound();
            }
            return View(overTimeStatus);
        }

        // GET: OverTimeStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OverTimeStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Abbreviation")] OverTimeStatus overTimeStatus)
        {
            if (ModelState.IsValid)
            {
                db.OverTimeStatus.Add(overTimeStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(overTimeStatus);
        }

        // GET: OverTimeStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverTimeStatus overTimeStatus = db.OverTimeStatus.Find(id);
            if (overTimeStatus == null)
            {
                return HttpNotFound();
            }
            return View(overTimeStatus);
        }

        // POST: OverTimeStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Abbreviation")] OverTimeStatus overTimeStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(overTimeStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(overTimeStatus);
        }

        // GET: OverTimeStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverTimeStatus overTimeStatus = db.OverTimeStatus.Find(id);
            if (overTimeStatus == null)
            {
                return HttpNotFound();
            }
            return View(overTimeStatus);
        }

        // POST: OverTimeStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OverTimeStatus overTimeStatus = db.OverTimeStatus.Find(id);
            db.OverTimeStatus.Remove(overTimeStatus);
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
