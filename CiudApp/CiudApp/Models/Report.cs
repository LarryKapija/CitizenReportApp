using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace CiudApp.Models
{
    class Report
    {
        public String Location { get; set; }
        public String Title { get; set; }
        public String Subtitle { get; set; }
        public FileResult Image { get; set; } //provisional
        public String Description { get; set; }
        public short Status { get; set; }

        //Functions:
        #region Report
        public Report(String location, String title, String subtitle,
                      FileResult image, String description)
        {
            Location = location;
            Title = title;
            Subtitle = subtitle;
            Image = image;
            Description = description;
            Status = 0;
        }
        #endregion

        #region ChangeStatus
        /// <summary>
        /// This function will work if the authority in charge of getting the
        /// problem of the report solve wants to show the progress so far.
        /// </summary>
        /// <param name="newStatus">
        ///     Wich porcentage has grown. Needs to be >= 100.
        /// </param>
        public void ChangeStatus(short newStatus)
        {
            if (newStatus > Status && newStatus < 101)
                Status = newStatus;
        }
        #endregion
    }
}
