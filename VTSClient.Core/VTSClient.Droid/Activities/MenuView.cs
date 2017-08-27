using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Support.V7.RecyclerView;
using VTSClient.Core.ViewModels;
using VTSClient.Droid.Adapters;
using MvvmCross.Binding.BindingContext;

namespace VTSClient.Droid.Activities
{
	[Activity(Label = "Menu", Theme = "@style/MyTheme.Main", MainLauncher = false, Icon = "@drawable/icon")]
	public class MenuView : MvxAppCompatActivity<MenuViewModel>
	{
		private MvxRecyclerView _segmentsRecyclerView;

		private SegmentAdapter _segmentAdapter;

		protected override void OnViewModelSet()
		{
			base.OnViewModelSet();

			SetContentView(Resource.Layout.Menu);

			_segmentsRecyclerView = FindViewById<MvxRecyclerView>(Resource.Id.segmentView);

			_segmentAdapter = new SegmentAdapter((IMvxAndroidBindingContext)this.BindingContext);

			_segmentsRecyclerView.Adapter = _segmentAdapter;

			_segmentsRecyclerView.SetLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.Vertical, false));

			ApplyBindings();
		}

		private void ApplyBindings()
		{
			var bindingSet = this.CreateBindingSet<MenuView, MenuViewModel>();

			bindingSet.Bind(_segmentAdapter)
				.For(x => x.ItemsSource)
				.To(x => x.Sections);

			bindingSet.Apply();

			_segmentAdapter.NotifyDataSetChanged();
		}
	}
}