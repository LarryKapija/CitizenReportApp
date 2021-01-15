using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CiudApp.Views.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataEntry : Grid
    {
        //public string Text
        //{
        //    get
        //    {
        //        return (string)GetValue(TextProperty);
        //    }
        //    set
        //    {
        //        SetValue(TextProperty, value); 
        //    }
        //}

        //public static BindableProperty TextProperty = BindableProperty.Create(
        //    propertyName: "Text",
        //    returnType: typeof(string),
        //    declaringType: typeof(DataEntry),
        //    defaultValue: string.Empty,
        //    defaultBindingMode: BindingMode.OneWay,
        //    propertyChanged: TextPropertyChanged);
        //private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        //{
        //    DataEntry dataEntry = bindable as DataEntry;
        //    dataEntry.entry.Text = $"{newValue}";
        //}

        public DataEntry()
        {
            InitializeComponent();
        }

    }
}