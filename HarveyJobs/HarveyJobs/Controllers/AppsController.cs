using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HarveyJobs.Models;

namespace HarveyJobs.Controllers
{
    [Authorize]
    public class AppsController : Controller
    {
        // GET: Apps

        HarveyJobsEntities db = new HarveyJobsEntities();

        [AllowAnonymous]
        public ActionResult ListApps()
        {
            return View(db.tbAppInfoes.ToList());
        }
    }
}