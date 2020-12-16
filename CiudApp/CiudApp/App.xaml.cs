﻿using CiudApp.Views;
using Xamarin.Forms;

namespace CiudApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ReportPage();
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
    }
}
