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
    public class LegalCompaniesController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: LegalCompanies
        public ActionResult Index()
        {
            return View(db.LegalCompanies.ToList());
        }

        // GET: LegalCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LegalCompany legalCompany = db.LegalCompanies.Find(id);
            if (legalCompany == null)
            {
                return HttpNotFound();
            }
            return View(legalCompany);
        }

        // GET: LegalCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LegalCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Abbreviation")] LegalCompany legalCompany)
        {
            if (ModelState.IsValid)
            {
                db.LegalCompanies.Add(legalCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(legalCompany);
        }

        // GET: LegalCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LegalCompany legalCompany = db.LegalCompanies.Find(id);
            if (legalCompany == null)
            {
                return HttpNotFound();
            }
            return View(legalCompany);
        }

        // POST: LegalCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Abbreviation")] LegalCompany legalCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(legalCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(legalCompany);
        }

        // GET: LegalCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LegalCompany legalCompany = db.LegalCompanies.Find(id);
            if (legalCompany == null)
            {
                return HttpNotFound();
            }
            return View(legalCompany);
        }

        // POST: LegalCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LegalCompany legalCompany = db.LegalCompanies.Find(id);
            db.LegalCompanies.Remove(legalCompany);
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
