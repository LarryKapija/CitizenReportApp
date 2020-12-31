using CiudApp.Models;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiudApp.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        #region Commands
        public ICommand NavegateCommand { get; }
        #endregion

        //Functions:
        #region MainViewModel
        public MainViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService,pageDialogService)
        {
            NavegateCommand = new Command(async (page) => await Navigate(page.ToString()));
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
