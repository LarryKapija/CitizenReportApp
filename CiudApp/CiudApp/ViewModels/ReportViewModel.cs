using CiudApp.Models;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CiudApp.ViewModels
{
    public class ReportViewModel : BaseViewModel
    {

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


        public ICommand NavigationCommand { get; }

        public async Task Navigate()
        {
            await NavigationService.NavigateAsync(Pages.ReportForm);
        }

        public ReportViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            NavigationCommand = new Command(async () => await Navigate());
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.TryGetValue("report", out Report reports))
            {
                Report.Add(reports);
                NavigationService.SelectTabAsync($"{Pages.HomePage}", parameters);
            }
        }

        public ObservableCollection<Report> Report { get; } = new ObservableCollection<Report>();
    }
 
}
