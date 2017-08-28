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
using VacationTypeSetting = VTSClient.Droid.Settings.VacationTypeSetting;

namespace VTSClient.Droid.Activities
{
    [Activity(Label = "Details", Icon = "@drawable/icon", Theme = "@style/MyTheme.Main", MainLauncher = false)]
    public class DetailsView : MvxAppCompatActivity<DetailViewModel>
	{
        private TextView _startDay;
		private TextView _startMonth;
		private TextView _startYear;
		private TextView _endDay;
		private TextView _endMonth;
		private TextView _endYear;
		private TextView _positionView;

		private Button _save;

		private RadioButton _approved, _closed;

        private ViewPager _viewPager;

        private Android.Support.V4.App.Fragment[] _fragments;

		protected override void OnViewModelSet()
		{
			base.OnViewModelSet();

			SetContentView(Resource.Layout.DetailsView);

			SetFragment();

			SupportActionBar.SetDisplayShowCustomEnabled(true);

			SupportActionBar.SetCustomView(Resource.Layout.Toolbar);

			FindById();

			BindEvents();

			ApplyBindings();

			SetViewPager();

			VacationTypeSetting.SetButtonsColor(this, int.Parse(_positionView.Text));
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


			bindingSet.Bind(_positionView)
			  .For(x => x.Text)
			  .To(vm => vm.Position);


			bindingSet.Bind(_positionView)
			  .For("Hidden")
			  .To(vm => vm.IsDatePickerToolbar);

			bindingSet.Bind(_approved)
			   .To(vm => vm.ChangeToApprovedCommand);

			bindingSet.Bind(_closed)
			   .To(vm => vm.ChangeToClosedCommand);

			bindingSet.Bind(_save)
			   .To(vm => vm.SaveCommand);

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

			_positionView = FindViewById<TextView>(Resource.Id.positionValue);
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

			_viewPager.SetCurrentItem(int.Parse(_positionView.Text), true);

			_viewPager.PageSelected += Item_OnClick;
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

			_positionView.Text = position.ToString();
		}
	}
}