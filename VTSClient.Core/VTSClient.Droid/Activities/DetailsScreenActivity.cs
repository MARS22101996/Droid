using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Widget;
using Autofac;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.Core.Infrastructure.Extentions;
using VTSClient.Core.ViewModels;
using VTSClient.DAL.Enums;
using VTSClient.Droid.Adapters;
using VTSClient.Droid.Infrastracture;
using VTSClient.Droid.Settings;
using AutofacSetting = VTSClient.Droid.Autofac.AutofacSetting;

namespace VTSClient.Droid.Activities
{
    [Activity(Label = "Details", Icon = "@drawable/icon", Theme = "@style/MyTheme.Main", MainLauncher = false)]
    public class DetailsScreenActivity : MvxAppCompatActivity<DetailViewModel>
	{
        private VacationDto _currentVacation;

        private TextView _startDay, _startMonth, _startYear, _endDay, _endMonth, _endYear, _save;

        private RadioButton _approved, _closed;

        private ViewPager _viewPager;

        private Android.Support.V4.App.Fragment[] _fragments;
        private int _position;

        private  IApiVacationService _vacationService;

		protected override void OnViewModelSet()
		{
			base.OnViewModelSet();

			AutofacSetting.Initialize();

			_vacationService = AutofacSetting.Container.Resolve<IApiVacationService>();

			var vacationId = Intent.GetStringExtra("VacationId");

			_currentVacation = (vacationId != null)
				? _vacationService.GetVacationByIdAsync(Guid.Parse(vacationId)).Result
				: new VacationDto
				{
					Id = Guid.NewGuid(),
					CreatedBy = "Ark",
					End = DateTime.UtcNow,
					Start = DateTime.UtcNow,
					VacationStatus = VacationStatus.Approved,
					VacationType = VacationType.Exceptional
				};

			_position = VacationTypeSetting.GetPosition(_currentVacation.VacationType);
			SetContentView(Resource.Layout.DetailsView);
			SetFragment();
			SupportActionBar.SetDisplayShowCustomEnabled(true);
			SupportActionBar.SetCustomView(Resource.Layout.Toolbar);
			SetViewPager();

			FindById();
			GetDate();
			BindEvents();

			VacationTypeSetting.SetButtonsColor(this, _position);
		}

		//protected override void OnDestroy()
		//{
		//    UnbindEvents();
		//    base.OnDestroy();
		//}

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
			_save = FindViewById<TextView>(Resource.Id.Save);
		}

		private void GetDate()
		{
			_startDay.Text = _currentVacation.Start.Day.ToString();
			_startMonth.Text = _currentVacation.Start.ToShortMonth();
			_startYear.Text = _currentVacation.Start.Year.ToString();

			_endDay.Text = _currentVacation.End.Day.ToString();
			_endMonth.Text = _currentVacation.End.ToShortMonth();
			_endYear.Text = _currentVacation.End.Year.ToString();
		}

		private void SetFragment()
		{
			var namesEnum = Enum.GetNames(typeof(VacationType));
			_fragments = new Android.Support.V4.App.Fragment[namesEnum.Length];

			for (int i = 0; i < namesEnum.Length; i++)
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

		private void Save_OnClick(object sender, EventArgs eventArgs)
		{
			_currentVacation.VacationType = VacationTypeSetting.GetType(_position);
			_vacationService.CreateVacationAsync(_currentVacation);
			//StartActivity(new Intent(this, typeof(MainScreenActivity)));
		}

		private void DateStartSelect_OnClick(object sender, EventArgs eventArgs)
		{
			var frag = DatePickerFragment.NewInstance(delegate (DateTime time)
			{
				_startMonth.Text = time.ToShortMonth();
				_startDay.Text = time.Day.ToString();
				_startYear.Text = time.Year.ToString();
				_currentVacation.Start = time.Date;
			});

			frag.Show(SupportFragmentManager, DatePickerFragment.TAG);
		}

		private void Item_OnClick(object sender, ViewPager.PageSelectedEventArgs e)
		{
			OnItemClick(e.Position);
		}

		private void Approved_OnClick(object sender, EventArgs eventArgs)
		{
			_currentVacation.VacationStatus = VacationStatus.Approved;
		}

		private void Canceled_OnClick(object sender, EventArgs eventArgs)
		{
			_currentVacation.VacationStatus = VacationStatus.Closed;
		}

		private void DateEndSelect_OnClick(object sender, EventArgs eventArgs)
		{
			var frag = DatePickerFragment.NewInstance(delegate (DateTime time)
			{
				_endMonth.Text = time.ToShortMonth();
				_endDay.Text = time.Day.ToString();
				_endYear.Text = time.Year.ToString();
				_currentVacation.End = time.Date;
			});

			frag.Show(SupportFragmentManager, DatePickerFragment.TAG);
		}

		private void BindEvents()
		{
			_approved.Click += Approved_OnClick;
			_closed.Click += Canceled_OnClick;

			_startDay.Click += DateStartSelect_OnClick;
			_startMonth.Click += DateStartSelect_OnClick;
			_startYear.Click += DateStartSelect_OnClick;

			_endDay.Click += DateEndSelect_OnClick;
			_endMonth.Click += DateEndSelect_OnClick;
			_endYear.Click += DateEndSelect_OnClick;

			_save.Click += Save_OnClick;
			_viewPager.PageSelected += Item_OnClick;

			SupportFragmentManager.BackStackChanged += OnBackStackChanged;
		}

		private void UnbindEvents()
		{
			_approved.Click -= Approved_OnClick;
			_closed.Click -= Canceled_OnClick;

			_startDay.Click -= DateStartSelect_OnClick;
			_startMonth.Click -= DateStartSelect_OnClick;
			_startYear.Click -= DateStartSelect_OnClick;

			_endDay.Click -= DateEndSelect_OnClick;
			_endMonth.Click -= DateEndSelect_OnClick;
			_endYear.Click -= DateEndSelect_OnClick;

			_save.Click -= Save_OnClick;
			_viewPager.PageSelected -= Item_OnClick;

			SupportFragmentManager.BackStackChanged -= OnBackStackChanged;
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