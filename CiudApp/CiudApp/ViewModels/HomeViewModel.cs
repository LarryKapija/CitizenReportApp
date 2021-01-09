using CiudApp.Models;
using Plugin.GoogleClient;
using Plugin.GoogleClient.Shared;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiudApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {

        #region Commands and Attributes:
        public ICommand NavegateCommand { get; }

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

        public short reportNumber;
        public short ReportNumber
        {
            get
            {
                return reportNumber;
            }

            set
            {
                reportNumber = value;
                GetNotify(nameof(reportNumber));
            }
        }

        public String reportTitle;
        public String ReportTitle
        {
            get
            {
                return reportTitle;
            }
            set
            {
                reportTitle = value;
                GetNotify(nameof(ReportTitle));
            }
        }

        public String progress;
        public String Progress
        {
            get
            {
                return progress;
            }
            set
            {
                progress = value;
                GetNotify(nameof(Progress));
            }
        }

        public String imageSource;
        public String ImageSource
        {
            get
            {
                return imageSource;
            }

            set
            {
                imageSource = value;
                GetNotify(nameof(ImageSource));
            }
        }
        public User User { get; set; }
        #endregion

        //Functions:
        #region HomeViewModel
        public HomeViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            ReportNumber = 0; //This is for the example, this number should come from the db.
            //addData();

            // NavegateCommand = new Command(async () => await Navigate());
        }


        #endregion

        #region Navigate
        //async Task Navigate()
        //{
        //    await NavigationService.NavigateAsync(Pages.ProfilePage);
        //}
        #endregion

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        #region OnNavigatedTo
        public override void OnNavigatedTo(INavigationParameters parameters)
        {

            if (parameters.TryGetValue("user", out User user))
            {
                User = parameters.GetValue<User>("user");
                Title = $"Bienvenido {User.Name}";
            }
            else if (parameters.TryGetValue("report", out Report reports))//GetValue<bool>("reportCreated"))
            {
                Report.Add(reports);

                String display = "";
                //Display all elements of the list.
                foreach(var element in Report)
                {
                    display += $"{element.Title}\n";
                }
                PageDialog.DisplayAlertAsync("Elements from de list", display, "Ok");
            }

        }
        #endregion

        #region addData()

        public ObservableCollection<Report> Report { get; } = new ObservableCollection<Report>();
        #endregion


    }
}

