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
    public class TrainingsController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: Trainings
        public ActionResult Index(int? id, string searchString, string sortOrder, string currentFilter, int? page, int? pageSize)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.FNameSortParm = sortOrder == "FName" ? "FName_desc" : "FName";
            ViewBag.CatSortParm = sortOrder == "Cat" ? "Cat_desc" : "Cat";
            ViewBag.TypeSortParm = sortOrder == "Type" ? "Type_desc" : "Type";
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

            var trainings = db.Trainings.Include(t => t.Employee).Include(t => t.TrainingCategory).Include(t => t.TrainingType);

            if (!String.IsNullOrEmpty(searchString))
            {
                trainings = trainings.Where(s => s.Employee.LastName.ToUpper().Contains(searchString.ToUpper())
                                                            || s.Employee.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    trainings = trainings.OrderByDescending(s => s.Employee.LastName);
                    break;
                case "FName_desc":
                    trainings = trainings.OrderByDescending(s => s.Employee.FirstName);
                    break;
                case "FName":
                    trainings = trainings.OrderBy(s => s.Employee.FirstName);
                    break;
                case "Date":
                    trainings = trainings.OrderBy(s => s.StartDate);
                    break;
                case "date_desc":
                    trainings = trainings.OrderByDescending(s => s.StartDate);
                    break;
                case "Cat":
                    trainings = trainings.OrderBy(s => s.TrainingCategory.Name);
                    break;
                case "Cat_desc":
                    trainings = trainings.OrderByDescending(s => s.TrainingCategory.Name);
                    break;
                case "Type":
                    trainings = trainings.OrderBy(s => s.TrainingType.Name);
                    break;
                case "Type_desc":
                    trainings = trainings.OrderByDescending(s => s.TrainingType.Name);
                    break;
                case "Amount":
                    trainings = trainings.OrderBy(s => s.Amount);
                    break;
                case "Amount_desc":
                    trainings = trainings.OrderByDescending(s => s.Amount);
                    break;
                default:
                    trainings = trainings.OrderBy(s => s.Employee.LastName);
                    break;
            }

            GlobalVars._pageSize_ = pageSize ?? GlobalVars._pageSize_;
            int pageNumber = (page ?? 1);

            return View(trainings.ToPagedList(pageNumber, GlobalVars._pageSize_));
        }

        // GET: Trainings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            return View(training);
        }

        // GET: Trainings/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees.OrderBy(i => i.LastName), "EmployeeID", "FullName");
            ViewBag.TrainingCategoryID = new SelectList(db.TrainingCategories, "ID", "Name");
            ViewBag.TrainingTypeID = new SelectList(db.TrainingTypes, "ID", "Name");
            return View();
        }

        // POST: Trainings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainingID,EmployeeID,CourseName,TrainingTypeID,TrainingCategoryID,OfferedBy,StartDate,EndDate,Amount,Feedback")] Training training)
        {
            if (ModelState.IsValid)
            {
                db.Trainings.Add(training);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", training.EmployeeID);
            ViewBag.TrainingCategoryID = new SelectList(db.TrainingCategories, "ID", "Name", training.TrainingCategoryID);
            ViewBag.TrainingTypeID = new SelectList(db.TrainingTypes, "ID", "Name", training.TrainingTypeID);
            return View(training);
        }

        // GET: Trainings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", training.EmployeeID);
            ViewBag.TrainingCategoryID = new SelectList(db.TrainingCategories, "ID", "Name", training.TrainingCategoryID);
            ViewBag.TrainingTypeID = new SelectList(db.TrainingTypes, "ID", "Name", training.TrainingTypeID);
            return View(training);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainingID,EmployeeID,CourseName,TrainingTypeID,TrainingCategoryID,OfferedBy,StartDate,EndDate,Amount,Feedback")] Training training)
        {
            if (ModelState.IsValid)
            {
                db.Entry(training).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", training.EmployeeID);
            ViewBag.TrainingCategoryID = new SelectList(db.TrainingCategories, "ID", "Name", training.TrainingCategoryID);
            ViewBag.TrainingTypeID = new SelectList(db.TrainingTypes, "ID", "Name", training.TrainingTypeID);
            return View(training);
        }

        // GET: Trainings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            return View(training);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Training training = db.Trainings.Find(id);
            db.Trainings.Remove(training);
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
