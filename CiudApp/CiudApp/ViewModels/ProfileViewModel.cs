using CiudApp.Models;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiudApp.ViewModels
{
    class ProfileViewModel : BaseViewModel
    {
        #region Command
        public ICommand ConfigurationCommand { get; }
        #endregion

        //Functions:
        #region ProfileViewModel
        public ProfileViewModel(INavigationService navigationService) : base(navigationService)
        {
            ConfigurationCommand = new Command(async (page) => await Navigate(page.ToString()));
        }
        #endregion

        #region Navigate
        async Task Navigate(string page)
        {
            await NavigationService.NavigateAsync(page);
        }
        #endregion
    }
}
