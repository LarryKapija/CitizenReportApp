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
    public class HomeViewModel : BaseViewModel
    {
        User user { get; }

        public String name;
        public String Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                GetNotify(nameof(Name));
            }
        }

        public LogInViewModel logIn;

        


        #region Commands
        public ICommand NavegateCommand { get;  }
        #endregion

        //Functions:
        #region HomeViewModel
        public HomeViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            //_navigationService = navigationService;
            //Name = logIn.user.Name;
            NavegateCommand = new Command(async () => await Navigate());
        }


        #endregion

        #region Navigate
        async Task Navigate()
        {
            await NavigationService.NavigateAsync(Pages.ProfilePage);
        }
        #endregion
    }
}
