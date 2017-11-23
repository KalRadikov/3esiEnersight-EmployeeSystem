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
    public class BenefitTypesController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: BenefitTypes
        public ActionResult Index()
        {
            return View(db.BenefitTypes.ToList());
        }

        // GET: BenefitTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenefitType benefitType = db.BenefitTypes.Find(id);
            if (benefitType == null)
            {
                return HttpNotFound();
            }
            return View(benefitType);
        }

        // GET: BenefitTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BenefitTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Abbreviation")] BenefitType benefitType)
        {
            if (ModelState.IsValid)
            {
                db.BenefitTypes.Add(benefitType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(benefitType);
        }

        // GET: BenefitTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenefitType benefitType = db.BenefitTypes.Find(id);
            if (benefitType == null)
            {
                return HttpNotFound();
            }
            return View(benefitType);
        }

        // POST: BenefitTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Abbreviation")] BenefitType benefitType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(benefitType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(benefitType);
        }

        // GET: BenefitTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenefitType benefitType = db.BenefitTypes.Find(id);
            if (benefitType == null)
            {
                return HttpNotFound();
            }
            return View(benefitType);
        }

        // POST: BenefitTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BenefitType benefitType = db.BenefitTypes.Find(id);
            db.BenefitTypes.Remove(benefitType);
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
