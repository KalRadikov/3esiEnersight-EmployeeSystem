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
    public class HeritageCompaniesController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: HeritageCompanies
        public ActionResult Index()
        {
            return View(db.HeritageCompanies.ToList());
        }

        // GET: HeritageCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeritageCompany heritageCompany = db.HeritageCompanies.Find(id);
            if (heritageCompany == null)
            {
                return HttpNotFound();
            }
            return View(heritageCompany);
        }

        // GET: HeritageCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeritageCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Abbreviation")] HeritageCompany heritageCompany)
        {
            if (ModelState.IsValid)
            {
                db.HeritageCompanies.Add(heritageCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heritageCompany);
        }

        // GET: HeritageCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeritageCompany heritageCompany = db.HeritageCompanies.Find(id);
            if (heritageCompany == null)
            {
                return HttpNotFound();
            }
            return View(heritageCompany);
        }

        // POST: HeritageCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Abbreviation")] HeritageCompany heritageCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heritageCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heritageCompany);
        }

        // GET: HeritageCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeritageCompany heritageCompany = db.HeritageCompanies.Find(id);
            if (heritageCompany == null)
            {
                return HttpNotFound();
            }
            return View(heritageCompany);
        }

        // POST: HeritageCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HeritageCompany heritageCompany = db.HeritageCompanies.Find(id);
            db.HeritageCompanies.Remove(heritageCompany);
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
