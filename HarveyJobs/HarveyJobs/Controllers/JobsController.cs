using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HarveyJobs.Models;

namespace HarveyJobs.Controllers
{
    [Authorize(Roles ="Admin")]
    public class JobsController : Controller
    {
        // GET: Jobs
        HarveyJobsEntities db = new HarveyJobsEntities();


        [AllowAnonymous]
        public ActionResult ListJobs()
        {
            return View(db.tbScheduledJobs.ToList());
        }

        [AllowAnonymous]
        public ActionResult ListScheduledJobs()
        {
            return View(db.tbScheduledJobs.ToList());
        }

        [AllowAnonymous]
        public ActionResult ShowScheduledJobsTable()
        {
            List<string> days = new List<string>();
            days.Add("Sunday");
            days.Add("Monday");
            days.Add("Tuesday");
            days.Add("Wednesday");
            days.Add("Thursday");
            days.Add("Friday");
            days.Add("Saturday");
            ViewData["Days"] = days.ToList();
            ViewData["AppsInfo"] = db.tbAppInfoes.ToList();
            return View(db.tbScheduledJobs);
        }

        [HttpGet]
        public ActionResult CreateScheduledJob()
        {
            ViewBag.AppsInfoDDL = new SelectList(db.tbAppInfoes.ToList(), "AppID", "AppName");
            return View();
        }

        [HttpPost]
        public ActionResult CreateScheduledJob(FormCollection formCollection)
        {
            tbScheduledJob _tbScheduledJob = new tbScheduledJob();
            _tbScheduledJob.AppID = Convert.ToInt32(formCollection["AppsInfoDDL"]);
            _tbScheduledJob.Day = formCollection["Day"];
            //_tbScheduledJob.Time = Convert.ToDateTime(formCollection["Time"]);
            _tbScheduledJob.Success = formCollection["Success"];
            _tbScheduledJob.Files_DwUp = Convert.ToInt32(formCollection["Files_DwUp"]);
            _tbScheduledJob.Files_Sorted = Convert.ToInt32(formCollection["Files_Sorted"]);
            db.tbScheduledJobs.Add(_tbScheduledJob);
            db.SaveChanges();
            return RedirectToAction("ListScheduledJobs");
            //return View("ListScheduledJobs");
        }
    }
}