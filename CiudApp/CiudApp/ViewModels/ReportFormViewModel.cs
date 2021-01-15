using CiudApp.Models;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CiudApp.ViewModels
{ 
    class ReportFormViewModel : BaseViewModel
    {
        #region Commands and Attributes:
        public ICommand FrameCommand { get; set; }
        public ICommand ImageCommand { get; set; }

        public ICommand GetLocationCommand { get; set; }

        public bool isEnable;
        public bool IsEnable
        {
            get
            {
                return isEnable;
            }

            set
            {
                isEnable = value;
                GetNotify(nameof(IsEnable));
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
                IsEnable = value;
            }
        }

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

        public String subtitle;
        public String Subtitle
        {
            get
            {
                return subtitle;
            }
            set
            {
                subtitle = value;
                GetNotify(nameof(Subtitle));
            }
        }

        public String description;
        public String Description
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

        public string location;
        public string Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
                GetNotify(nameof(Location));
            }
        }

        public FileResult Image { get; set; }

        readonly IList<Report> reportList = new List<Report>();
        #endregion

        //Functions:

        #region ReportViewModel
        public ReportFormViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            IsEnable = false;
            Image = new FileResult("user_picture.png");
            GetLocationCommand = new Command(async () => await Navigate());
            ImageCommand = new Command(async () => await AddPhoto());
            FrameCommand = new Command(FrameTapped);
        }
        #endregion

        #region Navigate
        public async Task Navigate()
        {
            await NavigationService.NavigateAsync($"{Pages.MapPage}");
        }
        #endregion

        #region AddMedia
        async private Task AddPhoto()
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
            if(MediaPicker.IsCaptureSupported)
            {
                Image = await MediaPicker.CapturePhotoAsync();
            }
            else
            {
                await PageDialog.DisplayAlertAsync("ERROR", "Dispositivo no tiene camara disponible", "OK");
            }
           

        }

        async Task LoadPhotoAsync()
        {
            Image = await MediaPicker.PickPhotoAsync();

        }


        #endregion

        #region FrameTapped
        private void FrameTapped()
        {

            if(Image.FullPath != "user_picture.png") //if it's different to the default image
            {
                bool reportCreated = true;
                Report report = new Report()
                {
                    Location = Location,
                    Title = Title,
                    Subtitle = Subtitle,
                    Image = Image.FullPath,
                    Description = Description

                };
                reportList.Add(report);

                PageDialog.DisplayAlertAsync("El reporte ha sido creado exitosamente.",
                                             "", "Ok");

                //Wiping out the elements of the Report view:
                Title = "";
                Subtitle = "";
                Description = "";

                NavigationParameters parameters = new NavigationParameters();
                parameters.Add("report", report);
                parameters.Add("reportCreated", reportCreated);

                NavigationService.GoBackAsync(parameters);
            }
            else
            {
                PageDialog.DisplayAlertAsync("No se puede completar el reporte",
                                             "Debe de agregar una imagen", "Ok");
            }
            
        }
        #endregion

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.Count > 0)
            {
                Location = parameters.GetValue<string>("location");
            }
        }
    }
}
