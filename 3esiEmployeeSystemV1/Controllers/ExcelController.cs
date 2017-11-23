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
    public class ExcelController : Controller
    {

        public ActionResult ExportCareersToExcel()
        {
            var gv = new GridView();
            gv.DataSource = ReportingHelpers.GetCareerList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=CareersReportExcel.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");
        }

        public ActionResult ExportStatusToExcel()
        {
            var gv = new GridView();
            gv.DataSource = ReportingHelpers.GetStatusList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=StatusReportExcel.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");
        }

        public ActionResult ExportCompensationsToExcel()
        {
            var gv = new GridView();
            gv.DataSource = ReportingHelpers.GetCompensationList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=CompensationsReportExcel.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");
        }

        public ActionResult ExportBenefitsToExcel()
        {
            var gv = new GridView();
            gv.DataSource = ReportingHelpers.GetBenefitList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=BenefitsReportExcel.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");
        }

        public ActionResult ExportTrainingsToExcel()
        {
            var gv = new GridView();
            gv.DataSource = ReportingHelpers.GetTrainingList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=TrainingsReportExcel.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");
        }

        public ActionResult ExportEmployeesToExcel()
        {
            var gv = new GridView();
            gv.DataSource = ReportingHelpers.GetEmployeeList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=EmployeesReportExcel.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);
            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return View("Index");
        }

        // GET: Excel
        public ActionResult Index()
        {
            return View();
        }
    }
}