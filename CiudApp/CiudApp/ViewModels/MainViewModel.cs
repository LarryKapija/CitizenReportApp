using CiudApp.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiudApp.ViewModels
{
    class MainViewModel
    {
        
        public INavigationService _navigationService;
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavegateCommand = new Command(async (pagina) => await Navigate(pagina.ToString()));
        }


        #region Commands
        public ICommand NavegateCommand { get; }
        #endregion

        #region Functions
        async Task Navigate(string page)
        {
            await _navigationService.NavigateAsync(page);
        }
        #endregion
    }
}
