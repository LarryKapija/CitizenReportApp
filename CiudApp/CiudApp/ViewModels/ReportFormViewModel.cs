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

        public FileResult Image { get; set; }

        readonly IList<Report> reportList = new List<Report>();
        #endregion

        //Functions:

        #region ReportViewModel
        public ReportFormViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            IsEnable = false;
            ImageCommand = new Command(async () => await AddMedia());
            //FrameCommand = new Command(FrameTapped);
        }
        #endregion

        #region AddMedia
        async private Task AddMedia()
        {

            string Action, Photo, Video;
            Photo = "Subir Foto";
            Video = "Subir Video";

            Action = await App.Current.MainPage.DisplayActionSheet("Elegir Media", "Cancelar", null, $"{Photo}", $"{Video}");

            if (Action == Photo)
            {
                await ChoosePhoto();
            }
            else if (Action == Video)
            {
                await ChooseVideo();
            }

        }

        async private Task ChoosePhoto()
        {
            string Action, TakePhoto, ChoosePhoto;
            TakePhoto = "Tomar foto";
            ChoosePhoto = "Elegir una de la galeria";

            Action = await App.Current.MainPage.DisplayActionSheet("Subir foto", "Cancelar", null, $"{TakePhoto}", $"{ChoosePhoto}");

            if (Action == TakePhoto)
            {
                await MediaPicker.CapturePhotoAsync();
            }
            else if (Action == ChoosePhoto)
            {
                await MediaPicker.PickPhotoAsync();
            }
        }

        async private Task ChooseVideo()
        {
            string Action, TakeVideo, ChooseVideo;
            TakeVideo = "Tomar video";
            ChooseVideo = "Elegir uno de la galeria";

            Action = await App.Current.MainPage.DisplayActionSheet("Subir video", "Cancelar", null, $"{TakeVideo}", $"{ChooseVideo}");

            if (Action == TakeVideo)
            {
                await MediaPicker.CaptureVideoAsync();
            }
            else if (Action == ChooseVideo)
            {
                await MediaPicker.PickVideoAsync();
            }
        }


        #endregion

        #region FrameTapped
        /*private void FrameTapped()
        {
            bool reportCreated = true;
            Report report = new Report(" ", Title, Subtitle, Image, Description);
            reportList.Add(report);

            //Wiping out the elements of the Report view:
            Title = "";
            Subtitle = "";
            Description = "";

            NavigationParameters parameter = new NavigationParameters();
            parameter.Add("reportList", reportList);
            parameter.Add("reportCreated", reportCreated);

            NavigationService.SelectTabAsync($"{Pages.HomePage}", parameter);
        }*/
        #endregion

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {

        }
    }
}
