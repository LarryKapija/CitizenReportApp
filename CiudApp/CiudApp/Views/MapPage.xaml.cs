using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CiudApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        #region Command and Attributes:
        public ICommand GetActualLocationCommand
        {
            get { return (ICommand)GetValue(GetActualLocationCommandProperty);  }
            set { SetValue(GetActualLocationCommandProperty, value);  }
        }

        public static readonly BindableProperty GetActualLocationCommandProperty =
                      BindableProperty.Create(nameof(GetActualLocationCommand), typeof(ICommand),
                                              typeof(MapPage), null, BindingMode.TwoWay);
        #endregion

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetActualLocationCommand.Execute(null);
        }

        public MapPage()
        {
            InitializeComponent();
            GetActualLocationCommand = new Command(async () => await GetActualLocation());
        }

        public async Task GetActualLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(
                        new Position(location.Latitude, location.Longitude), Distance.FromMiles(0.3)));

                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Error", "Unable to get actual location", "Ok");
            }
        }
    }
}