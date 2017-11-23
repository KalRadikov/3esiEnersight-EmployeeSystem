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
    [Authorize(Roles = "Admin")]
    public class BuildingAccessesController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: BuildingAccesses
        public ActionResult Index(int? id, string searchString, string sortOrder, string currentFilter, int? page, int? pageSize)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.FNameSortParm = sortOrder == "FName" ? "FName_desc" : "FName";
            ViewBag.BldingSortParm = sortOrder == "Building" ? "Building_desc" : "Building";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var buildingAccesses = db.BuildingAccesses.Include(b => b.Building).Include(b => b.Employee);

            if (!String.IsNullOrEmpty(searchString))
            {
                buildingAccesses = buildingAccesses.Where(s => s.Employee.LastName.ToUpper().Contains(searchString.ToUpper())
                                                            || s.Employee.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    buildingAccesses = buildingAccesses.OrderByDescending(s => s.Employee.LastName);
                    break;
                case "Date":
                    buildingAccesses = buildingAccesses.OrderBy(s => s.EffectiveDate);
                    break;
                case "date_desc":
                    buildingAccesses = buildingAccesses.OrderByDescending(s => s.EffectiveDate);
                    break;
                case "FName_desc":
                    buildingAccesses = buildingAccesses.OrderByDescending(s => s.Employee.FirstName);
                    break;
                case "FName":
                    buildingAccesses = buildingAccesses.OrderBy(s => s.Employee.FirstName);
                    break;
                case "Building_desc":
                    buildingAccesses = buildingAccesses.OrderByDescending(s => s.Building.Name);
                    break;
                case "Building":
                    buildingAccesses = buildingAccesses.OrderBy(s => s.Building.Name);
                    break;
                default:
                    buildingAccesses = buildingAccesses.OrderBy(s => s.Employee.LastName);
                    break;
            }

            GlobalVars._pageSize_ = pageSize ?? GlobalVars._pageSize_;
            int pageNumber = (page ?? 1);

            return View(buildingAccesses.ToPagedList(pageNumber, GlobalVars._pageSize_));
        }

        // GET: BuildingAccesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingAccess buildingAccess = db.BuildingAccesses.Find(id);
            if (buildingAccess == null)
            {
                return HttpNotFound();
            }
            return View(buildingAccess);
        }

        // GET: BuildingAccesses/Create
        public ActionResult Create()
        {
            ViewBag.BuildingID = new SelectList(db.Buildings, "BuildingID", "Name");
            ViewBag.EmployeeID = new SelectList(db.Employees.OrderBy(i => i.LastName), "EmployeeID", "FullName");
            return View();
        }

        // POST: BuildingAccesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BuildingAccessID,EmployeeID,BuildingID,EffectiveDate,CardIDNumber")] BuildingAccess buildingAccess)
        {
            if (ModelState.IsValid)
            {
                db.BuildingAccesses.Add(buildingAccess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuildingID = new SelectList(db.Buildings, "BuildingID", "Name", buildingAccess.BuildingID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", buildingAccess.EmployeeID);
            return View(buildingAccess);
        }

        // GET: BuildingAccesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingAccess buildingAccess = db.BuildingAccesses.Find(id);
            if (buildingAccess == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuildingID = new SelectList(db.Buildings, "BuildingID", "Name", buildingAccess.BuildingID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", buildingAccess.EmployeeID);
            return View(buildingAccess);
        }

        // POST: BuildingAccesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuildingAccessID,EmployeeID,BuildingID,EffectiveDate,CardIDNumber")] BuildingAccess buildingAccess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buildingAccess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuildingID = new SelectList(db.Buildings, "BuildingID", "Name", buildingAccess.BuildingID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", buildingAccess.EmployeeID);
            return View(buildingAccess);
        }

        // GET: BuildingAccesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingAccess buildingAccess = db.BuildingAccesses.Find(id);
            if (buildingAccess == null)
            {
                return HttpNotFound();
            }
            return View(buildingAccess);
        }

        // POST: BuildingAccesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuildingAccess buildingAccess = db.BuildingAccesses.Find(id);
            db.BuildingAccesses.Remove(buildingAccess);
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
