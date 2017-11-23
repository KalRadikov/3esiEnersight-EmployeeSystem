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
    public class SearchController : Controller
    {
        private EmployeeDBContext db = new EmployeeDBContext();

        // GET: Search
        public ActionResult Index(string departmentType, string budgetAreaType, 
            string statusType, string lCompType, string hCompType,
            string empType, string unionType, string overtimeType, 
            string compensationType, string startDate, string endDate, string searchString)
        {
            var deptList = new List<string>();
            var bAreaList = new List<string>();
            var statusList = new List<string>();
            var lCompList = new List<string>();
            var hCompList = new List<string>();
            var empTypeList = new List<string>();
            var unionList = new List<string>();
            var overtimeList = new List<string>();
            var compensationList = new List<string>();

            var deptQry = from d in db.Careers
                          orderby d.Department.Name
                          select d.Department.Name;

            var bAreaQry = from b in db.Careers
                          orderby b.BudgetArea.Name
                          select b.BudgetArea.Name;

            var statusQry = from s in db.Status
                            orderby s.EmployeeStatus.Name
                            select s.EmployeeStatus.Name;

            var lCompQry = from l in db.Status
                           orderby l.LegalCompany.Name
                           select l.LegalCompany.Name;

            var hCompQry = from h in db.Status
                           orderby h.HeritageCompany.Name
                           select h.HeritageCompany.Name;

            var empTypeQry = from e in db.Status
                             orderby e.EmployeeType.Name
                             select e.EmployeeType.Name;

            var unionQry = from u in db.Status
                             orderby u.UnionStatus.Name
                             select u.UnionStatus.Name;

            var overtimeQry = from o in db.Status
                             orderby o.OverTimeStatus.Name
                             select o.OverTimeStatus.Name;

            var compensationQry = from c in db.Compensations
                              orderby c.CompensationType.Name
                              select c.CompensationType.Name;


            deptList.AddRange(deptQry.Distinct());
            ViewBag.departmentType = new SelectList(deptList);

            bAreaList.AddRange(bAreaQry.Distinct());
            ViewBag.budgetAreaType = new SelectList(bAreaList);

            statusList.AddRange(statusQry.Distinct());
            ViewBag.statusType = new SelectList(statusList);

            lCompList.AddRange(lCompQry.Distinct());
            ViewBag.lCompType = new SelectList(lCompList);

            hCompList.AddRange(hCompQry.Distinct());
            ViewBag.hCompType = new SelectList(hCompList);

            empTypeList.AddRange(empTypeQry.Distinct());
            ViewBag.empType = new SelectList(empTypeList);

            unionList.AddRange(unionQry.Distinct());
            ViewBag.unionType = new SelectList(unionList);

            overtimeList.AddRange(overtimeQry.Distinct());
            ViewBag.overtimeType = new SelectList(overtimeList);

            compensationList.AddRange(compensationQry.Distinct());
            ViewBag.compensationType = new SelectList(compensationList);

            var employees = from e in db.Employees
                            select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
                                                                           || s.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!String.IsNullOrEmpty(departmentType))
            {
                employees = employees.Include(x => x.Careers.Select(d => d.Department))
                .Where(d => d.Careers.OrderByDescending(i=>i.EffectiveDate).Select(c=>c.Department.Name).FirstOrDefault() == departmentType);
            }

            if (!String.IsNullOrEmpty(budgetAreaType))
            {
                employees = employees.Include(x => x.Careers.Select(d => d.BudgetArea))
                .Where(d => d.Careers.OrderByDescending(i => i.EffectiveDate).Select(c => c.BudgetArea.Name).FirstOrDefault() == budgetAreaType);
            }

            if (!String.IsNullOrEmpty(statusType))
            {
                employees = employees.Include(x => x.EmployeeStatus.Select(d => d.EmployeeStatus))
                .Where(d => d.EmployeeStatus.OrderByDescending(i => i.EffectiveDate).Select(c => c.EmployeeStatus.Name).FirstOrDefault() == statusType);
            }

            if (!String.IsNullOrEmpty(lCompType))
            {
                employees = employees.Include(x => x.EmployeeStatus.Select(d => d.LegalCompany))
                .Where(d => d.EmployeeStatus.OrderByDescending(i => i.EffectiveDate).Select(c => c.LegalCompany.Name).FirstOrDefault() == lCompType);
            }

            if (!String.IsNullOrEmpty(hCompType))
            {
                employees = employees.Include(x => x.EmployeeStatus.Select(d => d.HeritageCompany))
                .Where(d => d.EmployeeStatus.OrderByDescending(i => i.EffectiveDate).Select(c => c.HeritageCompany.Name).FirstOrDefault() == hCompType);
            }

            if (!String.IsNullOrEmpty(empType))
            {
                employees = employees.Include(x => x.EmployeeStatus.Select(d => d.EmployeeType))
                .Where(d => d.EmployeeStatus.OrderByDescending(i => i.EffectiveDate).Select(c => c.EmployeeType.Name).FirstOrDefault() == empType);
            }

            if (!String.IsNullOrEmpty(unionType))
            {
                employees = employees.Include(x => x.EmployeeStatus.Select(d => d.UnionStatus))
                .Where(d => d.EmployeeStatus.OrderByDescending(i => i.EffectiveDate).Select(c => c.UnionStatus.Name).FirstOrDefault() == unionType);
            }
            if (!String.IsNullOrEmpty(overtimeType))
            {
                employees = employees.Include(x => x.EmployeeStatus.Select(d => d.OverTimeStatus))
                .Where(d => d.EmployeeStatus.OrderByDescending(i => i.EffectiveDate).Select(c => c.OverTimeStatus.Name).FirstOrDefault() == overtimeType);
            }
            if (!String.IsNullOrEmpty(compensationType))
            {
                employees = employees.Include(x => x.Compensations.Select(d => d.CompensationType))
                .Where(d => d.Compensations.Select(c => c.CompensationType.Name).Contains(compensationType));
            }
            if (!String.IsNullOrEmpty(startDate) || !String.IsNullOrEmpty(endDate))
            {
                DateTime dtS = Convert.ToDateTime(startDate);
                DateTime dtE = Convert.ToDateTime(endDate);
                employees = employees.Include(x => x.Compensations)
                .Where(d => d.Compensations.Any(b => b.EffectiveDate >= dtS &&
                b.EffectiveDate <= dtE));
            }

            return View(employees);
        }

        // GET: Search/Details/5
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

        // GET: Search/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Search/Create
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

        // GET: Search/Edit/5
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

        // POST: Search/Edit/5
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

        // GET: Search/Delete/5
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

        // POST: Search/Delete/5
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
