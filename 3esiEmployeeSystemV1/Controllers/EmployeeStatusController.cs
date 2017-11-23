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
    public class EmployeeStatusController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: EmployeeStatus
        public ActionResult Index()
        {
            return View(db.EmployeeStatus.ToList());
        }

        // GET: EmployeeStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeStatus employeeStatus = db.EmployeeStatus.Find(id);
            if (employeeStatus == null)
            {
                return HttpNotFound();
            }
            return View(employeeStatus);
        }

        // GET: EmployeeStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Abbreviation")] EmployeeStatus employeeStatus)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeStatus.Add(employeeStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeStatus);
        }

        // GET: EmployeeStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeStatus employeeStatus = db.EmployeeStatus.Find(id);
            if (employeeStatus == null)
            {
                return HttpNotFound();
            }
            return View(employeeStatus);
        }

        // POST: EmployeeStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Abbreviation")] EmployeeStatus employeeStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeStatus);
        }

        // GET: EmployeeStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeStatus employeeStatus = db.EmployeeStatus.Find(id);
            if (employeeStatus == null)
            {
                return HttpNotFound();
            }
            return View(employeeStatus);
        }

        // POST: EmployeeStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeStatus employeeStatus = db.EmployeeStatus.Find(id);
            db.EmployeeStatus.Remove(employeeStatus);
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
