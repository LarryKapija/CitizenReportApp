using CiudApp.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiudApp.ViewModels
{
    class ReportViewModel : BaseViewModel
    {
        #region Commands and Attributes:
        public ICommand frameCommand { get; set; }

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
        #endregion

        //Functions:

        #region ReportViewModel
        public ReportViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            IsEnable = false;
            frameCommand = new Command(frameTapped);
        }
        #endregion

        private void frameTapped()
        {
            bool reportCreated = true;
            Report report = new Report(" ", Title, Subtitle, null, Description);
            IList<Report> reportList = new List<Report>();
            reportList.Add(report);

            NavigationParameters parameter = new NavigationParameters();
            parameter.Add("reportList", reportList);
            parameter.Add("reportCreated", reportCreated);

            NavigationService.SelectTabAsync($"{Pages.HomePage}", parameter);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
    }
}
