using Android.App;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views;
using VTSClient.Core.ViewModels;
using VTSClient.Droid.Adapters;
using ActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;

namespace VTSClient.Droid.Activities
{
	[Activity(Label = "Vacations", Theme = "@style/MyTheme.Main", MainLauncher = false, Icon = "@drawable/icon")]
	public class VacationsView : MvxAppCompatActivity<VacationViewModel>
	{
		ActionBarDrawerToggle _drawerToggle;

		private readonly string[] _titles = { "All", "Opened", "Closed" };

		private DrawerLayout _drawerLayout;

		private ListView _drawerListView;

		private MvxRecyclerView _contriesRecyclerView;

		private VacationsAdapter _vacationsAdapter;

		protected override void OnViewModelSet()
		{
			base.OnViewModelSet();
			
			SetContentView(Resource.Layout.Main);

			_drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);

			_contriesRecyclerView = FindViewById<MvxRecyclerView>(Resource.Id.countriesView);

			_vacationsAdapter = new VacationsAdapter((IMvxAndroidBindingContext)this.BindingContext);

			_contriesRecyclerView.Adapter = _vacationsAdapter;

			_contriesRecyclerView.SetLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.Vertical, false));

			ApplyBindings();
		}

		private void ApplyBindings()
		{
			var bindingSet = this.CreateBindingSet<VacationsView, VacationViewModel>();

			bindingSet.Bind(_vacationsAdapter)
				.For(x => x.ItemsSource)
				.To(x => x.Vacations);

			bindingSet.Apply();

			_vacationsAdapter.NotifyDataSetChanged();
		}
	}
}