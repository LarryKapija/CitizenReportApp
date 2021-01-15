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
        public DataEntry()
        {
            InitializeComponent();
        }
    }
}