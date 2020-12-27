using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Plugin.GoogleClient;
using Prism;
using Prism.Ioc;
using UIKit;

namespace CiudApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            GoogleClientManager.Initialize(); //For the Google auth.

            LoadApplication(new App(new IosInitializer()));

            return base.FinishedLaunching(app, options);
        }

        #region OpenUrl
        /// <summary>
        /// This method is override to complete de auth of google API in the Android Project.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="url"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            return GoogleClientManager.OnOpenUrl(app, url, options);
        }
        #endregion

        public class IosInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
               
            }
        }
    }
}
