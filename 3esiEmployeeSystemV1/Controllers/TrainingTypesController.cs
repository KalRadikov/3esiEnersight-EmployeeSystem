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
    public class TrainingTypesController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: TrainingTypes
        public ActionResult Index()
        {
            return View(db.TrainingTypes.ToList());
        }

        // GET: TrainingTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingType trainingType = db.TrainingTypes.Find(id);
            if (trainingType == null)
            {
                return HttpNotFound();
            }
            return View(trainingType);
        }

        // GET: TrainingTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainingTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Abbreviation")] TrainingType trainingType)
        {
            if (ModelState.IsValid)
            {
                db.TrainingTypes.Add(trainingType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingType);
        }

        // GET: TrainingTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingType trainingType = db.TrainingTypes.Find(id);
            if (trainingType == null)
            {
                return HttpNotFound();
            }
            return View(trainingType);
        }

        // POST: TrainingTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Abbreviation")] TrainingType trainingType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingType);
        }

        // GET: TrainingTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingType trainingType = db.TrainingTypes.Find(id);
            if (trainingType == null)
            {
                return HttpNotFound();
            }
            return View(trainingType);
        }

        // POST: TrainingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingType trainingType = db.TrainingTypes.Find(id);
            db.TrainingTypes.Remove(trainingType);
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
