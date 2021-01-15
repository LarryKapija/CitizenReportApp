using CiudApp.Models;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CiudApp.ViewModels
{
    public class AccountConfigurationViewModel : BaseViewModel
    {
        #region Commands and Attributes:
        public ICommand ImageCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public string image;
        public string Image
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

        private FileResult ImageFile { get; set; }

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

        public string phone;
        public String Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
                GetNotify(nameof(Phone));
            }
        }

        public string webSite;
        public string WebSite
        {
            get
            {
                return webSite;
            }

            set
            {
                webSite = value;
                GetNotify(nameof(WebSite));
            }
        }

        public string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                GetNotify(nameof(Description));
            }
        }

        public string address;
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
                GetNotify(nameof(Address));
            }
        }
        #endregion

        //Functions:

        #region AccountConfigurationViewModel
        public AccountConfigurationViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            Image = "user_picture.png";
            ImageCommand = new Command(async () => await AddPhoto());
            SaveCommand = new Command(async () => await NavigateTo());
        }
        #endregion

        #region AddMedia
        private async Task AddPhoto()
        {
            string Action, TakePhoto, ChoosePhoto;
            TakePhoto = "Tomar foto";
            ChoosePhoto = "Elegir una de la galeria";

            Action = await App.Current.MainPage.DisplayActionSheet("Subir foto", "Cancelar", null, $"{TakePhoto}", $"{ChoosePhoto}");

            if (Action == TakePhoto)
            {
                await TakePhotoAsync();
            }
            else if (Action == ChoosePhoto)
            {
                await LoadPhotoAsync();
            }
        }

        async Task TakePhotoAsync()
        {
            if (MediaPicker.IsCaptureSupported)
            {
                ImageFile = await MediaPicker.CapturePhotoAsync();
                Image = ImageFile.FullPath;
            }
            else
            {
                await PageDialog.DisplayAlertAsync("ERROR", "Dispositivo no tiene camara disponible", "OK");
            }


        }

        async Task LoadPhotoAsync()
        {
            ImageFile = await MediaPicker.PickPhotoAsync();
            Image = ImageFile.FullPath;
        }
        #endregion

        public async Task NavigateTo()
        {
            NavigationParameters parameter = new NavigationParameters();
            parameter.Add("name", Name);
            parameter.Add("email", Email);
            parameter.Add("phone", Phone);
            parameter.Add("webSite", WebSite);
            parameter.Add("description", Description);
            parameter.Add("address", Address);
            parameter.Add("edit", true);

            await PageDialog.DisplayAlertAsync("Los cambios han sido guardados", "", "Ok");
            await NavigationService.SelectTabAsync(Pages.HomePage, parameter);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
    }
}
