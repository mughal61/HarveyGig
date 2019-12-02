using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarveyJobs.Models
{
    public class ScheduledJobDetails
    {
        public int JobsID { get; set; }
        public int AppID { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
        public string Day { get; set; }
        public string Success { get; set; }
        public Nullable<int> Files_DwUp { get; set; }
        public Nullable<int> Files_Sorted { get; set; }

    }
}