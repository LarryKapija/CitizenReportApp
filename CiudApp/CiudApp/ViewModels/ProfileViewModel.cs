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
        #region Command
        public ICommand ConfigurationCommand { get; }
        #endregion

        #region ProfileViewModel
        public ProfileViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            ConfigurationCommand = new Command(async () => await Navigate());
        }
        #endregion

        #region Navigate
        async Task Navigate()
        {
            await NavigationService.NavigateAsync(Pages.AccountConfigurationPage);
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
