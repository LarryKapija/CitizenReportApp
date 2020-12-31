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

        #region Just for the example
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
        #endregion

        internal User user { get; set; }
        #endregion


        #region LogInViewModel
        public LogInViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService,pageDialogService)
        {
             user = new User();
            GoogleLogIn = new Command(async () => await GoogleCheck());
        }
        #endregion

        #region GoogleCheck and OnLogInCompleted
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
                await NavigationService.NavigateAsync($"/Home");
            }
            catch (GoogleClientSignInNetworkErrorException )
            {
                await PageDialog.DisplayAlertAsync("Error","Error de conexion, favor intentelo nuevamente." , "OK");
            }
            catch (GoogleClientSignInCanceledErrorException )
            {
                await PageDialog.DisplayAlertAsync("Error", "Solicitud cancelada", "OK");
            }
            catch (GoogleClientSignInInvalidAccountErrorException )
            {
                await PageDialog.DisplayAlertAsync("Error", "Cuenta invalida.", "OK");
            }
            catch (GoogleClientSignInInternalErrorException )
            {
                await PageDialog.DisplayAlertAsync("Error", "Error desconocido. \nFavor llamar al 888-888-8888", "OK");
            }
            catch (GoogleClientNotInitializedErrorException )
            {
                await PageDialog.DisplayAlertAsync("Error", "Error desconocido. \nFavor llamar al 888-888-8888", "OK");
            }
            catch (GoogleClientBaseException )
            {
                await PageDialog.DisplayAlertAsync("Error", "Error desconocido. \nFavor llamar al 888-888-8888", "OK");
            }

        }

        private async void OnLogInCompleted(object sender, GoogleClientResultEventArgs<GoogleUser> loginEventArgs)
        {
            if (loginEventArgs.Data != null)
            {
                GoogleUser googleUser = loginEventArgs.Data;
                user.Name = googleUser.Name;
                user.GivenName = googleUser.GivenName;
                user.FamilyName = googleUser.FamilyName;
                user.Email = googleUser.Email;
                user.Picture = googleUser.Picture;
            }
            else
            {
                await PageDialog.DisplayAlertAsync("Error", loginEventArgs.Message, "OK");
            }
            CrossGoogleClient.Current.OnLogin -= OnLogInCompleted;
        }
        #endregion
    }
}
