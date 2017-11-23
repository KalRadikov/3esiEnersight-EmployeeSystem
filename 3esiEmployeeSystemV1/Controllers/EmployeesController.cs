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
    public class EmployeesController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: Employees
        public ActionResult Index(int? id, string searchString, string sortOrder, string currentFilter, int? page, int? pageSize)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.FNameSortParm = sortOrder == "FName" ? "FName_desc" : "FName";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var employees = db.Employees
                .Include(e => e.EmployeeStatus.Select(c => c.EmployeeStatus))
                .Where(e => (e.EmployeeStatus.GroupBy(x => x.EmployeeID)
                    .Select(y => y.OrderByDescending(i => i.EffectiveDate)
                    .FirstOrDefault()).Select(c => c.EmployeeStatus.Name).FirstOrDefault() == "Active") ||
                    (e.EmployeeStatus.GroupBy(x => x.EmployeeID)
                    .Select(y => y.OrderByDescending(i => i.EffectiveDate)
                    .FirstOrDefault()).Select(c => c.EmployeeStatus.Name).FirstOrDefault() == "Contractor")
                    );

            //        var employees = from s in db.Employees.Include(e => e.EmployeeStatus.Select(c => c.HeritageCompany))
            //.Include(e => e.EmployeeStatus.Select(c => c.LegalCompany))
            //.Include(e => e.EmployeeStatus.Select(c => c.EmployeeStatus))
            //.Include(e => e.EmployeeStatus.Select(c => c.EmployeeType))
            //.Include(e => e.EmployeeStatus.Select(c => c.OverTimeStatus))
            //.Include(e => e.EmployeeStatus.Select(c => c.UnionStatus))
            //.Include(e => e.Compensations.Select(c => c.CompensationType))
            //.Include(e => e.Compensations.Select(c => c.Currency))
            //.Include(e => e.Careers.Select(c => c.Department))
            //.Include(e => e.Careers.Select(c => c.BudgetArea))
            //.Include(e => e.Benefits.Select(c => c.BenefitType))
            //.Include(e => e.Trainings.Select(c => c.TrainingType))
            //.Include(e => e.Trainings.Select(c => c.TrainingCategory))
            //.Include(e => e.ParkingAccesses.Select(c => c.Parking))
            //.Include(e => e.BuildingAccesses.Select(c => c.Building))
            //.Where(e => e.EmployeeStatus.Select(c => c.EmployeeStatus.Name).FirstOrDefault() == "Active")
            //.OrderBy(i => i.LastName)
            //                        select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
                                                            || s.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    employees = employees.OrderBy(s => s.HireDate);
                    break;
                case "date_desc":
                    employees = employees.OrderByDescending(s => s.HireDate);
                    break;
                case "FName_desc":
                    employees = employees.OrderByDescending(s => s.FirstName);
                    break;
                case "FName":
                    employees = employees.OrderBy(s => s.FirstName);
                    break;
                default:
                    employees = employees.OrderBy(s => s.LastName);
                    break;
            }

            GlobalVars._pageSize_ = pageSize ?? GlobalVars._pageSize_;
            int pageNumber = (page ?? 1);

            return View(employees.ToPagedList(pageNumber, GlobalVars._pageSize_));
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,LastName,FirstName,MiddleName,Gender,BirthDate,Citizenship,Address1,Address2,City,ProvinceState,Country,PostalZip,HomePhone,MobilePhone,OfficePhone,HireDate,ContractEndDate,TerminationDate,EmergencyContactName,EmergencyContactRelationship,EmergencyContactNumber,YearsIndustryService")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,LastName,FirstName,MiddleName,Gender,BirthDate,Citizenship,Address1,Address2,City,ProvinceState,Country,PostalZip,HomePhone,MobilePhone,OfficePhone,HireDate,ContractEndDate,TerminationDate,EmergencyContactName,EmergencyContactRelationship,EmergencyContactNumber,YearsIndustryService")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
