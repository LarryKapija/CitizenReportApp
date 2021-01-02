using Prism.Navigation;
using Prism.Services;
using System;
using System.ComponentModel;

namespace CiudApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged , INavigatedAware

    {
        #region Attributes:
        protected INavigationService NavigationService { get; }
        protected IPageDialogService PageDialog { get; }
        protected INavigatedAware NavigatedAware { get; }
        #endregion

        //Functions:
        #region BaseViewModel
        protected BaseViewModel(INavigationService navigationService, IPageDialogService pageDialogService, INavigatedAware navigatedAware )
        {
            NavigationService = navigationService;
            PageDialog = pageDialogService;
            NavigatedAware = navigatedAware;
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

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
