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
    public class CareersController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: Careers
        public ActionResult Index(int? id, string searchString, string sortOrder, string currentFilter, int? page, int? pageSize)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.FNameSortParm = sortOrder == "FName" ? "FName_desc" : "FName";
            ViewBag.BAreaSortParm = sortOrder == "BArea" ? "BArea_desc" : "BArea";
            ViewBag.DeptSortParm = sortOrder == "Dept" ? "Dept_desc" : "Dept";
            ViewBag.SupervisorSortParm = sortOrder == "Supervisor" ? "Supervisor_desc" : "Supervisor";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var careers = db.Careers
                .Include(c => c.BudgetArea)
                .Include(c => c.Department)
                .Include(c => c.Employee)
                .GroupBy(x => x.EmployeeID)
                .Select(y => y.OrderByDescending(i => i.EffectiveDate)
                .FirstOrDefault());

            if (!String.IsNullOrEmpty(searchString))
            {
                careers = careers.Where(s => s.Employee.LastName.ToUpper().Contains(searchString.ToUpper())
                                                            || s.Employee.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    careers = careers.OrderByDescending(s => s.Employee.LastName);
                    break;
                case "Date":
                    careers = careers.OrderBy(s => s.EffectiveDate);
                    break;
                case "date_desc":
                    careers = careers.OrderByDescending(s => s.EffectiveDate);
                    break;
                case "FName_desc":
                    careers = careers.OrderByDescending(s => s.Employee.FirstName);
                    break;
                case "FName":
                    careers = careers.OrderBy(s => s.Employee.FirstName);
                    break;
                case "BArea_desc":
                    careers = careers.OrderByDescending(s => s.BudgetArea.Name);
                    break;
                case "BArea":
                    careers = careers.OrderBy(s => s.BudgetArea.Name);
                    break;
                case "Dept_desc":
                    careers = careers.OrderByDescending(s => s.Department.Name);
                    break;
                case "Dept":
                    careers = careers.OrderBy(s => s.Department.Name);
                    break;
                case "Supervisor_desc":
                    careers = careers.OrderByDescending(s => s.Supervisor);
                    break;
                case "Supervisor":
                    careers = careers.OrderBy(s => s.Supervisor);
                    break;
                default:
                    careers = careers.OrderBy(s => s.Employee.LastName);
                    break;
            }

            GlobalVars._pageSize_ = pageSize ?? GlobalVars._pageSize_;
            int pageNumber = (page ?? 1);

            return View(careers.ToPagedList(pageNumber, GlobalVars._pageSize_));
        }

        // GET: Careers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = db.Careers.Find(id);
            if (career == null)
            {
                return HttpNotFound();
            }
            return View(career);
        }

        // GET: Careers/Create
        public ActionResult Create()
        {
            ViewBag.BudgetAreaID = new SelectList(db.BudgetAreas, "ID", "Name");
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees.OrderBy(i => i.LastName), "EmployeeID", "FullName");
            return View();
        }

        // POST: Careers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CareerID,EmployeeID,Title,DepartmentID,BudgetAreaID,Supervisor,EffectiveDate,EndDate")] Career career)
        {
            if (ModelState.IsValid)
            {
                db.Careers.Add(career);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BudgetAreaID = new SelectList(db.BudgetAreas, "ID", "Name", career.BudgetAreaID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", career.DepartmentID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", career.EmployeeID);
            return View(career);
        }

        // GET: Careers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = db.Careers.Find(id);
            if (career == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudgetAreaID = new SelectList(db.BudgetAreas, "ID", "Name", career.BudgetAreaID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", career.DepartmentID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", career.EmployeeID);
            return View(career);
        }

        // POST: Careers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CareerID,EmployeeID,Title,DepartmentID,BudgetAreaID,Supervisor,EffectiveDate,EndDate")] Career career)
        {
            if (ModelState.IsValid)
            {
                db.Entry(career).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudgetAreaID = new SelectList(db.BudgetAreas, "ID", "Name", career.BudgetAreaID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", career.DepartmentID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", career.EmployeeID);
            return View(career);
        }

        // GET: Careers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = db.Careers.Find(id);
            if (career == null)
            {
                return HttpNotFound();
            }
            return View(career);
        }

        // POST: Careers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Career career = db.Careers.Find(id);
            db.Careers.Remove(career);
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
