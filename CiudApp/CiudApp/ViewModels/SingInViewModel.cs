using CiudApp.Models;
using Prism.Commands;
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
    public class SingInViewModel : BaseViewModel
    {
        #region Commands and Attributes
        public DelegateCommand SingInCommand { get; }
        public ICommand GoToMainPageCommand { get; }
        public ICommand GoBackCommand { get; }

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

        public string password;
        public string Password
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

        public string confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return confirmPassword;
            }

            set
            {
                confirmPassword = value;
                GetNotify(nameof(ConfirmPassword));
            }
        }

        public string email;
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
                GetNotify(nameof(Email));
            }
        }

        public bool isChecked;
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }

            set
            {
                isChecked = value;
                GetNotify(nameof(IsChecked));
            }
        }
        #endregion

        //functions:

        #region SingInViewModel
        public SingInViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            SingInCommand = new DelegateCommand(Execute).ObservesCanExecute(() => IsChecked);
                //As I erased canExecute, this command can only have one ObservesCanExecute.
            GoToMainPageCommand = new Command(async () => await Navigate());
            GoBackCommand = new Command(async () => await GoBack());
        }
        #endregion

        private void Execute()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Password) &&
                !string.IsNullOrEmpty(confirmPassword) && !string.IsNullOrEmpty(Email))
            {
                if (Password.Equals(confirmPassword))
                {
                    //Send the data to the db.
                    GoToMainPageCommand.Execute(null);
                }
                else
                {
                    PageDialog.DisplayAlertAsync("No puede registrarse.", "Las contraseñas deben ser iguales",
                                                 "Ok");
                }
            }
            else
            {
                PageDialog.DisplayAlertAsync("No puede registrarse.", "Debe de llenar todos los campos",
                                             "Ok");
            }
        }

        public async Task Navigate()
        {
            User user = new User();
            user.Name = Name;
            user.Password = password;
            user.Email = Email;

            NavigationParameters parameter = new NavigationParameters();
            parameter.Add("user", user);

            await NavigationService.NavigateAsync($"/{Pages.MainPage}", parameter);
        }

        public async Task GoBack()
        {
            await NavigationService.GoBackAsync();
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
    }
}
