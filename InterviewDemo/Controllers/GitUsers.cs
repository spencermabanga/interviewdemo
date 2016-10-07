using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewDemo.Controllers
{

    public class GitUsers
    {
        public string id { get; set; }
        public string position_title { get; set; }
        public string organization_name { get; set; }
        public string rate_interval_code { get; set; }
        public string minimum { get; set; }
        public string maximum { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public locations locations { get; set; }
        public string url { get; set; }
    }

    public class locations : List<string>
    {

    }

    public class GitUsersList : List<GitUsers>
    {

    }
}