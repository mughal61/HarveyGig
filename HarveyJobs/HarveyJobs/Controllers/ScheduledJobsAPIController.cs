using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HarveyJobs.Models;

namespace HarveyJobs.Controllers
{
    public class ScheduledJobsController : ApiController
    {
        HarveyJobsEntities db = new HarveyJobsEntities();

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            ScheduledJobDetails res = new ScheduledJobDetails();
            var jobsList = (List<tbScheduledJob>)db.tbScheduledJobs.ToList();
            var obj = jobsList.FirstOrDefault(x => x.JobsID == id);
            if (obj != null)
            {
                res.JobsID = obj.JobsID;
                res.AppID = obj.AppID;
                res.Time = obj.Time;
                res.Day = obj.Day;
                res.Success = obj.Success;
                res.Files_DwUp = obj.Files_DwUp;
                res.Files_Sorted = obj.Files_Sorted;
            }            
            else if (obj == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }

            return Request.CreateResponse(HttpStatusCode.OK, res);
        }
    }
}