using CiudApp.Models;
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
        public ICommand GetPlacesDetailCommand { get; set; }
        public ICommand ActualNameCommand { get; set; }
        public ICommand FocusOriginCommand { get; set; }
        public ICommand SearchCommand { get; set; }

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
                //GetNotify(nameof(PickupText));
                if (!string.IsNullOrEmpty(pickupText))
                {
                    isPickupFocused = true;
                    GetPlacesCommand.Execute(pickupText);
                }
            }
        }

        string latitude;
        string longitude;
        string destinationLatitude;
        string destiantionLongitude;

        GooglePlaceAutoCompletePrediction placeSelected;
        public GooglePlaceAutoCompletePrediction PlaceSelected
        {
            get
            {
                return placeSelected;
            }
            set
            {
                placeSelected = value;
                if (placeSelected != null)
                    GetPlacesDetailCommand.Execute(placeSelected);
            }
        }

        public ObservableCollection<GooglePlaceAutoCompletePrediction> Places { get; set; }
        public ObservableCollection<GooglePlaceAutoCompletePrediction> RecentPlaces { get; set; }

        public bool ShowRecentPlaces { get; set; }
        bool isPickupFocused = true;

        string originText;
        public string OriginText
        {
            get
            {
                return originText;
            }
            set
            {
                originText = value;
                if (!string.IsNullOrEmpty(originText))
                {
                    isPickupFocused = false;
                    GetPlacesCommand.Execute(originText);
                }
            }
        }
        #endregion
        //Functions:

        #region MapViewModel
        public MapViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            ActualNameCommand = new Command(async () => await GetActualName());
            GetPlacesCommand = new Command<string>(async (placeText) => await GetPlacesByName(placeText));
            GetPlacesDetailCommand = new Command<GooglePlaceAutoCompletePrediction>(async (param) => await GetPlacesDetail(param));
            SearchCommand = new Command(async () => await NavigateTo());
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
            var placeResult = places.AutoCompletePlaces;
            if (placeResult != null && placeResult.Count > 0)
                Places = new ObservableCollection<GooglePlaceAutoCompletePrediction>(placeResult);

            ShowRecentPlaces = (placeResult == null || placeResult.Count == 0);
        }

        public async Task GetPlacesDetail(GooglePlaceAutoCompletePrediction placeA)
        {
            var place = await googleMapsApi.GetPlaceDetails(placeA.PlaceId);
            if(place != null)
            {
                if (isPickupFocused)
                {
                    PickupText = place.Name;
                    latitude = $"{place.Latitude}";
                    longitude = $"{place.Longitude}";
                    isPickupFocused = false;
                    FocusOriginCommand.Execute(null);
                }
                else
                {
                    destinationLatitude = $"{place.Latitude}";
                    destiantionLongitude = $"{place.Longitude}";

                    RecentPlaces.Add(placeA);

                    //En chequeo todavia
                    await NavigationService.GoBackAsync();
                    CleanFields();
                }
            }
        }

        void CleanFields()
        {
            pickupText = OriginText = string.Empty;
            ShowRecentPlaces = true;
            PlaceSelected = null;
        }

        public async Task NavigateTo()
        {
            await NavigationService.NavigateAsync(Pages.SearchPage);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
    }
}
