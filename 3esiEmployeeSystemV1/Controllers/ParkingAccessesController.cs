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
    [Authorize(Roles = "Admin, Manager, Employee")]
    public class ParkingAccessesController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: ParkingAccesses
        public ActionResult Index(int? id, string searchString, string sortOrder, string currentFilter, int? page, int? pageSize)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.FNameSortParm = sortOrder == "FName" ? "FName_desc" : "FName";
            ViewBag.ParkSortParm = sortOrder == "Park" ? "Park_desc" : "Park";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var parkingAccesses = db.ParkingAccesses.Include(p => p.Employee).Include(p => p.Parking);

            if (!String.IsNullOrEmpty(searchString))
            {
                parkingAccesses = parkingAccesses.Where(s => s.Employee.LastName.ToUpper().Contains(searchString.ToUpper())
                                                            || s.Employee.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    parkingAccesses = parkingAccesses.OrderByDescending(s => s.Employee.LastName);
                    break;
                case "Date":
                    parkingAccesses = parkingAccesses.OrderBy(s => s.EffectiveDate);
                    break;
                case "date_desc":
                    parkingAccesses = parkingAccesses.OrderByDescending(s => s.EffectiveDate);
                    break;
                case "FName_desc":
                    parkingAccesses = parkingAccesses.OrderByDescending(s => s.Employee.FirstName);
                    break;
                case "FName":
                    parkingAccesses = parkingAccesses.OrderBy(s => s.Employee.FirstName);
                    break;
                case "Park_desc":
                    parkingAccesses = parkingAccesses.OrderByDescending(s => s.Parking.Address);
                    break;
                case "Park":
                    parkingAccesses = parkingAccesses.OrderBy(s => s.Parking.Address);
                    break;
                default:
                    parkingAccesses = parkingAccesses.OrderBy(s => s.Employee.LastName);
                    break;
            }

            GlobalVars._pageSize_ = pageSize ?? GlobalVars._pageSize_;
            int pageNumber = (page ?? 1);

            return View(parkingAccesses.ToPagedList(pageNumber, GlobalVars._pageSize_));
        }

        // GET: ParkingAccesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingAccess parkingAccess = db.ParkingAccesses.Find(id);
            if (parkingAccess == null)
            {
                return HttpNotFound();
            }
            return View(parkingAccess);
        }

        // GET: ParkingAccesses/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees.OrderBy(i => i.LastName), "EmployeeID", "FullName");
            ViewBag.ParkingID = new SelectList(db.Parkings, "ParkingID", "Address");
            return View();
        }

        // POST: ParkingAccesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParkingAccessID,EmployeeID,ParkingID,EffectiveDate,CarModel,PlateNumber")] ParkingAccess parkingAccess)
        {
            if (ModelState.IsValid)
            {
                db.ParkingAccesses.Add(parkingAccess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", parkingAccess.EmployeeID);
            ViewBag.ParkingID = new SelectList(db.Parkings, "ParkingID", "Address", parkingAccess.ParkingID);
            return View(parkingAccess);
        }

        // GET: ParkingAccesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingAccess parkingAccess = db.ParkingAccesses.Find(id);
            if (parkingAccess == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", parkingAccess.EmployeeID);
            ViewBag.ParkingID = new SelectList(db.Parkings, "ParkingID", "Address", parkingAccess.ParkingID);
            return View(parkingAccess);
        }

        // POST: ParkingAccesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParkingAccessID,EmployeeID,ParkingID,EffectiveDate,CarModel,PlateNumber")] ParkingAccess parkingAccess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkingAccess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", parkingAccess.EmployeeID);
            ViewBag.ParkingID = new SelectList(db.Parkings, "ParkingID", "Address", parkingAccess.ParkingID);
            return View(parkingAccess);
        }

        // GET: ParkingAccesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingAccess parkingAccess = db.ParkingAccesses.Find(id);
            if (parkingAccess == null)
            {
                return HttpNotFound();
            }
            return View(parkingAccess);
        }

        // POST: ParkingAccesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkingAccess parkingAccess = db.ParkingAccesses.Find(id);
            db.ParkingAccesses.Remove(parkingAccess);
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
