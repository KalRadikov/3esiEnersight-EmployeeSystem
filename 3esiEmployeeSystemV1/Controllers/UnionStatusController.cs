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
    public class UnionStatusController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: UnionStatus
        public ActionResult Index()
        {
            return View(db.UnionStatus.ToList());
        }

        // GET: UnionStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnionStatus unionStatus = db.UnionStatus.Find(id);
            if (unionStatus == null)
            {
                return HttpNotFound();
            }
            return View(unionStatus);
        }

        // GET: UnionStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnionStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Abbreviation")] UnionStatus unionStatus)
        {
            if (ModelState.IsValid)
            {
                db.UnionStatus.Add(unionStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unionStatus);
        }

        // GET: UnionStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnionStatus unionStatus = db.UnionStatus.Find(id);
            if (unionStatus == null)
            {
                return HttpNotFound();
            }
            return View(unionStatus);
        }

        // POST: UnionStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Abbreviation")] UnionStatus unionStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unionStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unionStatus);
        }

        // GET: UnionStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnionStatus unionStatus = db.UnionStatus.Find(id);
            if (unionStatus == null)
            {
                return HttpNotFound();
            }
            return View(unionStatus);
        }

        // POST: UnionStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnionStatus unionStatus = db.UnionStatus.Find(id);
            db.UnionStatus.Remove(unionStatus);
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
