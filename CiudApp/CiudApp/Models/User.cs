using System;
using System.Collections.Generic;
using System.Text;

namespace CiudApp.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public Uri Picture { get; set; }

        public string Password { get; set; }
        public int ReportCount { get; set; }

        public string PhoneNumber { get; set; }
        public string WebSite { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        //public IList<Report> ReportList {get; set;}
        //public int EventCount {get; set;}
    }
}
