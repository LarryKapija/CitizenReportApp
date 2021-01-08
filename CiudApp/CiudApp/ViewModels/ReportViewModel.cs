using CiudApp.Models;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiudApp.ViewModels
{
    public class ReportViewModel : BaseViewModel
    {
        public ICommand NavigationCommand { get; }

        public async Task Navigate()
        {
            await NavigationService.NavigateAsync(Pages.ReportForm);
        }

        public ReportViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            NavigationCommand = new Command(async () => await Navigate());
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
 
}
