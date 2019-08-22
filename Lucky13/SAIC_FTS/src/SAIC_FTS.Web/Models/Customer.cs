using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAIC_FTS.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactNo { get; set; }
        public string ContactPerson { get; set; }
        public string Description { get; set; }
    }
}