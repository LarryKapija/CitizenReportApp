using CiudApp.Models;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiudApp.ViewModels
{
    public class HomeViewModel : BaseViewModel, INavigatedAware
    {
        User user { get; }

        public String title;
        public String Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
                GetNotify(nameof(Title));
            }
        }
        public String Name { get; set; }

        public LogInViewModel logIn;

        


        #region Commands
        public ICommand NavegateCommand { get;  }
        #endregion

        //Functions:
        #region HomeViewModel
        public HomeViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            NavegateCommand = new Command(async () => await Navigate());
        }


        #endregion

        #region Navigate
        async Task Navigate()
        {
            await NavigationService.NavigateAsync(Pages.ProfilePage);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Name = parameters.GetValue<String>("name");
            Title = $"Bienvenido {Name.Substring(0, 6)}";
        }
        #endregion

        
    }
}
