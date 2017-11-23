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
    public class TrainingCategoriesController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: TrainingCategories
        public ActionResult Index()
        {
            return View(db.TrainingCategories.ToList());
        }

        // GET: TrainingCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCategory trainingCategory = db.TrainingCategories.Find(id);
            if (trainingCategory == null)
            {
                return HttpNotFound();
            }
            return View(trainingCategory);
        }

        // GET: TrainingCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainingCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Abbreviation")] TrainingCategory trainingCategory)
        {
            if (ModelState.IsValid)
            {
                db.TrainingCategories.Add(trainingCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainingCategory);
        }

        // GET: TrainingCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCategory trainingCategory = db.TrainingCategories.Find(id);
            if (trainingCategory == null)
            {
                return HttpNotFound();
            }
            return View(trainingCategory);
        }

        // POST: TrainingCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Abbreviation")] TrainingCategory trainingCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainingCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainingCategory);
        }

        // GET: TrainingCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainingCategory trainingCategory = db.TrainingCategories.Find(id);
            if (trainingCategory == null)
            {
                return HttpNotFound();
            }
            return View(trainingCategory);
        }

        // POST: TrainingCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainingCategory trainingCategory = db.TrainingCategories.Find(id);
            db.TrainingCategories.Remove(trainingCategory);
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
