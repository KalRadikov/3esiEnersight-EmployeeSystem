using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _3esiEmployeeSystemV1.Helpers;
using _3esiEmployeeSystemV1.Models;
using _3esiEmployeeSystemV1.Models.Employee;
using PagedList;

namespace _3esiEmployeeSystemV1.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class CompensationsController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: Compensations
        public ActionResult Index(int? id, string searchString, string sortOrder, string currentFilter, int? page, int? pageSize)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.FNameSortParm = sortOrder == "FName" ? "FName_desc" : "FName";
            ViewBag.CompTypeSortParm = sortOrder == "CompType" ? "CompType_desc" : "CompType";
            ViewBag.AmountSortParm = sortOrder == "Amount" ? "Amount_desc" : "Amount";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var compensations = db.Compensations.Include(c => c.CompensationType).Include(c => c.Currency).Include(c => c.Employee);

            if (!String.IsNullOrEmpty(searchString))
            {
                compensations = compensations.Where(s => s.Employee.LastName.ToUpper().Contains(searchString.ToUpper())
                                                            || s.Employee.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    compensations = compensations.OrderByDescending(s => s.Employee.LastName);
                    break;
                case "Date":
                    compensations = compensations.OrderBy(s => s.EffectiveDate);
                    break;
                case "date_desc":
                    compensations = compensations.OrderByDescending(s => s.EffectiveDate);
                    break;
                case "FName_desc":
                    compensations = compensations.OrderByDescending(s => s.Employee.FirstName);
                    break;
                case "FName":
                    compensations = compensations.OrderBy(s => s.Employee.FirstName);
                    break;
                case "CompType_desc":
                    compensations = compensations.OrderByDescending(s => s.CompensationType.Name);
                    break;
                case "CompType":
                    compensations = compensations.OrderBy(s => s.CompensationType.Name);
                    break;
                case "Amount_desc":
                    compensations = compensations.OrderByDescending(s => s.Amount);
                    break;
                case "Amount":
                    compensations = compensations.OrderBy(s => s.Amount);
                    break;
                default:
                    compensations = compensations.OrderBy(s => s.Employee.LastName);
                    break;
            }

            GlobalVars._pageSize_ = pageSize ?? GlobalVars._pageSize_;
            int pageNumber = (page ?? 1);

            return View(compensations.ToPagedList(pageNumber, GlobalVars._pageSize_));
        }

        // GET: Compensations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compensation compensation = db.Compensations.Find(id);
            if (compensation == null)
            {
                return HttpNotFound();
            }
            return View(compensation);
        }

        // GET: Compensations/Create
        public ActionResult Create()
        {
            ViewBag.CompensationTypeID = new SelectList(db.CompensationTypes, "ID", "Name");
            ViewBag.CurrencyID = new SelectList(db.Currencies, "ID", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees.OrderBy(i => i.LastName), "EmployeeID", "FullName");
            return View();
        }

        // POST: Compensations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompensationID,EmployeeID,EffectiveDate,EndDate,CompensationTypeID,Amount,CurrencyID,ExchangeRate,CompensationComment")] Compensation compensation)
        {
            if (ModelState.IsValid)
            {
                db.Compensations.Add(compensation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompensationTypeID = new SelectList(db.CompensationTypes, "ID", "Name", compensation.CompensationTypeID);
            ViewBag.CurrencyID = new SelectList(db.Currencies, "ID", "Name", compensation.CurrencyID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", compensation.EmployeeID);
            return View(compensation);
        }

        // GET: Compensations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compensation compensation = db.Compensations.Find(id);
            if (compensation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompensationTypeID = new SelectList(db.CompensationTypes, "ID", "Name", compensation.CompensationTypeID);
            ViewBag.CurrencyID = new SelectList(db.Currencies, "ID", "Name", compensation.CurrencyID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", compensation.EmployeeID);
            return View(compensation);
        }

        // POST: Compensations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompensationID,EmployeeID,EffectiveDate,EndDate,CompensationTypeID,Amount,CurrencyID,ExchangeRate,CompensationComment")] Compensation compensation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compensation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompensationTypeID = new SelectList(db.CompensationTypes, "ID", "Name", compensation.CompensationTypeID);
            ViewBag.CurrencyID = new SelectList(db.Currencies, "ID", "Name", compensation.CurrencyID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", compensation.EmployeeID);
            return View(compensation);
        }

        // GET: Compensations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compensation compensation = db.Compensations.Find(id);
            if (compensation == null)
            {
                return HttpNotFound();
            }
            return View(compensation);
        }

        // POST: Compensations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compensation compensation = db.Compensations.Find(id);
            db.Compensations.Remove(compensation);
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
