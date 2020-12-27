using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CiudApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        //Atributes:
        protected INavigationService NavigationService { get; }

        //Functions:
        #region BaseViewModel
        protected BaseViewModel(INavigationService navigationService )
        {
            NavigationService = navigationService;
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
