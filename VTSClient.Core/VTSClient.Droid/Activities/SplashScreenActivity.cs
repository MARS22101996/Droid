using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using MvvmCross.Droid.Views;

namespace VTSClient.Droid.Activities
{
	[Activity(
	   Label = "Guest Guide",
	   MainLauncher = true,
	   NoHistory = true,
	   Theme = "@style/MyTheme.Splash")]
	public class SplashActivity : AppCompatActivity
	{
		public SplashActivity()
		{
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			StartActivity(new Intent(this, typeof(MainScreenActivity)));
		}
	}
}
