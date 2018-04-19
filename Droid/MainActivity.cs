using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;

namespace GabDemo.Droid
{
    [Activity(Label = "GabDemo.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            InitializeAppCenter();

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }

        private void InitializeAppCenter()
        {
            // set the log level
            AppCenter.LogLevel = LogLevel.Verbose;

            // customize push
            // Push.SetSenderId("");

            AppCenter.Start("ec628b35-1c61-4eda-9810-138c732fa3e0",
                            typeof(Analytics), 
                            typeof(Crashes), 
                            typeof(Distribute),
                            typeof(Push));
        }
    }
}