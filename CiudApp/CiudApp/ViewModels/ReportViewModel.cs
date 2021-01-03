using Prism.Commands;
using Prism.Navigation;
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
        #region Commands
        public DelegateCommand IsEnableCommand { get; set; }
        #endregion

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

        //Functions:

        #region ReportViewModel
        public ReportViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            IsEnable = false;
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
