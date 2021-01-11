using CiudApp.Services;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace CiudApp.ViewModels
{
    class MapViewModel : BaseViewModel
    {
        #region Commands and Attributes
        IGoogleMapsApiService googleMapsApi = new GoogleMapsApiService();
        
        public ICommand GetPlacesCommand { get; set; }
        public ICommand GetLocationNameCommand { get; set; }

        bool isPickupFocused = true;

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
                if (!string.IsNullOrEmpty(pickupText))
                {
                    isPickupFocused = false;
                    GetPlacesCommand.Execute(pickupText);
                }
            }
        }
        #endregion
        //Functions:

        #region MapViewModel
        public MapViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {

            GetLocationNameCommand = new Command<Position>(async (position) => await GetLocationName(position));
            GetPlacesCommand = new Command<string>(async (placeText) => await GetPlacesByName(placeText));
        }
        #endregion

        public async Task GetLocationName(Position position)
        {
            try
            {
                var placemarks = await Geocoding.GetPlacemarksAsync(position.Latitude, position.Longitude);
                var placemark = placemarks?.FirstOrDefault();
                if (placemark != null)
                {
                    PickupText = placemark.FeatureName;
                }
                else
                {
                    PickupText = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        public async Task GetPlacesByName(string placeText)
        {
            var places = await googleMapsApi.GetPlaces(placeText);
        }

        #region GetLocation
        /// <summary>
        /// This function will try a request to know the user current location to start the map there.
        /// </summary>
        public async void GetLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest()
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }

                //Position position = new Position(location.Latitude, location.Longitude);
                //MapSpan mapSpan = new MapSpan(position, 0.1, 0.1);

                //Latitude = location.Latitude;
                //Longitude = location.Longitude;
            } catch (Exception e) { }
        }
        #endregion

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
    }
}
