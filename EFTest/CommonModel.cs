using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFTest
{
    public class CommonModel
    {
        public string ActionUser { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set;}
        public string ActionIP { get; set; }
        public string UpdatedIP { get; set; }
    }

    public class CommonAPIResponseModel
    {
        public string status { get; set; }
        public object data { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }
}