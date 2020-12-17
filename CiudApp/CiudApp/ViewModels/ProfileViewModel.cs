using CiudApp.Models;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiudApp.ViewModels
{
    class ProfileViewModel
    {
        
        public INavigationService _navigationService;

        public ProfileViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ConfigurationCommand = new Command(async (page) => await Navigation(page.ToString()));
        }

        #region Command
        public ICommand ConfigurationCommand{get;}
        #endregion

        #region Functions
        async Task Navigation(string page)
        {
            await _navigationService.NavigateAsync(page);
        }
        #endregion
    }
}
