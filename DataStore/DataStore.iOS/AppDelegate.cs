
using DataStore.Models;
using Foundation;
using Mobility.Infrastructure.Services;
using UIKit;
using Xamarin.Forms;

namespace DataStore.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
            Xamarin.Forms.DependencyService.Register<DataStore.Data.MockDataStore>();
            IDataStore<Item> ItemDataStore = DependencyService.Get<IDataStore<Item>>();

            LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
