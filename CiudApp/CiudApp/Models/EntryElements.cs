using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CiudApp.Models
{
    public class EntryElements
    {
        public string Title { get; }
        public string ImageSource { get; }
        public string Placeholder { get; }
        //public string Text { get; set; }
        public bool IsPassword { get; set; }

        public EntryElements(string title, string imageSource, string placeholder,
                             bool isPassword)
        {
            Title = title;
            ImageSource = imageSource;
            Placeholder = placeholder;
            IsPassword = IsPassword;
        }

    }
}
