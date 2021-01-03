using Prism.Navigation;
using Prism.Services;
using System;
using System.ComponentModel;

namespace CiudApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged, INavigatedAware

    {
        #region Attributes:
        protected INavigationService NavigationService { get; }
        protected IPageDialogService PageDialog { get; }
        #endregion

        //Functions:
        #region BaseViewModel
        protected BaseViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            PageDialog = pageDialogService;
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

        public abstract void OnNavigatedFrom(INavigationParameters parameters);
        public abstract void OnNavigatedTo(INavigationParameters parameters);


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
