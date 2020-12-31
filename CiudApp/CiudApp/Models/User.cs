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
    }
}
