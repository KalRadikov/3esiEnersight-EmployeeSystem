using _3esiEmployeeSystemV1.Models;
using _3esiEmployeeSystemV1.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using _3esiEmployeeSystemV1.Helpers;

namespace _3esiEmployeeSystemV1.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class ReportingController : Controller
    {

        private EmployeeDBContext db = new EmployeeDBContext();

        public ActionResult EntityReport()
        {
            IQueryable<EntityGroup> data = ReportingHelpers.GetEntityDashboard();
            ViewBag.Total = data.Sum(x => x.BAreaCount);

            return View(data.ToList());
        }

        public ActionResult BAreaReport()
        {

            IQueryable<EntityGroup> data = ReportingHelpers.GetEntityDashboard();
            ViewBag.Total = data.Sum(x => x.BAreaCount);

            //var data = from e in db.Careers
            //                  .Include(x => x.Employee)
            //                  .GroupBy(x => x.EmployeeID)
            //                  .Select(y => y.OrderByDescending(i => i.EffectiveDate)
            //                  .FirstOrDefault())
            //           group e by e.BudgetArea.Name into g
            //           select new EntityGroup
            //           {
            //               BudgetArea = g.Key,
            //               Departments = from d in g
            //                             group d by d.Department.Name into sg
            //                             select new
            //                             {
            //                                 BudgetArea = g.Key,
            //                                 Department = sg.Key
            //                             }

            //           };

            return View(data.ToList());
        }

        public ActionResult HistoryReport(int? id)
        {

            var employees = from s in db.Employees.Include(e => e.EmployeeStatus.Select(c => c.HeritageCompany))
                .Include(e => e.EmployeeStatus.Select(c => c.LegalCompany))
                .Include(e => e.EmployeeStatus.Select(c => c.EmployeeStatus))
                .Include(e => e.EmployeeStatus.Select(c => c.EmployeeType))
                .Include(e => e.EmployeeStatus.Select(c => c.OverTimeStatus))
                .Include(e => e.EmployeeStatus.Select(c => c.UnionStatus))
                .Include(e => e.Compensations.Select(c => c.CompensationType))
                .Include(e => e.Compensations.Select(c => c.Currency))
                .Include(e => e.Careers.Select(c => c.Department))
                .Include(e => e.Careers.Select(c => c.BudgetArea))
                .Include(e => e.Benefits.Select(c => c.BenefitType))
                .Include(e => e.Trainings.Select(c => c.TrainingType))
                .Include(e => e.Trainings.Select(c => c.TrainingCategory))
                .Include(e => e.ParkingAccesses.Select(c => c.Parking))
                .Include(e => e.BuildingAccesses.Select(c => c.Building))
                .OrderBy(i => i.LastName)
                            select s;

            var viewModel = new EmployeeIndexData();


            if (!id.Equals(null))
            {
                ViewBag.EmployeeID = id.Value;
                viewModel.Status = employees.Where(
                    i => i.EmployeeID == id.Value).Single().EmployeeStatus;
                viewModel.Compensations = employees.Where(
                    i => i.EmployeeID == id.Value).Single().Compensations;
                viewModel.Careers = employees.Where(
                    i => i.EmployeeID == id.Value).Single().Careers;
                viewModel.Benefits = employees.Where(
                    i => i.EmployeeID == id.Value).Single().Benefits;
                viewModel.Trainings = employees.Where(
                    i => i.EmployeeID == id.Value).Single().Trainings;
                viewModel.ParkingAccesses = employees.Where(
                    i => i.EmployeeID == id.Value).Single().ParkingAccesses;
                viewModel.BuildingAccesses = employees.Where(
                    i => i.EmployeeID == id.Value).Single().BuildingAccesses;

                ViewBag.FullName = employees.Where(
                    i => i.EmployeeID == id.Value).Single().FullName;
            }

            return View(viewModel);
        }

        // GET: Reporting
        public ActionResult Index()
        {
            return View();
        }

        // GET: Reporting/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reporting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reporting/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reporting/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reporting/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reporting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reporting/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
