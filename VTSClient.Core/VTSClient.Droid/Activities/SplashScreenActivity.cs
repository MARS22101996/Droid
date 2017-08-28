using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace VTSClient.Droid.Activities
{
	[Activity(
	   Label = "Vacations",
	   MainLauncher = true,
	   NoHistory = true,
	   Theme = "@style/MyTheme.Splash")]
	public class SplashView : MvxSplashScreenActivity
	{
		public SplashView()
		{
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}
	}
}
