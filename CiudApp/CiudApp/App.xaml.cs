using CiudApp.Models;
using CiudApp.ViewModels;
using CiudApp.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace CiudApp
{
    public partial class App : PrismApplication
    { 

        public App(IPlatformInitializer platformInitializer) :base(platformInitializer)
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        #region RegisterTypes
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            

            #region Pages
            containerRegistry.RegisterForNavigation<NavigationPage>("NavigationPage");
            containerRegistry.RegisterForNavigation<AccountConfigurationPage, AccountConfigurationViewModel>(Pages.AccountConfigurationPage);
            containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>(Pages.HomePage);
            containerRegistry.RegisterForNavigation<LogInPage, LogInViewModel>(Pages.LogIn);
            containerRegistry.RegisterForNavigation<MainPage>(Pages.MainPage);
            containerRegistry.RegisterForNavigation<NewEventPage, NewEventViewModel>("NewEvent");
            containerRegistry.RegisterForNavigation<ProfilePage , ProfileViewModel>(Pages.ProfilePage);
            containerRegistry.RegisterForNavigation<ReportPage, ReportViewModel>(Pages.ReportPage);
            containerRegistry.RegisterForNavigation<ReportFormPage, ReportFormViewModel>(Pages.ReportForm);
            containerRegistry.RegisterForNavigation<MapPage, MapViewModel>(Pages.MapPage);
            containerRegistry.RegisterForNavigation<SearchPage, MapViewModel>(Pages.SearchPage);
            containerRegistry.RegisterForNavigation<SingInPage, SingInViewModel>(Pages.SingIn);
            #endregion

        }
        #endregion

        #region OnInitialized
        protected override async void OnInitialized()
        {
            await NavigationService.NavigateAsync(Pages.LogIn);
        }
        #endregion
    }
}
