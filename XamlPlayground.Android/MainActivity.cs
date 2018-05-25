using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Plugin.Toasts;
using Acr.UserDialogs;

namespace XamarinFormsStarterKit.UserInterfaceBuilder.XamlPlayground.Droid.Droid
{
    [Activity(Label = "XamlPlayground", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
		internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
			Instance = this;
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

			UserDialogs.Init(() => Instance);

            LoadApplication(new App());
        }
    }
}

