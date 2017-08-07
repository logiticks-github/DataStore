using Android.App;
using Android.Content.PM;
using Android.OS;
using DataStore.Models;
using DataStore.UI.Android;
using Mobility.Infrastructure.Services;
using Xamarin.Forms;

namespace DataStore.UI.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
           
            global::Xamarin.Forms.Forms.Init(this, bundle);
            IDataStore<Item> ItemDataStore = DependencyService.Get<IDataStore<Item>>();
            LoadApplication(new App());
        }
    }
}