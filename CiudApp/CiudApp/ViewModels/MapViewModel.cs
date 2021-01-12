using CiudApp.Services;
using CiudApp.Views;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Maps;

namespace CiudApp.ViewModels
{
    class MapViewModel : BaseViewModel
    {
        #region Commands and Attributes
        IGoogleMapsApiService googleMapsApi = new GoogleMapsApiService();

        public ICommand GetPlacesCommand { get; set; }
        public ICommand ActualNameCommand { get; set; }


        string pickupText;
        public string PickupText
        {
            get
            {
                return pickupText;
            }

            set
            {
                pickupText = value;
                GetNotify(nameof(PickupText));
            }
        }

        #endregion
        //Functions:

        #region MapViewModel
        public MapViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            ActualNameCommand = new Command(async () => await GetActualName());
            GetPlacesCommand = new Command<string>(async (placeText) => await GetPlacesByName(placeText));
        }
        #endregion

        public async Task GetActualName()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium);
            var location = await Geolocation.GetLocationAsync(request);

            var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
            var placemark = placemarks?.FirstOrDefault();
            if (placemark != null)
            {
                PickupText = $"{placemark.FeatureName} {placemark.Thoroughfare}, {placemark.SubAdminArea} {placemark.CountryName}";
            }
            else
            {
                PickupText = string.Empty;

            }
        }

        public async Task GetPlacesByName(string placeText)
        {
            var places = await googleMapsApi.GetPlaces(placeText);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
    }
}
