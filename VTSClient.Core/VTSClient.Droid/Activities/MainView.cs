using Android.App;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Widget;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Views;
using VTSClient.Core.ViewModels;
using VTSClient.DAL.Enums;
using VTSClient.Droid.Fragments;
using VTSClient.Droid.Fragments.MVx;
using ActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;

namespace VTSClient.Droid.Activities
{
	[Activity(Label = "Vacations", Theme = "@style/MyTheme.Main", MainLauncher = false, Icon = "@drawable/icon")]
	public class MainView : MvxActivity<MenuViewModel>
	{
		ActionBarDrawerToggle _drawerToggle;

		private readonly string[] _titles = { "All", "Opened", "Closed" };

		private DrawerLayout _drawerLayout;

		private ListView _drawerListView;

		private MvxFragment [] _fragments;

		private Android.Support.V7.Widget.ListViewCompat _vacationList;

		protected override void OnViewModelSet()
		{
			base.OnViewModelSet();
			
			SetContentView(Resource.Layout.Main);

			_drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);

			//_vacationList = FindViewById<ListView>(Resource.Id.);

			_drawerToggle = new ActionBarDrawerToggle(this, _drawerLayout, Resource.String.DrawerOpenDescription,
				Resource.String.DrawerCloseDescription);

			_drawerLayout.SetDrawerListener(_drawerToggle);

			SetDrawerListView();
		}

		private void SetDrawerListView()
		{
			_drawerListView = FindViewById<ListView>(Resource.Id.menuList);

			var userView = LayoutInflater.Inflate(Resource.Layout.UserInfo, _drawerListView, false);

			userView.Clickable = false;

			_drawerListView.AddHeaderView(userView);

			_drawerListView.Adapter = new ArrayAdapter<string>(this, Resource.Layout.ListViewMenuRow,
				Resource.Id.menuRowTextView, _titles);

			_drawerListView.SetItemChecked(0, true);
		}
	}
}