using CiudApp.Models;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiudApp.ViewModels
{
    public class HomeViewModel
    {
        public INavigationService _navigationService;
        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavegateCommand = new Command(async () => await Navigate());
        }


        #region Commands
        public ICommand NavegateCommand { get;  }
        #endregion

        #region Functions
        async Task Navigate()
        {
            await _navigationService.NavigateAsync("Profile");
        }
        #endregion
    }
}
