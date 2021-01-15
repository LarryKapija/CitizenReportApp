using Prism.Navigation;
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
        #endregion

        //Functions:

        #region AccountConfigurationViewModel
        public AccountConfigurationViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            Image = "user_picture.png";
            ImageCommand = new Command(async () => await AddPhoto());
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

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
    }
}
