using System;
using System.Collections.Generic;
using System.Text;

namespace CiudApp.Models
{
    class Report
    {
        public String Location { get; set; }
        public String Title { get; set; }
        public String Subtitle { get; set; }
        public Uri Image { get; set; } //provisional
        public String Description { get; set; }

        //Functions:
        #region Report
        public Report(String location, String title, String subtitle,
                      Uri image, String description)
        {
            Location = location;
            Title = title;
            Subtitle = subtitle;
            Image = image;
            Description = description;
        }
        #endregion
    }
}
