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
        public Uri image;
        public Uri Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
                GetNotify(nameof(Image));
            }
        }



        #region Commands
        public ICommand NavegateCommand { get;  }
        #endregion

        //Functions:
        #region HomeViewModel
        public HomeViewModel(INavigationService navigationService, IPageDialogService pageDialogService, INavigatedAware navigatedAware) : base(navigationService, pageDialogService, navigatedAware)
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
            User = parameters.GetValue<User>("user");
            Title = $"Bienvenido {User.Name}";
            Image = User.Picture;
        }
        #endregion

        
    }
}
