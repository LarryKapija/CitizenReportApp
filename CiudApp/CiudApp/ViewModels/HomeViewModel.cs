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

        #region Commands
        public ICommand NavegateCommand { get;  }
        #endregion
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
        public User User { get; set; }

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
        #endregion

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {

        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if(parameters.Count == 2)
            {
                if (parameters.GetValue<bool>("reportCreated"))
                {
                    //Change the frame of the newest report.
                    Title = "El reporte ha sido creado";
                }
            }
            else
            {
                //Executed when the user come from the Log In.
                User = parameters.GetValue<User>("user");
                Title = $"Bienvenido {User.Name}";
            }
        }

    }
}
