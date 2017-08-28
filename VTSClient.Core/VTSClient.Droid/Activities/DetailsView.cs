using System;
using Android.App;
using Android.Support.V4.View;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using VTSClient.Core.Infrastructure.Extentions;
using VTSClient.Core.ViewModels;
using VTSClient.DAL.Enums;
using VTSClient.Droid.Adapters;
using VTSClient.Droid.Infrastracture;
using VTSClient.Droid.Settings;

namespace VTSClient.Droid.Activities
{
    [Activity(Label = "Details", Icon = "@drawable/icon", Theme = "@style/MyTheme.Main", MainLauncher = false)]
    public class DetailsView : MvxAppCompatActivity<DetailViewModel>
	{
        private TextView _startDay, _startMonth, _startYear, _endDay, _endMonth, _endYear;

		private Button _save;

		private RadioButton _approved, _closed;

        private ViewPager _viewPager;

        private Android.Support.V4.App.Fragment[] _fragments;

        private int _position;

		protected override void OnViewModelSet()
		{
			base.OnViewModelSet();

			_position = VacationTypeSetting.GetPosition(VacationType.Exceptional);

			SetContentView(Resource.Layout.DetailsView);

			SetFragment();

			SupportActionBar.SetDisplayShowCustomEnabled(true);

			SupportActionBar.SetCustomView(Resource.Layout.Toolbar);

			SetViewPager();

			FindById();

			BindEvents();

			ApplyBindings();

			VacationTypeSetting.SetButtonsColor(this, _position);
		}

		private void ApplyBindings()
		{
			var bindingSet = this.CreateBindingSet<DetailsView, DetailViewModel>();

			bindingSet.Bind(_startDay)
			   .For(x => x.Text)
			   .To(vm => vm.StartDay);

			bindingSet.Bind(_startMonth)
			   .For(x => x.Text)
			   .To(vm => vm.StartMonth);

			bindingSet.Bind(_startYear)
			  .For(x => x.Text)
			  .To(vm => vm.StartYear);

			bindingSet.Bind(_endDay)
			  .For(x => x.Text)
			  .To(vm => vm.EndDay);

			bindingSet.Bind(_endMonth)
			  .For(x => x.Text)
			  .To(vm => vm.EndMonth);

			bindingSet.Bind(_endYear)
			  .For(x=>x.Text)
			   .To(vm => vm.EndYear);

			//bindingSet.Bind(StatusSegment)
			//  .For("SelectedSegment")
			//   .To(vm => vm.StatusButtonSelectedSegment)
			//   .WithConversion("StatusToNumber");

			//bindingSet.Bind(TypeText)
			//	.For("Text")
			//	.To(vm => vm.TypeText);

			//bindingSet.Bind(Page)
			//	.For("CurrentPage")
			//	.To(vm => vm.Page);

			bindingSet.Bind(_approved)
			   .To(vm => vm.ChangeToApprovedCommand);

			bindingSet.Bind(_closed)
			   .To(vm => vm.ChangeToClosedCommand);

			bindingSet.Bind(_save)
			   .To(vm => vm.SaveCommand);

			//bindingSet.Bind(Page)
			//   .For("ValueChanged")
			//   .To(vm => vm.SwipeEventCommand);

			bindingSet.Apply();
		}

		private void FindById()
		{
			_startDay = FindViewById<TextView>(Resource.Id.startDateTextView);
			_startMonth = FindViewById<TextView>(Resource.Id.startMonthTextView);
			_startYear = FindViewById<TextView>(Resource.Id.startYearTextView);

			_endDay = FindViewById<TextView>(Resource.Id.endDateTextView);
			_endMonth = FindViewById<TextView>(Resource.Id.endMonthTextView);
			_endYear = FindViewById<TextView>(Resource.Id.endYearTextView);

			_approved = FindViewById<RadioButton>(Resource.Id.radioButtonApproved);
			_closed = FindViewById<RadioButton>(Resource.Id.radioButtonClosed);
			_save = FindViewById<Button>(Resource.Id.Save);
		}

		private void SetFragment()
		{
			var namesEnum = Enum.GetNames(typeof(VacationType));

			_fragments = new Android.Support.V4.App.Fragment[namesEnum.Length];

			for (var i = 0; i < namesEnum.Length; i++)
			{
				_fragments[i] = new VacationTypeFragment(namesEnum[i]);
			}
		}

		private void SetViewPager()
		{
			_viewPager = FindViewById<ViewPager>(Resource.Id.viewPager);

			_viewPager.Adapter = new TypesAdapter(SupportFragmentManager, _fragments);

			_viewPager.SetCurrentItem(_position, true);
		}


		private void DateStartSelect_OnClick(object sender, EventArgs eventArgs)
		{
			var frag = DatePickerFragment.NewInstance(delegate (DateTime time)
			{
				_startMonth.Text = time.ToShortMonth();

				_startDay.Text = time.Day.ToString();

				_startYear.Text = time.Year.ToString();
			});

			frag.Show(SupportFragmentManager, DatePickerFragment.TAG);
		}

		private void Item_OnClick(object sender, ViewPager.PageSelectedEventArgs e)
		{
			OnItemClick(e.Position);
		}


		private void DateEndSelect_OnClick(object sender, EventArgs eventArgs)
		{
			var frag = DatePickerFragment.NewInstance(delegate (DateTime time)
			{
				_endMonth.Text = time.ToShortMonth();

				_endDay.Text = time.Day.ToString();

				_endYear.Text = time.Year.ToString();
			});

			frag.Show(SupportFragmentManager, DatePickerFragment.TAG);
		}

		private void BindEvents()
		{
			_startDay.Click += DateStartSelect_OnClick;
			_startMonth.Click += DateStartSelect_OnClick;
			_startYear.Click += DateStartSelect_OnClick;

			_endDay.Click += DateEndSelect_OnClick;
			_endMonth.Click += DateEndSelect_OnClick;
			_endYear.Click += DateEndSelect_OnClick;

			_viewPager.PageSelected += Item_OnClick;

			SupportFragmentManager.BackStackChanged += OnBackStackChanged;
		}

		private void OnBackStackChanged(object sender, EventArgs e)
		{
			var hasBack = SupportFragmentManager.BackStackEntryCount > 0;
			SupportActionBar.SetDisplayHomeAsUpEnabled(hasBack);
		}

		private void OnItemClick(int position)
		{
			VacationTypeSetting.SetButtonsColor(this, position);
			_position = position;
		}
	}
}