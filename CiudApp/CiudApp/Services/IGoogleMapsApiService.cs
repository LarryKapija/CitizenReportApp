using CiudApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CiudApp.Services
{
    public interface IGoogleMapsApiService
    {
        Task<GooglePlaceAutoCompleteResult> GetPlaces(string text);
        Task<GooglePlace> GetPlaceDetails(string placeId);
    }
}
