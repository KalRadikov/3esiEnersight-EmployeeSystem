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
    public class BudgetAreasController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: BudgetAreas
        public ActionResult Index()
        {
            return View(db.BudgetAreas.ToList());
        }

        // GET: BudgetAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetArea budgetArea = db.BudgetAreas.Find(id);
            if (budgetArea == null)
            {
                return HttpNotFound();
            }
            return View(budgetArea);
        }

        // GET: BudgetAreas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BudgetAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Abbreviation")] BudgetArea budgetArea)
        {
            if (ModelState.IsValid)
            {
                db.BudgetAreas.Add(budgetArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(budgetArea);
        }

        // GET: BudgetAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetArea budgetArea = db.BudgetAreas.Find(id);
            if (budgetArea == null)
            {
                return HttpNotFound();
            }
            return View(budgetArea);
        }

        // POST: BudgetAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Abbreviation")] BudgetArea budgetArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budgetArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(budgetArea);
        }

        // GET: BudgetAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetArea budgetArea = db.BudgetAreas.Find(id);
            if (budgetArea == null)
            {
                return HttpNotFound();
            }
            return View(budgetArea);
        }

        // POST: BudgetAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BudgetArea budgetArea = db.BudgetAreas.Find(id);
            db.BudgetAreas.Remove(budgetArea);
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
