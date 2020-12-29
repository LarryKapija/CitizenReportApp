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
    public class LogInViewModel : BaseViewModel
    {
        #region Commands and Atributtes
        public ICommand GoogleLogIn { get; }

        public String label;
        public String Label
        {
            get
            {
                return label;
            }

            set
            {
                label = value;
                GetNotify(nameof(Label));
            }
        }

        public Uri img;
        public Uri Image
        {
            get
            {
                return img;
            }

            set
            {
                img = value;
                GetNotify(nameof(Image));
            }
        }

        IPageDialogService PageDialog; //For displaying alert.

        User user;
        #endregion

        //Functions:

        #region LogInViewModel
        public LogInViewModel(INavigationService navigationService, IPageDialogService pageDialog) : base(navigationService)
        {
            PageDialog = pageDialog;
            user = new User();
            GoogleLogIn = new Command(async () => await GoogleCheck());
        }
        #endregion

        #region GoogleCheck
        /// <summary>
        /// Function that will log in the user with his or her google account.
        /// </summary>
        public async Task GoogleCheck()
        {
            CrossGoogleClient.Current.OnLogin += OnLogInCompleted;
            try
            {
                await CrossGoogleClient.Current.LoginAsync();
                Label = user.Name;
                Image = user.Picture;
            }
            catch (Exception e)
            {
                await PageDialog.DisplayAlertAsync("Lo sentimos, no se puede completar la acción",
                                            $"{e}", "Cancelar");
            }

        }
        #endregion

        private void OnLogInCompleted(object sender, GoogleClientResultEventArgs<GoogleUser> loginEventArgs)
        {
            if(loginEventArgs.Data != null)
            {
                GoogleUser googleUser = loginEventArgs.Data;
                user.Name = googleUser.Name;
                user.Picture = googleUser.Picture;
            }
            
            CrossGoogleClient.Current.OnLogin -= OnLogInCompleted;
        }

    }
}
