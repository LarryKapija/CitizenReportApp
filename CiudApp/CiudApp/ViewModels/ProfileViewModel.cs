using CiudApp.Models;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiudApp.ViewModels
{
    class ProfileViewModel : BaseViewModel
    {

        User user;
        #region Command
        public ICommand ConfigurationCommand { get; }
        #endregion

        #region ProfileViewModel
        public ProfileViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            ConfigurationCommand = new Command(async (page) => await Navigate(page.ToString()));
        }
        #endregion

        #region Navigate
        async Task Navigate(string page)
        {
           // await NavigationService.NavigateAsync(page);
        }
        #endregion
    }
}
