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
    public class StatusController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: Status
        public ActionResult Index(int? id, string searchString, string sortOrder, string currentFilter, int? page, int? pageSize)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.FNameSortParm = sortOrder == "FName" ? "FName_desc" : "FName";
            ViewBag.StatusSortParm = sortOrder == "Status" ? "Status_desc" : "Status";
            ViewBag.HCompSortParm = sortOrder == "HComp" ? "HComp_desc" : "HComp";
            ViewBag.LCompSortParm = sortOrder == "LComp" ? "LComp_desc" : "LComp";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var status = db.Status
                         .Include(s => s.Employee)
                         .Include(s => s.EmployeeStatus)
                         .Include(s => s.EmployeeType)
                         .Include(s => s.HeritageCompany)
                         .Include(s => s.LegalCompany)
                         .Include(s => s.OverTimeStatus)
                         .Include(s => s.UnionStatus)
                         .GroupBy(x => x.EmployeeID)
                         .Select(y => y.OrderByDescending(i => i.EffectiveDate)
                         .FirstOrDefault());
            
            if (!String.IsNullOrEmpty(searchString))
            {
                status = status.Where(s => s.Employee.LastName.ToUpper().Contains(searchString.ToUpper())
                                                            || s.Employee.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    status = status.OrderByDescending(s => s.Employee.LastName);
                    break;
                case "Date":
                    status = status.OrderBy(s => s.EffectiveDate);
                    break;
                case "date_desc":
                    status = status.OrderByDescending(s => s.EffectiveDate);
                    break;
                case "FName_desc":
                    status = status.OrderByDescending(s => s.Employee.FirstName);
                    break;
                case "FName":
                    status = status.OrderBy(s => s.Employee.FirstName);
                    break;
                case "HComp_desc":
                    status = status.OrderByDescending(s => s.HeritageCompany.Name);
                    break;
                case "HComp":
                    status = status.OrderBy(s => s.HeritageCompany.Name);
                    break;
                case "LComp_desc":
                    status = status.OrderByDescending(s => s.LegalCompany.Name);
                    break;
                case "LComp":
                    status = status.OrderBy(s => s.LegalCompany.Name);
                    break;
                case "Status_desc":
                    status = status.OrderByDescending(s => s.EmployeeStatus.Name);
                    break;
                case "Status":
                    status = status.OrderBy(s => s.EmployeeStatus.Name);
                    break;
                default:
                    status = status.OrderBy(s => s.Employee.LastName);
                    break;
            }

            GlobalVars._pageSize_ = pageSize ?? GlobalVars._pageSize_;
            int pageNumber = (page ?? 1);

            return View(status.ToPagedList(pageNumber, GlobalVars._pageSize_));
        }

        // GET: Status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = db.Status.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // GET: Status/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees.OrderBy(i=>i.LastName), "EmployeeID", "FullName");
            ViewBag.EmployeeStatusID = new SelectList(db.EmployeeStatus, "ID", "Name");
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "ID", "Name");
            ViewBag.HeritageCompanyID = new SelectList(db.HeritageCompanies, "ID", "Name");
            ViewBag.LegalCompanyID = new SelectList(db.LegalCompanies, "ID", "Name");
            ViewBag.OverTimeStatusID = new SelectList(db.OverTimeStatus, "ID", "Name");
            ViewBag.UnionStatusID = new SelectList(db.UnionStatus, "ID", "Name");
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusID,EmployeeID,EffectiveDate,EndDate,HeritageCompanyID,LegalCompanyID,EmployeeStatusID,EmployeeTypeID,PercentFullTime,OverTimeStatusID,UnionStatusID,PayRollNumber")] Status status)
        {
            if (ModelState.IsValid)
            {
                db.Status.Add(status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", status.EmployeeID);
            ViewBag.EmployeeStatusID = new SelectList(db.EmployeeStatus, "ID", "Name", status.EmployeeStatusID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "ID", "Name", status.EmployeeTypeID);
            ViewBag.HeritageCompanyID = new SelectList(db.HeritageCompanies, "ID", "Name", status.HeritageCompanyID);
            ViewBag.LegalCompanyID = new SelectList(db.LegalCompanies, "ID", "Name", status.LegalCompanyID);
            ViewBag.OverTimeStatusID = new SelectList(db.OverTimeStatus, "ID", "Name", status.OverTimeStatusID);
            ViewBag.UnionStatusID = new SelectList(db.UnionStatus, "ID", "Name", status.UnionStatusID);
            return View(status);
        }

        // GET: Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = db.Status.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", status.EmployeeID);
            ViewBag.EmployeeStatusID = new SelectList(db.EmployeeStatus, "ID", "Name", status.EmployeeStatusID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "ID", "Name", status.EmployeeTypeID);
            ViewBag.HeritageCompanyID = new SelectList(db.HeritageCompanies, "ID", "Name", status.HeritageCompanyID);
            ViewBag.LegalCompanyID = new SelectList(db.LegalCompanies, "ID", "Name", status.LegalCompanyID);
            ViewBag.OverTimeStatusID = new SelectList(db.OverTimeStatus, "ID", "Name", status.OverTimeStatusID);
            ViewBag.UnionStatusID = new SelectList(db.UnionStatus, "ID", "Name", status.UnionStatusID);
            return View(status);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusID,EmployeeID,EffectiveDate,EndDate,HeritageCompanyID,LegalCompanyID,EmployeeStatusID,EmployeeTypeID,PercentFullTime,OverTimeStatusID,UnionStatusID,PayRollNumber")] Status status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", status.EmployeeID);
            ViewBag.EmployeeStatusID = new SelectList(db.EmployeeStatus, "ID", "Name", status.EmployeeStatusID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "ID", "Name", status.EmployeeTypeID);
            ViewBag.HeritageCompanyID = new SelectList(db.HeritageCompanies, "ID", "Name", status.HeritageCompanyID);
            ViewBag.LegalCompanyID = new SelectList(db.LegalCompanies, "ID", "Name", status.LegalCompanyID);
            ViewBag.OverTimeStatusID = new SelectList(db.OverTimeStatus, "ID", "Name", status.OverTimeStatusID);
            ViewBag.UnionStatusID = new SelectList(db.UnionStatus, "ID", "Name", status.UnionStatusID);
            return View(status);
        }

        // GET: Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Status status = db.Status.Find(id);
            if (status == null)
            {
                return HttpNotFound();
            }
            return View(status);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Status status = db.Status.Find(id);
            db.Status.Remove(status);
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
