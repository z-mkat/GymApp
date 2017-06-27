using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace GymApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(0, 56, 99);
            UINavigationBar.Appearance.BarStyle = UIBarStyle.Black;
            UINavigationBar.Appearance.TintColor = UIColor.White;

            return base.FinishedLaunching(app, options);
        }
    }
}
