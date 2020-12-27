using CiudApp.Models;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiudApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Commands
        public ICommand NavegateCommand { get;  }
        #endregion

        //Functions:
        #region HomeViewModel
        public HomeViewModel(INavigationService navigationService) : base(navigationService)
        {
            //_navigationService = navigationService;

            NavegateCommand = new Command(async () => await Navigate());
        }
        #endregion

        #region Navigate
        async Task Navigate()
        {
            await NavigationService.NavigateAsync("Profile");
        }
        #endregion
    }
}
