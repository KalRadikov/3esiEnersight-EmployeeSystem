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
    public class Status1Controller : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: Status1
        public ActionResult Index()
        {
            var status = db.Status
                .Include(s => s.Employee)
                .Include(s => s.EmployeeStatus)
                .Include(s => s.EmployeeType)
                .Include(s => s.HeritageCompany)
                .Include(s => s.LegalCompany)
                .Include(s => s.OverTimeStatus)
                .Include(s => s.UnionStatus)
                .GroupBy(x => x.EmployeeID).Select(y => y.OrderByDescending(i => i.StatusID).FirstOrDefault());
            return View(status.ToList());
        }

        // GET: Status1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = db.Status.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // GET: Status1/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName");
            ViewBag.EmployeeStatusID = new SelectList(db.EmployeeStatus, "ID", "Name");
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "ID", "Name");
            ViewBag.HeritageCompanyID = new SelectList(db.HeritageCompanies, "ID", "Name");
            ViewBag.LegalCompanyID = new SelectList(db.LegalCompanies, "ID", "Name");
            ViewBag.OverTimeStatusID = new SelectList(db.OverTimeStatus, "ID", "Name");
            ViewBag.UnionStatusID = new SelectList(db.UnionStatus, "ID", "Name");
            return View();
        }

        // POST: Status1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusID,EmployeeID,EffectiveDate,EndDate,HeritageCompanyID,LegalCompanyID,EmployeeStatusID,EmployeeTypeID,PercentFullTime,OverTimeStatusID,UnionStatusID,PayRollNumber")] Status status)
        {
            if (ModelState.IsValid)
            {
                db.Status.Add(status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", status.EmployeeID);
            ViewBag.EmployeeStatusID = new SelectList(db.EmployeeStatus, "ID", "Name", status.EmployeeStatusID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "ID", "Name", status.EmployeeTypeID);
            ViewBag.HeritageCompanyID = new SelectList(db.HeritageCompanies, "ID", "Name", status.HeritageCompanyID);
            ViewBag.LegalCompanyID = new SelectList(db.LegalCompanies, "ID", "Name", status.LegalCompanyID);
            ViewBag.OverTimeStatusID = new SelectList(db.OverTimeStatus, "ID", "Name", status.OverTimeStatusID);
            ViewBag.UnionStatusID = new SelectList(db.UnionStatus, "ID", "Name", status.UnionStatusID);
            return View(status);
        }

        // GET: Status1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = db.Status.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", status.EmployeeID);
            ViewBag.EmployeeStatusID = new SelectList(db.EmployeeStatus, "ID", "Name", status.EmployeeStatusID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "ID", "Name", status.EmployeeTypeID);
            ViewBag.HeritageCompanyID = new SelectList(db.HeritageCompanies, "ID", "Name", status.HeritageCompanyID);
            ViewBag.LegalCompanyID = new SelectList(db.LegalCompanies, "ID", "Name", status.LegalCompanyID);
            ViewBag.OverTimeStatusID = new SelectList(db.OverTimeStatus, "ID", "Name", status.OverTimeStatusID);
            ViewBag.UnionStatusID = new SelectList(db.UnionStatus, "ID", "Name", status.UnionStatusID);
            return View(status);
        }

        // POST: Status1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusID,EmployeeID,EffectiveDate,EndDate,HeritageCompanyID,LegalCompanyID,EmployeeStatusID,EmployeeTypeID,PercentFullTime,OverTimeStatusID,UnionStatusID,PayRollNumber")] Status status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", status.EmployeeID);
            ViewBag.EmployeeStatusID = new SelectList(db.EmployeeStatus, "ID", "Name", status.EmployeeStatusID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "ID", "Name", status.EmployeeTypeID);
            ViewBag.HeritageCompanyID = new SelectList(db.HeritageCompanies, "ID", "Name", status.HeritageCompanyID);
            ViewBag.LegalCompanyID = new SelectList(db.LegalCompanies, "ID", "Name", status.LegalCompanyID);
            ViewBag.OverTimeStatusID = new SelectList(db.OverTimeStatus, "ID", "Name", status.OverTimeStatusID);
            ViewBag.UnionStatusID = new SelectList(db.UnionStatus, "ID", "Name", status.UnionStatusID);
            return View(status);
        }

        // GET: Status1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = db.Status.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // POST: Status1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Status status = db.Status.Find(id);
            db.Status.Remove(status);
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
