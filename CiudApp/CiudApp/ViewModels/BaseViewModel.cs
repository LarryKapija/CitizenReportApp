using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CiudApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Attributes:
        protected INavigationService NavigationService { get; }
        #endregion

        //Functions:
        #region BaseViewModel
        protected BaseViewModel(INavigationService navigationService )
        {
            NavigationService = navigationService;
        }
        #endregion

        #region GetNotify
        /// <summary>
        /// This function is invoke anytime there's a view model that wants to change 
        /// any of the elements displayed in the page.
        /// </summary>
        /// <param name="property">
        ///     Name of the Attribute that needs to be changed.
        ///     I usually use nameof(Attribute)
        /// </param>
        protected void GetNotify(String property)
        {
            PropertyChanged?.Invoke(this, 
                new PropertyChangedEventArgs(property));
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
