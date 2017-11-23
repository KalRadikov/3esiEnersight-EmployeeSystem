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
    public class BenefitsController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: Benefits
        public ActionResult Index(int? id, string searchString, string sortOrder, string currentFilter, int? page, int? pageSize)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.FNameSortParm = sortOrder == "FName" ? "FName_desc" : "FName";
            ViewBag.TypeSortParm = sortOrder == "Type" ? "Type_desc" : "Type";
            ViewBag.PlanSortParm = sortOrder == "Plan" ? "Plan_desc" : "Plan";
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

            var benefits = db.Benefits.Include(b => b.BenefitType).Include(b => b.Currency).Include(b => b.Employee);

            if (!String.IsNullOrEmpty(searchString))
            {
                benefits = benefits.Where(s => s.Employee.LastName.ToUpper().Contains(searchString.ToUpper())
                                                            || s.Employee.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    benefits = benefits.OrderByDescending(s => s.Employee.LastName);
                    break;
                case "Date":
                    benefits = benefits.OrderBy(s => s.EffectiveDate);
                    break;
                case "date_desc":
                    benefits = benefits.OrderByDescending(s => s.EffectiveDate);
                    break;
                case "FName_desc":
                    benefits = benefits.OrderByDescending(s => s.Employee.FirstName);
                    break;
                case "FName":
                    benefits = benefits.OrderBy(s => s.Employee.FirstName);
                    break;
                case "Type_desc":
                    benefits = benefits.OrderByDescending(s => s.BenefitType.Name);
                    break;
                case "Type":
                    benefits = benefits.OrderBy(s => s.BenefitType.Name);
                    break;
                case "Plan_desc":
                    benefits = benefits.OrderByDescending(s => s.BenefitPlan);
                    break;
                case "Plan":
                    benefits = benefits.OrderBy(s => s.BenefitPlan);
                    break;
                case "Amount_desc":
                    benefits = benefits.OrderByDescending(s => s.Amount);
                    break;
                case "Amount":
                    benefits = benefits.OrderBy(s => s.Amount);
                    break;
                default:
                    benefits = benefits.OrderBy(s => s.Employee.LastName);
                    break;
            }

            GlobalVars._pageSize_ = pageSize ?? GlobalVars._pageSize_;
            int pageNumber = (page ?? 1);


            return View(benefits.ToPagedList(pageNumber, GlobalVars._pageSize_));
        }

        // GET: Benefits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benefit benefit = db.Benefits.Find(id);
            if (benefit == null)
            {
                return HttpNotFound();
            }
            return View(benefit);
        }

        // GET: Benefits/Create
        public ActionResult Create()
        {
            ViewBag.BenefitTypeID = new SelectList(db.BenefitTypes, "ID", "Name");
            ViewBag.CurrencyID = new SelectList(db.Currencies, "ID", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees.OrderBy(i => i.LastName), "EmployeeID", "FullName");
            return View();
        }

        // POST: Benefits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BenefitID,EmployeeID,EffectiveDate,EndDate,BenefitPlan,BenefitTypeID,Amount,CurrencyID,Comment")] Benefit benefit)
        {
            if (ModelState.IsValid)
            {
                db.Benefits.Add(benefit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BenefitTypeID = new SelectList(db.BenefitTypes, "ID", "Name", benefit.BenefitTypeID);
            ViewBag.CurrencyID = new SelectList(db.Currencies, "ID", "Name", benefit.CurrencyID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", benefit.EmployeeID);
            return View(benefit);
        }

        // GET: Benefits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benefit benefit = db.Benefits.Find(id);
            if (benefit == null)
            {
                return HttpNotFound();
            }
            ViewBag.BenefitTypeID = new SelectList(db.BenefitTypes, "ID", "Name", benefit.BenefitTypeID);
            ViewBag.CurrencyID = new SelectList(db.Currencies, "ID", "Name", benefit.CurrencyID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", benefit.EmployeeID);
            return View(benefit);
        }

        // POST: Benefits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BenefitID,EmployeeID,EffectiveDate,EndDate,BenefitPlan,BenefitTypeID,Amount,CurrencyID,Comment")] Benefit benefit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(benefit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BenefitTypeID = new SelectList(db.BenefitTypes, "ID", "Name", benefit.BenefitTypeID);
            ViewBag.CurrencyID = new SelectList(db.Currencies, "ID", "Name", benefit.CurrencyID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", benefit.EmployeeID);
            return View(benefit);
        }

        // GET: Benefits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benefit benefit = db.Benefits.Find(id);
            if (benefit == null)
            {
                return HttpNotFound();
            }
            return View(benefit);
        }

        // POST: Benefits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Benefit benefit = db.Benefits.Find(id);
            db.Benefits.Remove(benefit);
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
