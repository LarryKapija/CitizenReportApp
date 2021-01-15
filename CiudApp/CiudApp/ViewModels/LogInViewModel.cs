using CiudApp.Models;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiudApp.ViewModels
{
    public class LogInViewModel : BaseViewModel
    {
        #region Commands and Atributtes
        public ICommand GoogleLogIn { get; }
        public ICommand LogInCommand { get; }
        public ICommand SignInCommand { get; }

        //public EntryElements NameElement { get; set; }
        //public EntryElements PasswordElement { get; set; }

        internal Models.User user { get; set; }
        
        public string name;
        public string Name
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

        public String password;
        public String Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                GetNotify(nameof(Password));
            }
        }
        #endregion

        #region LogInViewModel
        public LogInViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            //NameElement = new EntryElements("Nombre:", "Icons/user_icon.png", "Ingrese su nombre aquí", false);
            //PasswordElement = new EntryElements("Contraseña:", "Icon/security_icon.png", "Ingrese su contraseña aquí", true);

            user = new Models.User();
            GoogleLogIn = new Command(async () => await GoogleCheck());
            LogInCommand = new Command(async () => await LogIn());
            SignInCommand = new Command(async () => await NavigateTo());
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

                //Label = user.Name;
                //Image = user.Picture;

                NavigationParameters parameters = new NavigationParameters();
                parameters.Add("user", user);

                await NavigationService.NavigateAsync($"/{Pages.MainPage}", parameters);
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
                await PageDialog.DisplayAlertAsync("Error", "Error desconocido. \nFavor llamar al 111-111-1111", "OK");
            }
            catch (GoogleClientNotInitializedErrorException )
            {
                await PageDialog.DisplayAlertAsync("Error", "Error desconocido. \nFavor llamar al 222-222-2222", "OK");
            }
            catch (GoogleClientBaseException )
            {
                await PageDialog.DisplayAlertAsync("Error", "Error desconocido. \nFavor llamar al 888-888-8888", "OK");
            }

        }

        private async void OnLogInCompleted(object sender, GoogleClientResultEventArgs<Plugin.GoogleClient.Shared.GoogleUser> loginEventArgs)
        {
            if (loginEventArgs.Data != null)
            {
                Plugin.GoogleClient.Shared.GoogleUser googleUser = loginEventArgs.Data;
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

        #region LogIn
        public async Task LogIn()
        {
            if(!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Password))
            {
                user.Name = Name;
                NavigationParameters parameter = new NavigationParameters();
                parameter.Add("user", user);
                await NavigationService.NavigateAsync($"/{Pages.MainPage}", parameter);
            }
            else
            {
                await PageDialog.DisplayAlertAsync("No se puede completar la acción",
                                             "Necesita completar todos los campos primero", "Ok");
            }
        }
        #endregion


        public async Task NavigateTo()
        {
            await NavigationService.NavigateAsync(Pages.SingIn);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
    }
}
