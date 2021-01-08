using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace CiudApp.ViewModels
{
    class MapViewModel : BaseViewModel
    {
        #region Commands and Attributes
        public Double latitude;
        public Double Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                latitude = value;
                GetNotify(nameof(Latitude));
            }
        }

        public Double longitude;
        public Double Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                longitude = value;
                GetNotify(nameof(Longitude));
            }
        }
        #endregion
        //Functions:

        #region MapViewModel
        public MapViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            
            GetLocation();
        }
        #endregion

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

                Position position = new Position(location.Latitude, location.Longitude);
                MapSpan mapSpan = new MapSpan(position, 0.1, 0.1);

                Latitude = location.Latitude;
                Longitude = location.Longitude;
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
