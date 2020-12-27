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
        public Pages pages = new Pages();
        

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
                containerRegistry.RegisterForNavigation<AccountConfigurationPage, AccountConfigurationViewModel>("AccountConfiguration");
                containerRegistry.RegisterForNavigation<CalendarPage, CalendarViewModel>("Calendar");
                containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>("Home");
                containerRegistry.RegisterForNavigation<MainPage, MainViewModel>("Main");
                containerRegistry.RegisterForNavigation<NewEventPage, NewEventViewModel>("NewEvent");
                containerRegistry.RegisterForNavigation<ProfilePage , ProfileViewModel>("Profile");
                containerRegistry.RegisterForNavigation<ReportPage, ReportViewModel>("Report");
            #endregion

        }
        #endregion

        #region OnInitialized
        protected override async void OnInitialized()
        {
            await NavigationService.NavigateAsync(pages.MainPage);
        }
        #endregion
    }
}
