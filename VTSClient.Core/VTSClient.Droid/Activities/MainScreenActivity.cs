using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using VTSClient.Droid.Fragments;
using ActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;
using VTSClient.DAL.Enums;

namespace VTSClient.Droid.Activities
{
    [Activity(Label = "Vacations", Theme = "@style/MyTheme.Main", MainLauncher = false, Icon = "@drawable/icon")]
    public class MainScreenActivity : AppCompatActivity
    {
        ActionBarDrawerToggle _drawerToggle;
        private readonly string[] _titles = {"All", "Opened", "Closed"};

        private DrawerLayout _drawerLayout;
        private ListView _drawerListView;

        private Android.Support.V4.App.Fragment[] _fragments;

        [Register(".ctor", "()V", "")]
        public MainScreenActivity()
        {
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return _drawerToggle.OnOptionsItemSelected(item) || base.OnOptionsItemSelected(item);
        }

        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            _drawerToggle.SyncState();

            base.OnPostCreate(savedInstanceState);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _fragments = new Android.Support.V4.App.Fragment[]
            {
                new FilterFragment(this, FilterEnum.All),
                new FilterFragment(this, FilterEnum.Opened),
                new FilterFragment(this, FilterEnum.Closed)
            };

            SetContentView(Resource.Layout.Main);

            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
            _drawerToggle = new ActionBarDrawerToggle(this, _drawerLayout, Resource.String.DrawerOpenDescription,
                Resource.String.DrawerCloseDescription);
            _drawerLayout.SetDrawerListener(_drawerToggle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetIcon(Android.Resource.Color.Transparent);

            SetDrawerListView();      
            BindEvents();

            OnMenuItemClick(0);
        }

        protected override void OnDestroy()
        {
            UnbindEvents();
            base.OnDestroy();
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

        private void OnMenuItemClick(int position)
        {
            if (position < 0) return;
            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, _fragments[position]).Commit();

           Title = _titles[position];

            _drawerLayout.CloseDrawer(_drawerListView);
        }

        private void MenuClicked(object sender, AdapterView.ItemClickEventArgs e)
        {
            OnMenuItemClick(e.Position - 1);
        }

        private void BindEvents()
        {
            _drawerListView.ItemClick += MenuClicked;
            SupportFragmentManager.BackStackChanged += OnBackStackChanged;
        }

        private void OnBackStackChanged(object sender, EventArgs e)
        {
            var hasBack = SupportFragmentManager.BackStackEntryCount > 0;
            SupportActionBar.SetDisplayHomeAsUpEnabled(hasBack);
        }

        private void UnbindEvents()
        {
            _drawerListView.ItemClick -= MenuClicked;
            SupportFragmentManager.BackStackChanged -= OnBackStackChanged;
        }
    }
}